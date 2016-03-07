using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSService
{
    public class EditModel : INotifyPropertyChanged
    {
        private ObservableCollection<String> itemsSource = new ObservableCollection<String>();
        public ObservableCollection<String> ItemsSource
        {
            get
            {
                return itemsSource;
            }
            set
            {
                itemsSource = value;
                NotifyPropertyChanged("ItemsSource");
            }
        }

        public EditModel()
        {
        }

        public void AddMediaData()
        {
            itemsSource.Add("點選編輯新的 圖片 或 影片參數");
            NotifyPropertyChanged("ItemsSource");
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
