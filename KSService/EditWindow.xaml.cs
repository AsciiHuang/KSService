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
using System.Windows.Shapes;

namespace KSService
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Constants.LayoutType type = Constants.LayoutType.Landscape_Full;

        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(Constants.LayoutType type)
        {
            this.type = type;
            InitializeComponent();
        }

        private void OnWindowsClosed(object sender, EventArgs e)
        {

        }
    }
}
