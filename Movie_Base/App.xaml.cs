using System;
using System.Linq;
using Movie_Base.Common;
using Movie_Base.View;
using TCD.Controls;
using TCD.Controls.Settings;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Movie_Base.Pages;

namespace Movie_Base
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();          
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                if (!rootFrame.Navigate(typeof(GroupedItemsPage), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            Window.Current.Activate();

            this.InitSettings();
        }

        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        private void InitSettings()
        {
            SettingsEntry privacyEntry = new SettingsEntry("Privacy", new PrivacyPanelPage(), FlyoutDimension.Narrow);

            SettingsContractWrapper privacyWrapper = new SettingsContractWrapper(
                (Brush)App.Current.Resources["ApplicationForegroundThemeBrush"],
                (Brush)App.Current.Resources["ApplicationPageBackgroundThemeBrush"],
                (Brush)App.Current.Resources["ApplicationPageBackgroundThemeBrush"],
                new BitmapImage(new Uri("ms-appx:/Assets/30x30.png")),
                privacyEntry);
        }
    }
}

