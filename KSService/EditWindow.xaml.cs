using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace KSService
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Constants.LayoutType type = Constants.LayoutType.Landscape_Full;

        private EditModel model = null;
        public EditModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new EditModel();
                }
                return model;
            }
        }

        public EditWindow()
        {
            InitializeComponent();
            this.DataContext = Model;
        }

        public EditWindow(Constants.LayoutType type)
        {
            this.type = type;
            InitializeComponent();
            this.DataContext = Model;
        }

        private void OnWindowsClosed(object sender, EventArgs e)
        {

        }

        private void OnAddButtonClicked(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.DefaultExt = ".png";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            //Nullable<bool> result = dlg.ShowDialog();
            //if (result == true)
            //{
            //    string filename = dlg.FileName;
            //    textBox1.Text = filename;
            //}
            model.AddMediaData();
        }

        private void OnDeleteButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnSaveButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnMediaDataItemSelected(object sender, SelectionChangedEventArgs e)
        {
            combo_type.SelectedIndex = 0;
            combo_duration.SelectedIndex = 0;
            combo_repeat.SelectedIndex = 0;
        }

        #region Button Click Handler
        private void OnTLButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.TL);
        }

        private void OnTCButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.TC);
        }

        private void OnTRButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.TR);
        }

        private void OnCLButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.CL);
        }

        private void OnCCButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.CC);
        }
        
        private void OnCRButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.CR);
        }

        private void OnBLButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.BL);
        }

        private void OnBCButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.BC);
        }

        private void OnBRButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition.BR);
        }
        #endregion
    }
}
