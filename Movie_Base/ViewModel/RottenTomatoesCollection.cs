using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Movie_Base.Model;

namespace Movie_Base.ViewModel
{
    public class RottenTomatoesCollection
    {
        private static readonly RottenTomatoesCollection _movieData = new RottenTomatoesCollection();

        private readonly ObservableCollection<MovieGroup> _allGroups = new ObservableCollection<MovieGroup>();
        public ObservableCollection<MovieGroup> AllGroups
        {
            get { return this._allGroups; }
        }

        public static IEnumerable<MovieGroup> GetGroups(string uniqueId)
        {
            return _movieData.AllGroups;
        }

        public static MovieGroup GetGroupById(string uniqueId)
        {
            var matches = _movieData.AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static MovieGroup GetGroupByTitle(string title)
        {
            var matches = _movieData.AllGroups.Where((group) => group.Title.Equals(title));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static MovieItem GetItem(string uniqueId)
        {
            var matches = _movieData.AllGroups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static void Copy(RottenTomatoesMovies response, string groupId, string groupName)
        {
            try
            {
                MovieGroup movieGroup = RottenTomatoesCollection.GetGroupByTitle(groupName);
                if (movieGroup != null)
                    movieGroup.Items.Clear();
                else
                    movieGroup = new MovieGroup(groupId, groupName, response.Movies[0].Posters.Original);

                foreach (var movieItem in response.Movies.Select(movie => new MovieItem(
                    movie.Id,
                    movie.Title,
                    movie.MPAARating,
                    movie.Ratings.AudienceRating,
                    movie.Ratings.CriticsRating,
                    movie.Links.Clips,
                    movie.Links.Reviews,
                    movie.Links.Cast,
                    movie.Posters.Original,
                    movie.Synopsis,
                    movieGroup)))
                {
                    movieGroup.Items.Add(movieItem);
                }
                _movieData._allGroups.Add(movieGroup);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
