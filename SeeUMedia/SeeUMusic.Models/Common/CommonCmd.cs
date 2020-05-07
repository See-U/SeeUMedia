using System.Windows.Input;

namespace SeeUMedia.Models.Common
{
    /// <summary>
    /// 通用命令
    /// </summary>
    public abstract class CommonCmd
    {
        /// <summary>
        /// ItemTapped选中命令
        /// </summary>
        public virtual ICommand ItemTappedCmd { set; get; }

        public virtual void ItemTappedHandler(object objParam)
        {

        }

        /// <summary>
        /// SearchItem命令
        /// </summary>
        public virtual ICommand SearchItemCmd { set; get; }

        public virtual void SearchItemHandler(object objParam)
        {

        }
    }
}
