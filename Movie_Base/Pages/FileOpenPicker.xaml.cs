using System;
using System.Linq;
using Movie_Base.Common;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Movie_Base.Pages
{
    public sealed partial class FileOpenPicker : LayoutAwarePage
    {
        private const string id = "MyLocalFile";
        FileOpenPickerUI fileOpenPickerUI = ReadingAndWritingFiles.Current.fileOpenPickerUI;
        CoreDispatcher dispatcher = Window.Current.Dispatcher;

        public FileOpenPicker()
        {
            this.InitializeComponent();
            AddLocalFileButton.Click += new RoutedEventHandler(AddLocalFileButton_Click);
            RemoveLocalFileButton.Click += new RoutedEventHandler(RemoveLocalFileButton_Click);
        }

        private void UpdateButtonState(bool fileInBasket)
        {
            AddLocalFileButton.IsEnabled = !fileInBasket;
            RemoveLocalFileButton.IsEnabled = fileInBasket;
        }

        private async void OnFileRemoved(FileOpenPickerUI sender, FileRemovedEventArgs args)
        {
            if (args.Id == id)
            {
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    await new Windows.UI.Popups.MessageDialog("File removed from the basket.").ShowAsync();
                    UpdateButtonState(false);
                });
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateButtonState(fileOpenPickerUI.ContainsFile(id));
            fileOpenPickerUI.FileRemoved += new TypedEventHandler<FileOpenPickerUI, FileRemovedEventArgs>(OnFileRemoved);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            fileOpenPickerUI.FileRemoved -= new TypedEventHandler<FileOpenPickerUI, FileRemovedEventArgs>(OnFileRemoved);
        }

        private async void AddLocalFileButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\squareTile-sdk.png");
            bool inBasket;
            switch (fileOpenPickerUI.AddFile(id, file))
            {
                case AddFileResult.Added:
                case AddFileResult.AlreadyAdded:
                    inBasket = true;
                    await new Windows.UI.Popups.MessageDialog("File added to the basket.").ShowAsync();
                    break;
                default:
                    inBasket = false;
                    await new Windows.UI.Popups.MessageDialog("Couldn't add file to the basket.").ShowAsync();
                    break;
            }
            UpdateButtonState(inBasket);
        }

        private async void RemoveLocalFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (fileOpenPickerUI.ContainsFile(id))
            {
                fileOpenPickerUI.RemoveFile(id);
                await new Windows.UI.Popups.MessageDialog("File removed from the basket.").ShowAsync();
            }
            UpdateButtonState(false);
        }
    }
}