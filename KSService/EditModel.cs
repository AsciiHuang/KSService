using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KSService
{
    public class EditModel : INotifyPropertyChanged
    {
        private Constants.MediaLayoutPosition currentMediaLayoutPosition = Constants.MediaLayoutPosition.None;
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

        private Marquee MarqueeItem = new Marquee();

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
            if (Constants.MediaLayoutPosition.None != currentMediaLayoutPosition)
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

        public void DeleteCurrentIndex()
        {
            if (currentIndex != -1)
            {
                List<MediaData> currentItems = getCurrentItems();
                if (currentIndex != -1 && currentItems != null && currentItems.Count > currentIndex)
                {
                    currentItems.RemoveAt(currentIndex);
                    itemsSource.RemoveAt(currentIndex);
                    NotifyPropertyChanged("ItemsSource");
                }
            }
        }

        public MediaData GetCurrentMediaData()
        {
            MediaData data = null;

            List<MediaData> datas = getCurrentItems();
            if (currentIndex != -1 && datas != null && datas.Count > currentIndex)
            {
                data = datas[currentIndex];
            }

            return data;
        }

        public void UpdateCurrentIndex(int index)
        {
            currentIndex = index;
        }

        public void UpdateMediaType(Constants.MediaType type)
        {
            if (currentIndex != -1)
            {
                List<MediaData> currentItems = getCurrentItems();
                if (currentIndex != -1 && currentItems != null && currentItems.Count > currentIndex)
                {
                    currentItems[currentIndex].Type = type;
                }
            }
        }

        public void UpdateMediaPath(String path, String internalPath)
        {
            if (currentIndex != -1)
            {
                List<MediaData> currentItems = getCurrentItems();
                if (currentIndex != -1 && currentItems != null && currentItems.Count > currentIndex)
                {
                    itemsSource[currentIndex].Path = path;
                    currentItems[currentIndex].Path = path;
                    currentItems[currentIndex].InternalPath = internalPath;
                    NotifyPropertyChanged("ItemsSource");
                }
            }
        }

        public void UpdateMediaDuration(Constants.MediaDuration duration)
        {
            if (currentIndex != -1)
            {
                List<MediaData> currentItems = getCurrentItems();
                if (currentIndex != -1 && currentItems != null && currentItems.Count > currentIndex)
                {
                    currentItems[currentIndex].Duration = duration;
                }
            }
        }

        public void UpdateMediaRepeat(Constants.MediaRepeat repeat)
        {
            if (currentIndex != -1)
            {
                List<MediaData> currentItems = getCurrentItems();
                if (currentIndex != -1 && currentItems != null && currentItems.Count > currentIndex)
                {
                    currentItems[currentIndex].Repeat = repeat;
                }
            }
        }

        public void UpdateMarequeeData(String content)
        {
            MarqueeItem.Content = content;
        }

        public void UpdateMarequeeTextColor(String color)
        {
            MarqueeItem.FontColor = color;
        }

        public void UpdateMarequeeBackgroundColor(String color)
        {
            MarqueeItem.Background = color;
        }

        public JObject GetJSONObject(Constants.LayoutType type)
        {
            JObject resObj = new JObject();

            resObj.Add("Type", type.ToString());

            JArray tlArray = getMediaDataJSONArray(tLItems);
            JArray tcArray = getMediaDataJSONArray(tCItems);
            JArray trArray = getMediaDataJSONArray(tRItems);
            JArray clArray = getMediaDataJSONArray(cLItems);
            JArray ccArray = getMediaDataJSONArray(cCItems);
            JArray crArray = getMediaDataJSONArray(cRItems);
            JArray blArray = getMediaDataJSONArray(bLItems);
            JArray bcArray = getMediaDataJSONArray(bCItems);
            JArray brArray = getMediaDataJSONArray(bRItems);

            resObj.Add("TL", tlArray);
            resObj.Add("TC", tcArray);
            resObj.Add("TR", trArray);
            resObj.Add("CL", clArray);
            resObj.Add("CC", ccArray);
            resObj.Add("CR", crArray);
            resObj.Add("BL", blArray);
            resObj.Add("BC", bcArray);
            resObj.Add("BR", brArray);

            JObject mtObj = new JObject();
            mtObj.Add("Text", MarqueeItem.Content);
            mtObj.Add("Background", MarqueeItem.Background);
            mtObj.Add("FontColor", MarqueeItem.FontColor);

            resObj.Add("Marquee", mtObj);

            return resObj;
        }

        private JArray getMediaDataJSONArray(List<MediaData> datas)
        {
            JArray resArray = new JArray();

            foreach (MediaData data in datas)
            {
                JObject dataObj = new JObject();
                dataObj.Add("Type", data.Type.ToString());
                String pathValue = "";
                if (data.Type == Constants.MediaType.None)
                {
                    pathValue = String.Empty;
                }
                else if (String.IsNullOrEmpty(data.InternalPath))
                {
                    pathValue = String.Empty;
                }
                else
                {
                    pathValue = data.Path.ToString();
                }
                dataObj.Add("Path", pathValue);
                dataObj.Add("InternalPath", data.InternalPath.ToString());
                dataObj.Add("Duration", data.Duration.ToString());
                dataObj.Add("Repeat", data.Repeat.ToString());
                resArray.Add(dataObj);
            }

            return resArray;
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
