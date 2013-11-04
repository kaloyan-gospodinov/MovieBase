using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Movie_Base.Common
{
    public abstract class SharePage : Movie_Base.Common.LayoutAwarePage
    {
        private DataTransferManager dataTransferManager;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.dataTransferManager = DataTransferManager.GetForCurrentView();
            this.dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.OnDataRequested);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
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

        protected void ShowUIButton_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        protected abstract bool GetShareContent(DataRequest request);
    }
}
