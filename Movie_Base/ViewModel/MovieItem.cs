using System;
using System.Linq;

namespace Movie_Base.ViewModel
{
    public class MovieItem : MovieItemCommom
    {
        private string message;

        public MovieItem(string uniqueId, string title, string rating, string audienceScore, string criticsScore, string clips, string reviews, string cast, string imagePath, string description, MovieGroup movieGroup)
            : base(uniqueId, title, rating, audienceScore, criticsScore, clips, reviews, cast, imagePath, description)
        {
            this._movieGroup = movieGroup;
        }

        private MovieGroup _movieGroup;
        public MovieGroup MovieGroup
        {
            get { return this._movieGroup; }
            set { this.SetProperty(ref this._movieGroup, value); }
        }

        public string Message
        {
            get { return this.message; }
            set { this.SetProperty(ref this.message, value); }
        }
    }
}
