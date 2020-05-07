using System;
using System.Threading.Tasks;

namespace SeeUMedia.Common.Helper
{
    /// <summary>
    /// 任务异步处理
    /// </summary>
    public static class TaskAsyncHelper
    {
        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是void</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法没有参数，返回类型必须是void</param>
        public static async void RunAsync(Action function, Action callback)
        {
            Func<Task> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    function();
                });
            };
            await taskFunc();
            if (callback != null)
                callback();
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是void</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法有参数，返回类型必须是void</param>
        public static async void RunAsync(string parm, Action function, Action<string> callback)
        {
            Func<Task> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    function();
                });
            };
            await taskFunc();
            if (callback != null)
                callback(parm);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(Func<TResult> function, Action<TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function();
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
                callback(rlt);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="function">异步方法，该方法有参数</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法,该方法有参数，返回类型必须是void</param>
        public static async void RunAsync<TResult>(TResult parm, Action<TResult> function, Action<TResult> callback)
        {
            Func<Task> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    function(parm);
                });
            };
            await taskFunc();
            callback?.Invoke(parm);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="parm">异步方法需传入的参数</param>
        /// <param name="function">异步方法，该方法有string参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(string parm, Func<string, TResult> function, Action<string, TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function(parm);
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
                callback(parm, rlt);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="parm1">异步方法需传入的参数</param>
        /// <param name="parm2">异步方法需传入的参数</param>
        /// <param name="function">异步方法，该方法有string参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(string parm1, string parm2, Func<string, string, TResult> function, Action<TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function(parm1, parm2);
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
                callback(rlt);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="parm1">异步方法需传入的参数</param>
        /// <param name="parm2">异步方法需传入的参数</param>
        /// <param name="parm3">异步方法需传入的参数</param>
        /// <param name="function">异步方法，该方法有string参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(string parm1,
                                                    string parm2,
                                                    string parm3,
                                                    Func<string, string, string, TResult> function,
                                                    Action<string, TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function(parm1, parm2, parm3);
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
                callback(parm1, rlt);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="parms">异步方法需传入的参数数组</param>
        /// <param name="function">异步方法，该方法有string参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(object[] parms,
                                                    Func<string, string, string, string, string, string, TResult> function,
                                                    Action<TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function(parms[0] == null ? string.Empty : parms[0].ToString(),
                                    parms[1] == null ? string.Empty : parms[1].ToString(),
                                    parms[2] == null ? string.Empty : parms[2].ToString(),
                                    parms[3] == null ? string.Empty : parms[3].ToString(),
                                    parms[4] == null ? string.Empty : parms[4].ToString(),
                                    parms[5] == null ? string.Empty : parms[5].ToString()
                                    );
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
                callback(rlt);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="parm1">异步方法需传入的参数1</param>
        /// <param name="parm2">异步方法需传入的参数2</param>
        /// <param name="function">异步方法，该方法有两个string参数，返回类型必须是Tuple<bool, string></param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为bool和string，返回类型必须是void</param>
        public static async void RunAsync<TResult>(string parm1, string parm2, Func<string, string, TResult> function, Action<bool, string> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function(parm1, parm2);
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
            {
                Tuple<bool, string> tuple = rlt as Tuple<bool, string>;
                callback(tuple.Item1, tuple.Item2);
            }
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="parms">异步方法需传入的参数数组</param>
        /// <param name="function">异步方法，该方法有三个string参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        public static async void RunAsync<TResult>(object[] parms,
                                                   Func<string, string, string, TResult> function,
                                                   Action<TResult> callback)
        {
            Func<Task<TResult>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function(parms[0] == null ? string.Empty : parms[0].ToString(),
                                    parms[1] == null ? string.Empty : parms[1].ToString(),
                                    parms[2] == null ? string.Empty : parms[2].ToString());
                });
            };
            TResult rlt = await taskFunc();
            callback?.Invoke(rlt);
        }

        /// <summary>
        /// 将一个方法function异步运行，在执行完毕时执行回调callback
        /// </summary>
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>
        /// <param name="function">异步方法，该方法有三个string参数，返回类型必须是TResult</param>
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>
        /// <param name="paramObj">异步方法需传入的参数数组</param>
        public static async void RunAsync<TResult>(Func<object[], TResult> function,
                                                   Action<TResult> callback,
                                                   params object[] paramObj)
        {
            try
            {
                Func<Task<TResult>> taskFunc = () =>
                {
                    return Task.Run(() =>
                    {
                        return function(paramObj);
                    });
                };
                TResult rlt = await taskFunc();
                callback?.Invoke(rlt);
            }
            catch (Exception ex)
            {
                string errorMsg =
                    "系统遇到无法处理的异常:"
                    + ex.Message + "\r\n异常位置:"
                    + ex.StackTrace + "\r\n异常级别:"
                    + ex.GetType();
            }
        }

    }
}
