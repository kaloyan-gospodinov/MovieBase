using System;
using System.Collections.Generic;
using System.Linq;
using Movie_Base.Common;
using Movie_Base.Model;
using Movie_Base.Services;
using Movie_Base.ViewModel;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Movie_Base.View
{
    public sealed partial class GroupedItemsPage : Movie_Base.Common.LayoutAwarePage
    {
        private readonly InvokeApi _apiInvokeInTheaters;

        public static GroupedItemsPage Current;
        private static bool _loaded = false;

        public GroupedItemsPage()
        {
            this.InitializeComponent();
            _apiInvokeInTheaters = new InvokeApi();
            _apiInvokeInTheaters.OnResponse += apiInvoke_OnResponseInTheaters;

            var settingsPane = SettingsPane.GetForCurrentView();
              
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var movieGroups = RottenTomatoesCollection.GetGroups((String)navigationParameter);
            this.DefaultViewModel["Groups"] = movieGroups;

            if (!_loaded) Invoke();
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = ((MovieItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }

        private void Invoke()
        {
            var apiCall = Globals.ROTTEN_TOMATOES_API_MOVIES_INTHEATERS;
            _apiInvokeInTheaters.Invoke<RottenTomatoesMovies>(apiCall);
        }

        async private void apiInvoke_OnResponseInTheaters(object sender, Event e)
        {
            var response = (RottenTomatoesMovies)e.Object;

            if (e.Status == Status.SUCCESS)
            {
                RottenTomatoesCollection.Copy(response, System.Guid.NewGuid().ToString(), "In Theaters");
                this.DefaultViewModel["AllGroups"] = RottenTomatoesCollection.GetGroups("AllGroups");
                _loaded = true;
            }
            else
            {
                var md = new MessageDialog(e.Message, "Error");
                bool? result = null;
                md.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler((cmd) => result = true)));
                await md.ShowAsync();
            }
        }

    }
}