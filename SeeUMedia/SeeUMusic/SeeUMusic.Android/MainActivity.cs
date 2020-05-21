using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Content;
using Acr.UserDialogs.Infrastructure;
using SeeUMedia;
using Android.Webkit;
using static Android.Webkit.WebChromeClient;

namespace SeeUMusic.Droid
{
    [Activity(Label = "SeeUMedia", Icon = "@drawable/music", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    { 
        public static MainActivity Current { get; private set; }
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<string> PickImageTaskCompletionSource { get; set; }
        private static FrameLayout mLayout;    // 用来显示视频的布局
        private static View mCustomView;   //用于全屏渲染视频的View
        private static WebChromeClient.ICustomViewCallback mCustomViewCallback;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Current = this;
            base.OnCreate(savedInstanceState);

            ////Remove title bar
            //RequestWindowFeature(WindowFeatures.NoTitle);
            ////Remove notification bar
            //Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            //SetContentView(Resource.Layout.RelativeLayout);
            //mLayout = (FrameLayout)FindViewById(Resource.Id.fl_video);
            //WebView webView = (WebView)FindViewById(Resource.Id.wv_content);
            //webView.LoadUrl("https://www.iqiyi.com/");
            //webView.SetWebChromeClient(new CustomWebViewChromeClient());

            //注册未处理异常事件
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState); // 注册插件
            Acr.UserDialogs.UserDialogs.Init(this);//注册Acr控件
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    // Set the filename as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(data.DataString);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #region 再按一次退出程序

        private DateTime? lastBackKeyDownTime;

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && e.Action == KeyEventActions.Down && e.RepeatCount == 0)
            {
                var backPressed = DateTime.Now;
                var navigation = App.Current.MainPage.Navigation;
                if (navigation.NavigationStack.Count > 1)
                {
                    navigation.PopAsync();
                    OnBackPressed();
                    return false;
                }
                else if (!lastBackKeyDownTime.HasValue || backPressed.Subtract(lastBackKeyDownTime.Value).Seconds > 3)
                {
                    lastBackKeyDownTime = backPressed;
                    var toast = Toast.MakeText(this, "再按一次退出程序", ToastLength.Short);
                    toast.SetGravity(GravityFlags.Center, 0, 0);
                    toast.Show();
                }
                else
                {
                    Finish();
                }
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }

        #endregion

        #region 异常处理
        protected override void Dispose(bool disposing)
        {
            AndroidEnvironment.UnhandledExceptionRaiser -= AndroidEnvironment_UnhandledExceptionRaiser;
            base.Dispose(disposing);
        }

        void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            UnhandledExceptionHandler(e.Exception, e);
        }

        /// <summary>
        /// 处理未处理异常
        /// </summary>
        /// <param name="e"></param>
        private void UnhandledExceptionHandler(Exception ex, RaiseThrowableEventArgs e)
        {
            //处理程序（记录 异常、设备信息、时间等重要信息）
            //**************
            Log.Debug(nameof(UnhandledExceptionHandler), ex.Message);
            //提示
            Task.Run(() =>
            {
                Looper.Prepare();
                //可以换成更友好的提示
                //Toast.MakeText(this, "很抱歉,程序出现异常:" + ex.Message + ",即将退出.", ToastLength.Long).Show();
                Looper.Loop();
            });

            //停一会，让前面的操作做完
            System.Threading.Thread.Sleep(2000);

            e.Handled = true;
        }

        #endregion

        private class CustomWebViewChromeClient: WebChromeClient
        {
            public void onShowCustomView(View view, ICustomViewCallback callback)
            {
                base.OnShowCustomView(view, callback);
                //如果view 已经存在，则隐藏
                if (mCustomView != null)
                {
                    callback.OnCustomViewHidden();
                    return;
                }

                mCustomView = view;
                mCustomView.Visibility = ViewStates.Visible;
                mCustomViewCallback = callback;
                mLayout.AddView(mCustomView);
                mLayout.Visibility = ViewStates.Visible;
                mLayout.BringToFront();

                ////设置横屏
                //setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
            }

            public override void OnHideCustomView()
            {
                base.OnHideCustomView();
                if (mCustomView == null)
                {
                    return;
                }
                mCustomView.Visibility = ViewStates.Gone;
                mLayout.RemoveView(mCustomView);
                mCustomView = null;
                mLayout.Visibility = ViewStates.Gone;
                try
                {
                    mCustomViewCallback.OnCustomViewHidden();
                }
                catch (Exception ex)
                {
                }
                // titleView.setVisibility(View.VISIBLE);
               // setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);//竖屏
            }
        }

    }
}