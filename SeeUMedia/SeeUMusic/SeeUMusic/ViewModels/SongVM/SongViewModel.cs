using Acr.UserDialogs;
using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using SeeUMedia.Common.Helper;
using SeeUMedia.Models;
using SeeUMedia.Models.SongModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeeUMedia.ViewModels.SongVM
{
    public class SongViewModel:BaseViewModel
    {
        private static CloudMusicApi api = new CloudMusicApi();
        private static Dictionary<string, string> queries;
        private static bool isOk;
        private static string msg;
        private static JObject json;

        public SongViewModel(MediaElement media)
        {
            MediaElement = media;
            SearchItemCmd = new Command<string>(SearchItemHandler);//注册 
            PlayCmd = new Command<object>(PlayHandler);
            PauseCmd = new Command<object>(PauseHandler);
            PreviousCmd = new Command(PreviousHandler);
            NextCmd = new Command(NextHandler);
            ItemTappedCmd = new Command(SongsLsvt_ItemTappedHandler);
            CurMediaInfo = new MediaInfo();
            MediaElement.MediaFailed += MediaElement_MediaFailed;
            MediaElement.MediaOpened += MediaElement_MediaOpened;
            SearchItemCmd.Execute("流行");
        }

        private void MediaElement_MediaFailed(object sender, EventArgs e)
        {
            MediaElement.Stop();
            //IsPlay = false;
        }

        private void MediaElement_MediaOpened(object sender, EventArgs e)
        {
            TaskAsyncHelper.RunAsync(new Action(() =>
            {
                while (true)
                {
                    if (MediaElement.CurrentState == MediaElementState.Playing)
                    {
                        IsPlay = true;
                    }
                    else
                    {
                        IsPlay = false;
                    }
                    Thread.Sleep(100);
                }
            }), null);
        }

        // ICommand implementations
        public ICommand PlayCmd { protected set; get; }
        public ICommand PauseCmd { protected set; get; }
        public ICommand PreviousCmd { protected set; get; }
        public ICommand NextCmd { protected set; get; }
        //public override ICommand ItemTappedCmd { set; get; }
        
        /// <summary>
        /// SearchMusic
        /// </summary>
        /// <returns></returns>
        private async Task SearchMusic(string keyWords)
        {
            try
            {
                SongLst = new ObservableCollection<Song>();
                queries = new Dictionary<string, string>();
                queries["keywords"] = keyWords;
                (isOk, json) = await api.RequestAsync(CloudMusicApiProviders.Search, queries);
                if (!isOk)
                    throw new ApplicationException($"获取歌曲详情失败： {json}");
                var Lst = json["result"];
                foreach (JObject song in Lst["songs"])
                {
                    var item = song.ToObject<Song>();
                    SongLst.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObservableCollection<Song> _SongLst;
        /// <summary>
        /// SongList
        /// </summary>
        public ObservableCollection<Song> SongLst
        {
            get 
            {
                return _SongLst;
            }
            set
            {
                if (_SongLst != value)
                {
                    _SongLst = value;
                    OnPropertyChanged();
                }
            }
        }

        private MediaElement _MediaElement;
        /// <summary>
        /// SongListMediaElement
        /// </summary>
        public MediaElement MediaElement
        {
            get
            {
                return _MediaElement;
            }
            set
            {
                if (_MediaElement != value)
                {
                    _MediaElement = value;
                    OnPropertyChanged();
                }
            }
        }

        private MediaInfo _CurMediaInfo;
        /// <summary>
        /// CurMediaInfo
        /// </summary>
        public MediaInfo CurMediaInfo
        {
            get
            {
                return _CurMediaInfo;
            }
            set
            {
                if (_CurMediaInfo != value)
                {
                    _CurMediaInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _IsPlay;
        /// <summary>
        /// IsPlay
        /// </summary>
        public bool IsPlay
        {
            get
            {
                return _IsPlay;
            }
            set
            {
                if (_IsPlay != value)
                {
                    _IsPlay = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// SearchItemHandler
        /// </summary>
        /// <param name="notWeightWO"></param>
        public override async void SearchItemHandler(object obj)
        {
            var key = obj.ToString();
            await SearchMusic(key);
        }

        /// <summary>
        ///  Play
        /// </summary>
        /// <param name="obj"></param>
        public void PlayHandler(object obj)
        {
            if (MediaElement.CurrentState != MediaElementState.Playing)
            {
                MediaElement.Play();
            }
        }

        public void SongsLsvt_ItemTappedHandler(object obj)
        {
            try
            {
                if (obj != null)
                {
                    var item = obj as Song;
                    MediaElement.Source = GetSourceById(item.id);
                    MediaElement.Play();
                    CurMediaInfo.DisplayName = item.name;
                    CurMediaInfo.Artist = item.artists[0].name;
                }
                else if (MediaElement.Source != null)
                {
                    MediaElement.Play();
                }
                else
                {
                    UserDialogs.Instance.Toast("未选择需要播放的歌曲！");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast(ex.ToString());
            }
        }

        /// <summary>
        /// Pause
        /// </summary>
        /// <param name="obj"></param>
        public void PauseHandler(object obj)
        {
            if (MediaElement.CurrentState == MediaElementState.Playing)
            {
                MediaElement.Pause();
            }
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="obj"></param>
        public void PreviousHandler()
        {
            try
            {
                var curSong = new Song();
                if (SongLst != null && SongLst.Count > 0)
                {
                    var mediaSource = MediaElement.Source.ToString();
                    if (string.IsNullOrEmpty(mediaSource))
                    {
                        curSong = SongLst[0];
                        MediaElement.Source = GetSourceById(curSong.id);
                        MediaElement.Play();
                        CurMediaInfo.DisplayName = curSong.name;
                        CurMediaInfo.Artist = curSong.artists[0].name;
                    }
                    else
                    {
                        foreach (var item in SongLst)
                        {
                            if (mediaSource.Contains(item.id.ToString()))
                            {
                                int curItemId = SongLst.IndexOf(item);
                                MediaElement.Stop();
                                if (curItemId != 0)
                                {
                                    curSong = SongLst[--curItemId];
                                    MediaElement.Source = GetSourceById(curSong.id);
                                    CurMediaInfo.DisplayName = curSong.name;
                                    CurMediaInfo.Artist = curSong.artists[0].name;
                                }
                                else
                                {
                                    MediaElement.Source = mediaSource;
                                    UserDialogs.Instance.Toast("已经是第一首歌了！");
                                }

                                MediaElement.Play();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.ToString());
            }
        }

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="obj"></param>
        public void NextHandler()
        {
            try
            {
                var curSong = new Song();
                if (SongLst != null && SongLst.Count > 0)
                {
                    var mediaSource = MediaElement.Source.ToString();
                    if (string.IsNullOrEmpty(mediaSource))
                    {
                        curSong = SongLst[0];
                        MediaElement.Source = GetSourceById(curSong.id);
                        MediaElement.Play();
                        CurMediaInfo.DisplayName = curSong.name;
                        CurMediaInfo.Artist = curSong.artists[0].name;
                    }
                    else
                    {
                        foreach (var item in SongLst)
                        {
                            if (mediaSource.Contains(item.id.ToString()))
                            {
                                MediaElement.Stop();
                                IsPlay = false;

                                int curItemId = SongLst.IndexOf(item);
                                if (SongLst.Count > curItemId)
                                {
                                    curSong = SongLst[++curItemId];
                                    MediaElement.Source = GetSourceById(curSong.id);
                                    CurMediaInfo.DisplayName = curSong.name;
                                    CurMediaInfo.Artist = curSong.artists[0].name;
                                }
                                else
                                {
                                    MediaElement.Source = mediaSource;
                                    UserDialogs.Instance.Toast("已经是最后一首歌了！");
                                }

                                MediaElement.Play();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.ToString());
            }
        }

        /// <summary>
        /// GetSourceById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private MediaSource GetSourceById(int id)
        {
            MediaSource mediaSource = "http://music.163.com/song/media/outer/url?id=" + id + ".mp3";
            return mediaSource;
        }
    }
}
