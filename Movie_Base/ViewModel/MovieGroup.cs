using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Movie_Base.ViewModel
{
    public class MovieGroup : MovieGroupCommom
    {
        public MovieGroup(String uniqueId, String title, String imagePath)
            : base(uniqueId, title, imagePath)
        {
            Items.CollectionChanged += ItemsCollectionChanged;
        }

        private void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex < Items.Count)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        if (TopItems.Count > Items.Count)
                        {
                            TopItems.RemoveAt(Items.Count);
                        }
                    }
                    break;
            }
        }

        private ObservableCollection<MovieItem> _items = new ObservableCollection<MovieItem>();
        public ObservableCollection<MovieItem> Items
        {
            get { return this._items; }
        }

        private ObservableCollection<MovieItem> _topItem = new ObservableCollection<MovieItem>();
        public ObservableCollection<MovieItem> TopItems
        {
            get { return this._topItem; }
        }
    }
}
