using System;
using System.Collections.ObjectModel;
using System.Linq;
using Movie_Base.Model;

namespace Movie_Base.ViewModel
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public class MovieReviewGroup
    {
        private ObservableCollection<MovieReviewItem> _items;

        public MovieReviewGroup()
        {
            _items = new ObservableCollection<MovieReviewItem>();
        }

        public ObservableCollection<MovieReviewItem> Items
        {
            get { return this._items; }
        }

        public void Copy(MovieReviews movieReviews)
        {
            foreach (var movieItem in movieReviews.Reviews.Select(review => new MovieReviewItem(
                    review.Critic,
                    review.Date,
                    review.Freshness,
                    review.Publication,
                    review.Quote,
                    review.Link.Review)))
            {
                this._items.Add(movieItem);
            }
        }
    }
}