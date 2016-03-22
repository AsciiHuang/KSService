using Newtonsoft.Json.Linq;
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
            ChooseLayout();
            this.DataContext = Model;
        }

        private void OnBackButtonClicked(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void ChooseLayout()
        {
            Landscape_Full.Visibility = System.Windows.Visibility.Hidden;
            Landscape_L1_R21.Visibility = System.Windows.Visibility.Hidden;
            Landscape_L1_R111.Visibility = System.Windows.Visibility.Hidden;
            Landscape_Full_BottomMarquee.Visibility = System.Windows.Visibility.Hidden;
            Landscape_BottomMarquee_L1_R11.Visibility = System.Windows.Visibility.Hidden;
            Landscape_BottomMarquee_L1_R21.Visibility = System.Windows.Visibility.Hidden;
            Landscape_L1_C1_R1.Visibility = System.Windows.Visibility.Hidden;
            Landscape_BottomMarquee_L1_C1_R1.Visibility = System.Windows.Visibility.Hidden;
            Portrait_Full.Visibility = System.Windows.Visibility.Hidden;
            Portrait_Full_TopMarquee.Visibility = System.Windows.Visibility.Hidden;
            Portrait_CenterMarquee_T1_B3.Visibility = System.Windows.Visibility.Hidden;
            Portrait_T1_C1_B1.Visibility = System.Windows.Visibility.Hidden;
            Portrait_T1_C1_CL1_CR1_B1.Visibility = System.Windows.Visibility.Hidden;
            if (type == Constants.LayoutType.Landscape_Full)
            {
                Landscape_Full.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_L1_R21)
            {
                Landscape_L1_R21.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_L1_R111)
            {
                Landscape_L1_R111.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_Full_BottomMarquee)
            {
                Landscape_Full_BottomMarquee.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_BottomMarquee_L1_R11)
            {
                Landscape_BottomMarquee_L1_R11.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_BottomMarquee_L1_R21)
            {
                Landscape_BottomMarquee_L1_R21.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_L1_C1_R1)
            {
                Landscape_L1_C1_R1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Landscape_BottomMarquee_L1_C1_R1)
            {
                Landscape_BottomMarquee_L1_C1_R1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Portrait_Full)
            {
                Portrait_Full.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Portrait_Full_TopMarquee)
            {
                Portrait_Full_TopMarquee.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Portrait_CenterMarquee_T1_B3)
            {
                Portrait_CenterMarquee_T1_B3.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Portrait_T1_C1_B1)
            {
                Portrait_T1_C1_B1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == Constants.LayoutType.Portrait_T1_C1_CL1_CR1_B1)
            {
                Portrait_T1_C1_CL1_CR1_B1.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void OnMediaTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Constants.MediaType type = Constants.MediaType.None;
            int index = ((ComboBox)sender).SelectedIndex;
            if (index != -1)
            {

                if (index == 0)
                {
                    type = Constants.MediaType.Photo;
                }
                else if (index == 1)
                {
                    type = Constants.MediaType.Video;
                }

                if (type != Constants.MediaType.None)
                {
                    model.UpdateMediaType(type);
                }
            }
        }

        private void OnChooseFileClicked(object sender, RoutedEventArgs e)
        {
            int typeIndex = combo_type.SelectedIndex;
            if (typeIndex == 0)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".jpg";
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    model.UpdateMediaPath(dlg.SafeFileName, dlg.FileName);
                }
            }
            else if (typeIndex == 1)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".mp4";
                dlg.Filter = "MP4 Files (*.mp4)|*.mp4|AVI Files (*.avi)|*.avi|WMV Files (*.wmv)|*.wmv|MPEG Files (*.mpeg)|*.mpeg|MPG Files (*.mpg)|*.mpg";
                Nullable<bool> result = dlg.ShowDialog();
                if (true == result)
                {
                    model.UpdateMediaPath(dlg.SafeFileName, dlg.FileName);
                }
            }
        }

        private void OnMediaDurationComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            Constants.MediaDuration duration = Constants.MediaDuration.None;
            switch (index)
            {
                case 0:
                    duration = Constants.MediaDuration.Second5;
                    break;
                case 1:
                    duration = Constants.MediaDuration.Second10;
                    break;
                case 2:
                    duration = Constants.MediaDuration.Second15;
                    break;
                case 3:
                    duration = Constants.MediaDuration.Second20;
                    break;
                case 4:
                    duration = Constants.MediaDuration.Second25;
                    break;
                case 5:
                    duration = Constants.MediaDuration.Second30;
                    break;
                case 6:
                    duration = Constants.MediaDuration.Second35;
                    break;
                case 7:
                    duration = Constants.MediaDuration.Second40;
                    break;
                case 8:
                    duration = Constants.MediaDuration.Second45;
                    break;
                case 9:
                    duration = Constants.MediaDuration.Second50;
                    break;
                case 10:
                    duration = Constants.MediaDuration.Second55;
                    break;
                case 11:
                    duration = Constants.MediaDuration.Second60;
                    break;
                case 12:
                    duration = Constants.MediaDuration.Unlimited;
                    break;
            }
            if (duration != Constants.MediaDuration.None)
            {
                model.UpdateMediaDuration(duration);
            }
        }

        private void OnTextColorComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            String colorString = "";
            switch (index)
            {
                case 0:
                    colorString = "#FFFFFF";
                    break;
                case 1:
                    colorString = "#000000";
                    break;
            }
            if (!String.IsNullOrEmpty(colorString))
            {
                model.UpdateMarequeeTextColor(colorString);
            }
        }

        public void OnTextBackgroundColorComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            String colorString = "";
            switch (index)
            {
                case 0:
                    colorString = "#F61A00";
                    break;
                case 1:
                    colorString = "#0087E4";
                    break;
                case 2:
                    colorString = "#FF9D01";
                    break;
                case 3:
                    colorString = "#000000";
                    break;
                case 4:
                    colorString = "#009600";
                    break;
                case 5:
                    colorString = "#6C00AB";
                    break;
                case 6:
                    colorString = "#FFE301";
                    break;
            }
            if (!String.IsNullOrEmpty(colorString))
            {
                model.UpdateMarequeeBackgroundColor(colorString);
            }
        }

        private void OnAddButtonClicked(object sender, RoutedEventArgs e)
        {
            model.AddMediaData();
        }

        private void OnDeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            model.DeleteCurrentIndex();
        }

        private void OnSaveButtonClicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".ksd";
            dlg.CreatePrompt = true;
            dlg.FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            Nullable<bool> result = dlg.ShowDialog();
            if (true == result)
            {
                JObject obj = model.GetJSONObject(type);
                String objValue = obj.ToString();
                RC4 rc4Obj = new RC4("a555ab555bc555cd555d");
                System.IO.FileStream fs = (System.IO.FileStream) dlg.OpenFile();
                byte[] data = getBytes(objValue);
                rc4Obj.EncryptInPlace(data);
                byte[] encData = getBytes(Convert.ToBase64String(data));
                fs.Write(encData, 0, encData.Length);
                fs.Close();
            }
        }

        private void OnMediaDataItemSelected(object sender, SelectionChangedEventArgs e)
        {
            model.UpdateCurrentIndex(((ListView)sender).SelectedIndex);
            updateComboBoxStatus();
        }

        private void updateComboBoxStatus()
        {
            combo_type.SelectedIndex = -1;
            combo_duration.SelectedIndex = -1;

            MediaData data = model.GetCurrentMediaData();
            if (data != null)
            {
                #region Type
                if (data.Type == Constants.MediaType.Photo)
                {
                    combo_type.SelectedIndex = 0;
                }
                else if (data.Type == Constants.MediaType.Video)
                {
                    combo_type.SelectedIndex = 1;
                }
                #endregion

                #region Duration
                if (data.Duration == Constants.MediaDuration.Second5)
                {
                    combo_duration.SelectedIndex = 0;
                }
                else if (data.Duration == Constants.MediaDuration.Second10)
                {
                    combo_duration.SelectedIndex = 1;
                }
                else if (data.Duration == Constants.MediaDuration.Second15)
                {
                    combo_duration.SelectedIndex = 2;
                }
                else if (data.Duration == Constants.MediaDuration.Second20)
                {
                    combo_duration.SelectedIndex = 3;
                }
                else if (data.Duration == Constants.MediaDuration.Second25)
                {
                    combo_duration.SelectedIndex = 4;
                }
                else if (data.Duration == Constants.MediaDuration.Second30)
                {
                    combo_duration.SelectedIndex = 5;
                }
                else if (data.Duration == Constants.MediaDuration.Second35)
                {
                    combo_duration.SelectedIndex = 6;
                }
                else if (data.Duration == Constants.MediaDuration.Second40)
                {
                    combo_duration.SelectedIndex = 7;
                }
                else if (data.Duration == Constants.MediaDuration.Second45)
                {
                    combo_duration.SelectedIndex = 8;
                }
                else if (data.Duration == Constants.MediaDuration.Second50)
                {
                    combo_duration.SelectedIndex = 9;
                }
                else if (data.Duration == Constants.MediaDuration.Second55)
                {
                    combo_duration.SelectedIndex = 10;
                }
                else if (data.Duration == Constants.MediaDuration.Second60)
                {
                    combo_duration.SelectedIndex = 11;
                }
                else if (data.Duration == Constants.MediaDuration.Unlimited)
                {
                    combo_duration.SelectedIndex = 12;
                }
                #endregion
            }
        }

        private byte[] getBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private String getString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        #region Media Layout Position Click Handler
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

        private void OnMarqueeTextChanged(object sender, TextChangedEventArgs e)
        {
            model.UpdateMarequeeData(((TextBox)sender).Text);
        }
        #endregion
    }
}
