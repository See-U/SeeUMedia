using SeeUMedia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayWebAudioPage : ContentPage
    {
        readonly ObservableCollection<MediaInfo> mediaInfos = new ObservableCollection<MediaInfo>();
        public PlayWebAudioPage()
        {
            InitializeComponent();
            Initial();
            BindingContext = mediaInfos;
        }

        /// <summary>
        /// mediaelement: https://docs.microsoft.com/zh-cn/xamarin/xamarin-forms/user-interface/mediaelement
        /// </summary>
        public void Initial()
        {
            mediaInfos.Add(new MediaInfo { DisplayName = "盗墓笔记·十年人间-郭聪明" ,Source= "http://mp.111ttt.cn/mp3free/92685853.mp3" });
            mediaInfos.Add(new MediaInfo { DisplayName = "最美的期待-周笔畅", Source= "http://mp.111ttt.cn/mp3free/40079535.mp3" });
            mediaInfos.Add(new MediaInfo { DisplayName = "我们不一样-大壮", Source= "http://mp.111ttt.cn/mp3free/24720751.mp3" });
            mediaInfos.Add(new MediaInfo { DisplayName = "大海-张雨生", Source= "http://mp.111ttt.cn/mp3free/322610.mp3" });
            mediaInfos.Add(new MediaInfo { DisplayName = "带你去旅行-校长（张驰）", Source= "http://mp.111ttt.cn/mp3free/27748502.mp3" });
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MediaInfo;
            this.mediaElement.Source = item.Source;
            this.mediaElement.Play();
            this.mediaElement.IsLooping = true;//循环播放
            this.lb_CurMusic.Text = "当前播放条目:" + item.DisplayName;
        }

        private string _CurMusic;
        /// <summary>
        /// 当前播放条目
        /// </summary>
        public string CurMusic
        {
            get { return _CurMusic; }
            set
            {
                _CurMusic = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MediaInfo> _MediaInfoLst;
        /// <summary>
        /// 音乐列表
        /// </summary>
        public ObservableCollection<MediaInfo> MediaInfoLst
        {
            get { return _MediaInfoLst; }
            set
            {
                _MediaInfoLst = value;
                OnPropertyChanged();
            }
        }

        /*  MediaElement定义以下属性：
            Aspect的类型Aspect，确定如何缩放媒体以适合显示区域。 此属性的默认值为 AspectFit。
            AutoPlay类型bool， 指示在设置Source属性时是否自动开始媒体播放。 此属性的默认值为 true。
            BufferingProgress类型double， 指示当前缓冲进度。 此属性的默认值为 0.0。
            CanSeek类型bool， 指示是否可以通过设置Position属性的值来重新定位媒体。 这是只读属性。
            CurrentState的类型MediaElementState，指示控件的当前状态。 这是一个只读属性，其默认值为MediaElementState.Closed。
            Duration的类型TimeSpan?，表示当前打开的媒体的持续时间。 这是一个只读属性，其默认值为null。
            IsLooping的类型bool， 描述当前加载的媒体源是否应在到达其末尾后从头开始恢复播放。 此属性的默认值为 false。
            KeepScreenOn的类型bool，确定设备屏幕是否应在媒体播放期间保持打开状态。 此属性的默认值为 false。
            Position的类型TimeSpan，通过媒体的播放时间描述当前进度。 此属性的默认值为 TimeSpan.Zero。
            ShowsPlaybackControls的类型bool，确定是否显示平台播放控件。 此属性的默认值为 false。
            Source的类型MediaSource， 指示加载到控件中的介质的源。
            VideoHeight的类型int，指示控件的高度。 这是只读属性。
            VideoWidth的类型int， 表示控件的宽度。 这是只读属性。
            Volume类型double， 确定媒体的体积， 以 0 和 1 之间的线性比例表示。 此属性使用TwoWay绑定，其默认值为 1。
            这些属性（属性除外CanSeek）由BindableProperty对象支持，这意味着它们可以成为数据绑定的目标和样式。
            该MediaElement类还定义了四个事件：
            MediaOpened在验证并打开媒体流时触发。
            MediaEnded在MediaElement播放其媒体后触发。
            MediaFailed当存在与媒体源关联的错误时，将触发。
            SeekCompleted当请求的寻用操作的搜索点已准备好进行播放时，将触发。
            此外，MediaElement包括Play和PauseStop
            有关 Android 上受支持的媒体格式的信息，请参阅 developer.android.com上支持的媒体格式。 有关通用 Windows 平台 （UWP） 上受支持的媒体格式的信息，请参阅支持编解码器。
         * 
         * 
         * 
         * 
         */

    }
}