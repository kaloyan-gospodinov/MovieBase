using Movie_Base.Common;
using Movie_Base.View;
using System;
using System.Linq;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;

namespace Movie_Base.Pages
{
    public sealed partial class ReadingAndWritingFiles : LayoutAwarePage
    {
        ItemDetailPage rootPage = ItemDetailPage.Current;

        public static ReadingAndWritingFiles Current;

        internal FileOpenPickerUI fileOpenPickerUI = null;

        public ReadingAndWritingFiles()
        {
            this.InitializeComponent();
            Current = this;
        }

        Windows.Storage.StorageFile fileToUse = null;

        public async void OpenFileClick(object sender, RoutedEventArgs e)
        {
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();

            filePicker.FileTypeFilter.Add(".txt");
            filePicker.FileTypeFilter.Add(".doc");

            fileToUse = await filePicker.PickSingleFileAsync();

            if (fileToUse != null)
            {
                try
                {
                    var text = await Windows.Storage.FileIO.ReadTextAsync(fileToUse);
                    FileContents.Text = text;
                }
                catch (Exception)
                {
                    new Windows.UI.Popups.MessageDialog("Something went wrong").ShowAsync();
                }
            }
        }

        private async void WriteToFileClick(object sender, RoutedEventArgs e)
        {
            var text = TextInput.Text;

            if (fileToUse != null)
            {
                if (OverwriteCheckBox.IsChecked == true)
                {
                    try
                    {
                        await Windows.Storage.FileIO.WriteTextAsync(fileToUse, text);
                        await new Windows.UI.Popups.MessageDialog("Text successfully written to file").ShowAsync();
                    }
                    catch (Exception)
                    {
                        new Windows.UI.Popups.MessageDialog("Something went wrong").ShowAsync();
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        await Windows.Storage.FileIO.AppendTextAsync(fileToUse, text);
                        await new Windows.UI.Popups.MessageDialog("Text successfully written to file").ShowAsync();
                    }
                    catch (Exception)
                    {
                        new Windows.UI.Popups.MessageDialog("Something went wrong").ShowAsync();
                        throw;
                    }
                }
            }
        }

        protected void GoBack(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
    }
}
