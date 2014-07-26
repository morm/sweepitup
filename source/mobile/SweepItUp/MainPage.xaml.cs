using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SweepItUp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /*
          request.getParameter("nick"),
           request.getParameter("date"),
           request.getParameter("glass"),
           request.getParameter("plastmass"),
           request.getParameter("paper"),
           request.getParameter("metall"),
           request.getParameter("stones"),
           request.getParameter("sorted"),
           request.getParameter("longitude"),
           request.getParameter("latitude"),
           request.getParameter("email")
         */
        private bool glass = false;
        private bool glassClicked = false;
        private bool paper = false;
        private bool paperClicked = false;
        private bool plastmass = false;
        private bool plastmassClicked = false;
        private bool sizeFilled = false;
        private string email = String.Empty;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btnPaper_Click(object sender, RoutedEventArgs e)
        {
            if (!paperClicked)
            {
                btnPaper.Background = new SolidColorBrush(Colors.Green);
                paperClicked = true;
                paper = true;
            }
            else
            {
                btnPaper.Background = new SolidColorBrush(Colors.Black);
                paperClicked = false;
                paper = false;
            }
        }

        private void btnGlass_Click(object sender, RoutedEventArgs e)
        {
            if (!glassClicked)
            {
                btnGlass.Background = new SolidColorBrush(Colors.Green);
                glassClicked = true;
                glass = true;
            }
            else
            {
                btnGlass.Background = new SolidColorBrush(Colors.Black);
                glassClicked = false;
                glass = false;
            }
        }

        private void btnPlactic_Click(object sender, RoutedEventArgs e)
        {    
            if (!plastmassClicked)
            {
                btnPlactic.Background = new SolidColorBrush(Colors.Green);
                plastmassClicked = true;
                plastmass = true;
            }
            else
            {
                btnPlactic.Background = new SolidColorBrush(Colors.Black);
                plastmassClicked = false;
                plastmass = false;
            }
        }

        private void btnGarbageLow_Click(object sender, RoutedEventArgs e)
        {
            sizeFilled = true;
            btnGarbageMiddle.Background = new SolidColorBrush(Colors.Black);
            btnGarbageFull.Background = new SolidColorBrush(Colors.Black);
            btnGarbageLow.Background = new SolidColorBrush(Colors.Green);
        }

        private void btnGarbageMiddle_Click(object sender, RoutedEventArgs e)
        {
            sizeFilled = true;
            btnGarbageLow.Background = new SolidColorBrush(Colors.Black);
            btnGarbageFull.Background = new SolidColorBrush(Colors.Black);
            btnGarbageMiddle.Background = new SolidColorBrush(Colors.Green);
        }

        private void btnGarbageFull_Click(object sender, RoutedEventArgs e)
        {
            sizeFilled = true;
            btnGarbageLow.Background = new SolidColorBrush(Colors.Black);
            btnGarbageMiddle.Background = new SolidColorBrush(Colors.Black);
            btnGarbageFull.Background = new SolidColorBrush(Colors.Green);
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var dialogNoType = new MessageDialog("Введите тип вторичного сырья", "Ошибка");
            dialogNoType.Commands.Add(new UICommand("OK"));
            if (!paper && !glass && !plastmass) { await dialogNoType.ShowAsync(); return; }

            var dialogNoSize = new MessageDialog("Введите количество вторичного сырья", "Ошибка");
            dialogNoSize.Commands.Add(new UICommand("OK"));
            if (!sizeFilled) { await dialogNoSize.ShowAsync(); return; }

            var dialogSuccsess = new MessageDialog("Данные успешно отправлены", "Спасибо");
            dialogSuccsess.Commands.Add(new UICommand("OK"));
            await dialogSuccsess.ShowAsync();

            InitData();
        }

        private void InitData()
        {
            btnGarbageLow.Background = new SolidColorBrush(Colors.Black);
            btnGarbageMiddle.Background = new SolidColorBrush(Colors.Black);
            btnGarbageFull.Background = new SolidColorBrush(Colors.Black);
            btnPaper.Background = new SolidColorBrush(Colors.Black);
            btnGlass.Background = new SolidColorBrush(Colors.Black);
            btnPlactic.Background = new SolidColorBrush(Colors.Black);
            cbxName.IsChecked = false;
            userName.Text = string.Empty;
            glass = false;
            glassClicked = false;
            paper = false;
            paperClicked = false;
            plastmass = false;
            plastmassClicked = false;
            sizeFilled = false;
        }
    }
}
