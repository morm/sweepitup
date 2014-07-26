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
           request.getParameter("plastic"),
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
        private bool glassLow = false;
        private bool glassMiddle = false;
        private bool glassHigh = false;
        private bool paper = false;
        private bool paperClicked = false;
        private bool paperLow = false;
        private bool paperMiddle = false;
        private bool paperHigh = false;
        private bool plastic = false;
        private bool plasticClicked = false;
        private bool plasticLow = false;
        private bool plasticMiddle = false;
        private bool plasticHigh = false;
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
            if (!plasticClicked)
            {
                btnPlactic.Background = new SolidColorBrush(Colors.Green);
                plasticClicked = true;
                plastic = true;
            }
            else
            {
                btnPlactic.Background = new SolidColorBrush(Colors.Black);
                plasticClicked = false;
                plastic = false;
            }
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var dialogNoType = new MessageDialog("Введите тип вторичного сырья", "Ошибка");
            dialogNoType.Commands.Add(new UICommand("OK"));
            if ((!paper && !glass && !plastic) ||
                (!paper && (paperLow || paperMiddle || paperHigh)) ||
                (!glass && (glassLow || glassMiddle || glassHigh)) ||
                (!plastic && (plasticLow || plasticMiddle || plasticHigh))) { await dialogNoType.ShowAsync(); return; }

            var dialogNoSize = new MessageDialog("Введите количество вторичного сырья", "Ошибка");
            dialogNoSize.Commands.Add(new UICommand("OK"));
            if ((glassClicked && !glassLow && !glassMiddle && !glassHigh) || 
               (paperClicked && !paperLow && !paperMiddle && !paperHigh) ||
               (plasticClicked && !plasticLow && !plasticMiddle && !plasticHigh)) { await dialogNoSize.ShowAsync(); return; }

            var dialogSuccsess = new MessageDialog("Данные успешно отправлены", "Спасибо");
            dialogSuccsess.Commands.Add(new UICommand("OK"));
            await dialogSuccsess.ShowAsync();

            InitData();
        }

        private void InitData()
        {
            btnPaper.Background = new SolidColorBrush(Colors.Black);
            btnPaperLow.Background = new SolidColorBrush(Colors.Black);
            btnPaperMiddle.Background = new SolidColorBrush(Colors.Black);
            btnPaperMiddle.Foreground = new SolidColorBrush(Colors.White);
            btnPaperHigh.Background = new SolidColorBrush(Colors.Black);
            btnGlass.Background = new SolidColorBrush(Colors.Black);
            btnGlassLow.Background = new SolidColorBrush(Colors.Black);
            btnGlassMiddle.Background = new SolidColorBrush(Colors.Black);
            btnGlassMiddle.Foreground = new SolidColorBrush(Colors.White);
            btnGlassHigh.Background = new SolidColorBrush(Colors.Black);
            btnPlactic.Background = new SolidColorBrush(Colors.Black);
            btnPlasticLow.Background = new SolidColorBrush(Colors.Black);
            btnPlasticMiddle.Background = new SolidColorBrush(Colors.Black);
            btnPlasticMiddle.Foreground = new SolidColorBrush(Colors.White);
            btnPlasticHigh.Background = new SolidColorBrush(Colors.Black);
            cbxName.IsChecked = false;
            userName.Text = string.Empty;
            glass = false;
            glassClicked = false;
            glassLow = false;
            glassMiddle = false;
            glassHigh = false;
            paper = false;
            paperClicked = false;
            paperLow = false;
            paperMiddle = false;
            paperHigh = false;
            plastic = false;
            plasticClicked = false;
            plasticLow = false;
            plasticMiddle = false;
            plasticHigh = false;
        }

        private void btnPaperLow_Click(object sender, RoutedEventArgs e)
        {
            if (!paperLow) { btnPaperLow.Background = new SolidColorBrush(Colors.Green); paperLow = true; paperMiddle = false; paperHigh = false; }
            else { btnPaperLow.Background = new SolidColorBrush(Colors.Black); paperLow = false; paperMiddle = false; paperHigh = false; }
            btnPaperMiddle.Background = new SolidColorBrush(Colors.Black);
            btnPaperMiddle.Foreground = new SolidColorBrush(Colors.White);
            btnPaperHigh.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnPaperMiddle_Click(object sender, RoutedEventArgs e)
        {
            btnPaperLow.Background = new SolidColorBrush(Colors.Black);
            if (!paperMiddle)
            {
                btnPaperMiddle.Background = new SolidColorBrush(Colors.Yellow);
                btnPaperMiddle.Foreground = new SolidColorBrush(Colors.Black);
                paperMiddle = true;
                paperLow = false;
                paperHigh = false;
            }
            else
            {
                btnPaperMiddle.Background = new SolidColorBrush(Colors.Black);
                btnPaperMiddle.Foreground = new SolidColorBrush(Colors.White);
                paperMiddle = false;
                paperLow = false;
                paperHigh = false;
            }
            btnPaperHigh.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnPaperHigh_Click(object sender, RoutedEventArgs e)
        {
            btnPaperLow.Background = new SolidColorBrush(Colors.Black);
            btnPaperMiddle.Background = new SolidColorBrush(Colors.Black);
            btnPaperMiddle.Foreground = new SolidColorBrush(Colors.White);
            if (!paperHigh) { btnPaperHigh.Background = new SolidColorBrush(Colors.Red); paperHigh = true; paperLow = false; paperMiddle = false; }
            else { btnPaperHigh.Background = new SolidColorBrush(Colors.Black); paperHigh = false; paperLow = false; paperMiddle = false; }
        }

        private void btnGlassLow_Click(object sender, RoutedEventArgs e)
        {
            if (!glassLow) { btnGlassLow.Background = new SolidColorBrush(Colors.Green); glassLow = true; glassMiddle = false; glassHigh = false; }
            else { btnGlassLow.Background = new SolidColorBrush(Colors.Black); glassLow = false; glassMiddle = false; glassHigh = false; }
            btnGlassMiddle.Background = new SolidColorBrush(Colors.Black);
            btnGlassMiddle.Foreground = new SolidColorBrush(Colors.White);
            btnGlassHigh.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnGlassMiddle_Click(object sender, RoutedEventArgs e)
        {
            btnGlassLow.Background = new SolidColorBrush(Colors.Black);
            if (!glassMiddle)
            {
                btnGlassMiddle.Background = new SolidColorBrush(Colors.Yellow);
                btnGlassMiddle.Foreground = new SolidColorBrush(Colors.Black);
                glassMiddle = true;
                glassLow = false;
                glassHigh = false;
            }
            else
            {
                btnGlassMiddle.Background = new SolidColorBrush(Colors.Black);
                btnGlassMiddle.Foreground = new SolidColorBrush(Colors.White);
                glassMiddle = false;
                glassLow = false;
                glassHigh = false;
            }
            btnGlassHigh.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnGlassHigh_Click(object sender, RoutedEventArgs e)
        {
            btnGlassLow.Background = new SolidColorBrush(Colors.Black);
            btnGlassMiddle.Background = new SolidColorBrush(Colors.Black);
            btnGlassMiddle.Foreground = new SolidColorBrush(Colors.White);
            if (!glassHigh) { btnGlassHigh.Background = new SolidColorBrush(Colors.Red); glassHigh = true; glassMiddle = false; glassLow = false; }
            else { btnGlassHigh.Background = new SolidColorBrush(Colors.Black); glassHigh = false; glassMiddle = false; glassLow = false; }
        }

        private void btnPlasticLow_Click(object sender, RoutedEventArgs e)
        {
            if (!plasticLow) { btnPlasticLow.Background = new SolidColorBrush(Colors.Green); plasticLow = true; plasticMiddle = false; plasticHigh = false; }
            else { btnPlasticLow.Background = new SolidColorBrush(Colors.Black); plasticLow = false; plasticMiddle = false; plasticHigh = false; }
            btnPlasticMiddle.Background = new SolidColorBrush(Colors.Black);
            btnPlasticMiddle.Foreground = new SolidColorBrush(Colors.White);
            btnPlasticHigh.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnPlasticMiddle_Click(object sender, RoutedEventArgs e)
        {
            btnPlasticLow.Background = new SolidColorBrush(Colors.Black);
            if (!plasticMiddle)
            {
                btnPlasticMiddle.Background = new SolidColorBrush(Colors.Yellow);
                btnPlasticMiddle.Foreground = new SolidColorBrush(Colors.Black);
                plasticMiddle = true;
                plasticLow = false;
                plasticHigh = false;
            }
            else
            {
                btnPlasticMiddle.Background = new SolidColorBrush(Colors.Black);
                btnPlasticMiddle.Foreground = new SolidColorBrush(Colors.White);
                plasticMiddle = false;
                plasticLow = false;
                plasticHigh = false;
            }
            btnPlasticHigh.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnPlasticHigh_Click(object sender, RoutedEventArgs e)
        {
            btnPlasticLow.Background = new SolidColorBrush(Colors.Black);
            btnPlasticMiddle.Background = new SolidColorBrush(Colors.Black);
            btnPlasticMiddle.Foreground = new SolidColorBrush(Colors.White);
            if (!plasticHigh) { btnPlasticHigh.Background = new SolidColorBrush(Colors.Red); plasticHigh = true; plasticMiddle = false; plasticLow = false; }
            else { btnPlasticHigh.Background = new SolidColorBrush(Colors.Black); plasticHigh = false; plasticMiddle = false; plasticLow = false; }
        }
    }
}
