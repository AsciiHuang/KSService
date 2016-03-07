using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSService
{
    public class MediaData : INotifyPropertyChanged
    {
        public enum DataType
        {
            Photo,
            Video,
        }

        private DataType type = DataType.Photo;
        public DataType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        private String path = "";
        public String Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                NotifyPropertyChanged("Path");
            }
        }

        private Int32 duration = 0;
        public Int32 Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
                NotifyPropertyChanged("Duration");
            }
        }

        private Int32 repeat = 0;
        public Int32 Repeat
        {
            get
            {
                return repeat;
            }
            set
            {
                repeat = value;
                NotifyPropertyChanged("Repeat");
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
