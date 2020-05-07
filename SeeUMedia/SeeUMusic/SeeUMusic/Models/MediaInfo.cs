using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SeeUMedia.Models
{
    public class MediaInfo: INotifyPropertyChanged
    {
        private string _DisplayName;
        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                if (_DisplayName != value)
                {
                    _DisplayName = value;
                    OnPropertyChanged();
                }
            }
        }
        public MediaSource Source { get; set; }

        private string _Artist;
        /// <summary>
        /// Artist
        /// </summary>
        public string Artist
        {
            get
            {
                return _Artist;
            }
            set
            {
                if (_Artist != value)
                {
                    _Artist = value;
                    OnPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
