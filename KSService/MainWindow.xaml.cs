using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KSService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OnLandscapeItemSelected(object sender, MouseButtonEventArgs e)
        {
            int index = ((ListView)sender).SelectedIndex;
            if (index == 0)
            {
                new EditWindow(Constants.LayoutType.Landscape_Full).Show();
            }
            else if (index == 1)
            {
                new EditWindow(Constants.LayoutType.Landscape_L1_R21).Show();
            }
            else if (index == 2)
            {
                new EditWindow(Constants.LayoutType.Landscape_L1_R111).Show();
            }
            else if (index == 3)
            {
                new EditWindow(Constants.LayoutType.Landscape_Full_BottomMarquee).Show();
            }
            else if (index == 4)
            {
                new EditWindow(Constants.LayoutType.Landscape_BottomMarquee_L1_R11).Show();
            }
            else if (index == 5)
            {
                new EditWindow(Constants.LayoutType.Landscape_BottomMarquee_L1_R21).Show();
            }
            else if (index == 6)
            {
                new EditWindow(Constants.LayoutType.Landscape_L1_C1_R1).Show();
            }
            else if (index == 7)
            {
                new EditWindow(Constants.LayoutType.Landscape_BottomMarquee_L1_C1_R1).Show();
            }
            this.Close();
        }

        public void OnPortraitItemSelected(object sender, RoutedEventArgs e)
        {
            int index = ((ListView)sender).SelectedIndex;
            if (index == 0)
            {
                new EditWindow(Constants.LayoutType.Portrait_Full).Show();
            }
            else if (index == 1)
            {
                new EditWindow(Constants.LayoutType.Portrait_Full_TopMarquee).Show();
            }
            else if (index == 2)
            {
                new EditWindow(Constants.LayoutType.Portrait_CenterMarquee_T1_B3).Show();
            }
            else if (index == 3)
            {
                new EditWindow(Constants.LayoutType.Portrait_T1_C1_B1).Show();
            }
            else if (index == 4)
            {
                new EditWindow(Constants.LayoutType.Portrait_T1_C1_CL1_CR1_B1).Show();
            }
            this.Close();
        }
    }
}
