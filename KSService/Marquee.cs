using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KSService
{
    public class Marquee : INotifyPropertyChanged
    {

        private String text = "";
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                NotifyPropertyChanged("Text");
            }
        }

        private Color background = Colors.White;
        public Color Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                NotifyPropertyChanged("Background");
            }
        }

        private Color fontColor = Colors.White;
        public Color FontColor
        {
            get
            {
                return fontColor;
            }
            set
            {
                fontColor = value;
                NotifyPropertyChanged("FontColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
