﻿using System;
using System.Linq;
using Movie_Base.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Movie_Base.View
{
    public sealed partial class ReviewControl : UserControl
    {
        public ReviewControl()
        {
            this.InitializeComponent();

            var bounds = Window.Current.Bounds;
            this.RootPanel.Width = bounds.Width;
            this.RootPanel.Height = bounds.Height - 200;
        }

        public MovieReviewGroup MovieReviews { get; set; }

        public void Initialize()
        {
            MovieReviewItems.ItemsSource = MovieReviews.Items;
            MovieReviewItems.SelectedIndex = 0;
        }

        private void CriticsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mi = (MovieReviewItem)MovieReviewItems.SelectedItem;
            if (mi != null)
            {
                if (mi.Link != null)
                {
                    ReviewPage.Navigate(new Uri(mi.Link));
                }

            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            var parent = (Popup)this.Parent;
            parent.IsOpen = false;
        }
    }
}
