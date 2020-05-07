using Acr.UserDialogs;
using FluentValidation;
using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using SeeUMedia.Bll.BllImplement.LoginMgt;
using SeeUMedia.Common.Helper;
using SeeUMedia.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeeUMedia.ViewModels.LoginVM
{
    public class LoginViewModel:BaseViewModel
    {
        /// <summary>
        /// 验证辅助
        /// </summary>
        private readonly IValidator _validator;

        public LoginViewModel()
        {
            _validator = new LoginUserValidator();
            _loginInfo = new LoginInfo();
        }

        private LoginInfo _loginInfo;
        /// <summary>
        /// 登录信息
        /// </summary>
        public LoginInfo LoginInfo
        {
            get { return _loginInfo; }
            set
            {
                _loginInfo = value;
                OnPropertyChanged();
            }
        }

        private ICommand _loginCommand;
        /// <summary>
        /// 登录命令
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(ExecuteLoginCommand));
            }
        }

        private bool _loginBtnIsEnable;
        /// <summary>
        /// 登录按钮是否可用
        /// </summary>
        public bool LoginBtnIsEnable
        {
            get
            {
                return _loginBtnIsEnable;
            }
            set
            {
                SetProperty(ref _loginBtnIsEnable, value);
            }
        }

        private ICommand _logoutCommand;
        /// <summary>
        /// 退出命令
        /// </summary>
        public ICommand LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new Command(ExecuteLogoutCommand));
            }
        }

        private string _validateMsg;
        /// <summary>
        /// 验证信息
        /// </summary>
        public string ValidateMsg
        {
            get
            {
                return _validateMsg;
            }
            set
            {
                SetProperty(ref _validateMsg, value);
            }
        }

        private string _errorMsg;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg
        {
            get
            {
                return _errorMsg;
            }
            set
            {
                SetProperty(ref _errorMsg, value);
            }
        }

        /// <summary>
        /// 执行登录命令
        /// </summary>
        private void ExecuteLoginCommand()
        {
            TaskAsyncHelper.RunAsync<LoginInfo>(Logining, LoginedCallBack, LoginInfo);
        }

        /// <summary>
        /// 执行登录命令
        /// </summary>
        private  async void ExecuteLogoutCommand()
        {
            ErrorMsg = await Singleton<LoginMgtSvr>.Instance.LogoutInvoke<string>();
        }

        /// <summary>
        /// 登录中
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        private LoginInfo Logining(object[] objParams)
        {
            string msg = string.Empty;
            var loginInfo = objParams[0] as LoginInfo;
           var rlt = Singleton<LoginMgtSvr>.Instance.Invoke<LoginInfo>(loginInfo);
            return rlt.Result.Item1;
        }

        /// <summary>
        /// 登录完成回调
        /// </summary>
        /// <param name="loginInfo"></param>
        private void LoginedCallBack(LoginInfo loginInfo)
        {
            if (loginInfo == null)
            {
                UserDialogs.Instance.HideLoading();
                ErrorMsg = "登录失败";
            }
            else
            {
                //=>获取所属站点信息
                ErrorMsg = string.Format("【{0}】登录成功", loginInfo.UserAccount);
                var userId = loginInfo.UserId.ToString();
            }
        }
    }
}
