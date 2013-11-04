using System;
using System.Collections.Generic;
using System.Linq;
using Movie_Base.Common;
using Movie_Base.Model;
using Movie_Base.Services;
using Movie_Base.ViewModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.Storage.Pickers;
using Windows.Storage;
using Movie_Base.Pages;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using Windows.Foundation;

namespace Movie_Base.View
{
    public sealed partial class ItemDetailPage : LayoutAwarePage
    {
        private readonly InvokeApi apiInvokePreview;
        private readonly InvokeApi apiInvokeReviews;

        public static ItemDetailPage Current;

        public ItemDetailPage()
        {
            this.InitializeComponent();

            apiInvokeReviews = new InvokeApi();

            apiInvokeReviews.OnResponse += apiInvokeReviews_OnResponse;
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            if (pageState != null && pageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = pageState["SelectedItem"];
            }

            var mi = RottenTomatoesCollection.GetItem((string)navigationParameter);
            this.DefaultViewModel["Item"] = mi;
        }

        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            var mi = (MovieItem)this.DefaultViewModel["Item"];
            pageState["SelectedItem"] = mi.UniqueId;
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            var mi = (MovieItem)this.DefaultViewModel["Item"];
            var apiCall = mi.Reviews + "?" + Globals.ROTTEN_TOMATOES_API_KEY;
            apiInvokeReviews.Invoke<MovieReviews>(apiCall);
        }

        async void apiInvokeReviews_OnResponse(object sender, Event e)
        {
            var cc = (ReviewControl)ReviewPopup.Child;
            var response = (MovieReviews)e.Object;

            if ((e.Status == Status.SUCCESS) && (response.Reviews.Length > 0))
            {
                var mg = new MovieReviewGroup();
                mg.Copy(response);
                cc.MovieReviews = mg;
                cc.Initialize();
                ReviewPopup.IsOpen = true;
            }
            else
            {
                if (response.Reviews.Length <= 0)
                    e.Message = "There are no previews";
                var md = new MessageDialog(e.Message, "Error");
                bool? result = null;
                md.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler((cmd) => result = true)));
                await md.ShowAsync();
            }
        }

        private async void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string text = PageTitle.Text;
            string description = Synopsis.Text;

            FileSavePicker savePicker = new FileSavePicker();

            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            List<string> plainTextFileTypes = new List<string>(new string[] { ".txt" });
            List<string> wordTextFileTypes = new List<string>(new string[] { ".doc" });
            savePicker.FileTypeChoices.Add(new KeyValuePair<string, IList<string>>("Plain Text", plainTextFileTypes));
            savePicker.FileTypeChoices.Add(new KeyValuePair<string, IList<string>>("Word Text", wordTextFileTypes));
            savePicker.SuggestedFileName = text;

            StorageFile saveFile = await savePicker.PickSaveFileAsync();

            if (saveFile != null)
            {
                await Windows.Storage.FileIO.WriteTextAsync(saveFile, description);
                await new Windows.UI.Popups.MessageDialog("File Saved!").ShowAsync();
            }
        }

        public void EditFileButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReadingAndWritingFiles));
        }

        private DataTransferManager dataTransferManager;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.dataTransferManager = DataTransferManager.GetForCurrentView();
            this.dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.OnDataRequested);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.dataTransferManager.DataRequested -= new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.OnDataRequested);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            if (GetShareContent(e.Request))
            {
                if (String.IsNullOrEmpty(e.Request.Data.Properties.Title))
                {
                    e.Request.FailWithDisplayText("Enter a title for what you are sharing and try again.");
                }
            }
        }

        protected bool GetShareContent(DataRequest request)
        {
            bool succeeded = false;

            string dataPackageText = Synopsis.Text;
            if (!String.IsNullOrEmpty(dataPackageText))
            {
                DataPackage requestData = request.Data;
                requestData.Properties.Title = PageTitle.Text;
                requestData.SetText(dataPackageText);
                succeeded = true;
            }
            else
            {
                request.FailWithDisplayText("Enter the text you would like to share and try again.");
            }
            return succeeded;
        }

    }
}
