namespace SeeUMedia.Models.Common
{
    /// <summary>
    /// 动作处理结果
    /// </summary>
    public class ActionHandlerResult
    {
        /// <summary>
        /// 结果对象
        /// </summary>
        public object ResultObj { get; set; }

        /// <summary>
        /// 标识结果(True,False)
        /// </summary>
        public bool Flag { get; set; }
    }
}