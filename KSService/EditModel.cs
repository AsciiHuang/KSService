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
        private Constants.MediaLayoutPosition currentMediaLayoutPosition = Constants.MediaLayoutPosition.Default;
        private Constants.MarqueeLayoutPosition currentMarqueeLayoutPosition = Constants.MarqueeLayoutPosition.Default;
        private Int32 currentIndex = -1;

        private List<MediaData> tLItems = new List<MediaData>();
        private List<MediaData> tCItems = new List<MediaData>();
        private List<MediaData> tRItems = new List<MediaData>();

        private List<MediaData> cLItems = new List<MediaData>();
        private List<MediaData> cCItems = new List<MediaData>();
        private List<MediaData> cRItems = new List<MediaData>();

        private List<MediaData> bLItems = new List<MediaData>();
        private List<MediaData> bCItems = new List<MediaData>();
        private List<MediaData> bRItems = new List<MediaData>();

        private Marquee mTItem = new Marquee();
        private Marquee mCItem = new Marquee();
        private Marquee mBItem = new Marquee();

        private ObservableCollection<MediaData> itemsSource = new ObservableCollection<MediaData>();
        public ObservableCollection<MediaData> ItemsSource
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
            //itemsSource.Add("點選編輯新的 圖片 或 影片參數");
            //itemsSource.Add(new MediaData());
            List<MediaData> currentItems = getCurrentItems();
            if (currentItems != null)
            {
                currentItems.Add(new MediaData());
                itemsSource.Add(new MediaData());
            }
            NotifyPropertyChanged("ItemsSource");
        }

        public void SwitchToMediaLayoutPosition(Constants.MediaLayoutPosition position)
        {
            currentMediaLayoutPosition = position;
            itemsSource.Clear();
            if (Constants.MediaLayoutPosition.Default != currentMediaLayoutPosition)
            {
                List<MediaData> items = getCurrentItems();
                if (items != null)
                {
                    for (int i = 0; i < items.Count; ++i)
                    {
                        itemsSource.Add(items[i]);
                    }
                }
            }
            NotifyPropertyChanged("ItemsSource");
        }

        public void UpdateMediaType(Constants.MediaType type, String path)
        {
            if (currentIndex != -1)
            {
                List<MediaData> currentItems = getCurrentItems();
                if (currentIndex != null && currentItems.Count > currentIndex)
                {
                    
                }
            }
        }

        public void UpdateMediaDuration(Int32 duration)
        {

        }

        public void UpdateMediaRepeat(Int32 repeat)
        {

        }

        private List<MediaData> getCurrentItems()
        {
            List<MediaData> datas = null;
            switch (currentMediaLayoutPosition)
            {
                case Constants.MediaLayoutPosition.TL:
                    datas = tLItems;
                    break;
                case Constants.MediaLayoutPosition.TC:
                    datas = tCItems;
                    break;
                case Constants.MediaLayoutPosition.TR:
                    datas = tRItems;
                    break;
                case Constants.MediaLayoutPosition.CL:
                    datas = cLItems;
                    break;
                case Constants.MediaLayoutPosition.CC:
                    datas = cCItems;
                    break;
                case Constants.MediaLayoutPosition.CR:
                    datas = cRItems;
                    break;
                case Constants.MediaLayoutPosition.BL:
                    datas = bLItems;
                    break;
                case Constants.MediaLayoutPosition.BC:
                    datas = bCItems;
                    break;
                case Constants.MediaLayoutPosition.BR:
                    datas = bRItems;
                    break;
            }
            return datas;
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
