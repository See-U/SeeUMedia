using SeeUMedia.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeUMedia.Models.Login
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginInfo : BaseBind
    {
        private int _userId;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        private string _userAccount = string.Empty;
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount
        {
            get { return _userAccount; }
            set
            {
                _userAccount = value;
                OnPropertyChanged(nameof(UserAccount));
            }
        }

        private string _userPassword = string.Empty;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        private string _nickname = string.Empty;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname
        {
            get { return _nickname; }
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }

        
    }
}
