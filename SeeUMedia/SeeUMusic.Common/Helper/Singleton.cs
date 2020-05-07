using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace SeeUMedia.Common.Helper
{
    /// <summary>
    /// 管理单实例
    /// </summary>
    /// <typeparam name="T">Type of the singleton class.</typeparam>
    public static class Singleton<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// 目标类
        /// </summary>
        static volatile T _instance;

        /// <summary>
        /// The dummy object used for locking.
        /// </summary>
        static object _lock = new object();

        #endregion Fields


        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        static Singleton()
        {
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// 获取T实例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            ConstructorInfo constructor = null;

                            try
                            {
                                // Binding flags exclude public constructors.
                                constructor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                                //constructor = typeof(T).GetConstructor(new Type[0]);
                            }
                            catch (Exception exception)
                            {
                                throw new SingletonException(exception);
                            }

                            if (constructor == null || constructor.IsAssembly) // Also exclude internal constructors.
                                throw new SingletonException(string.Format("A private or protected constructor is missing for '{0}'.", typeof(T).Name));

                            _instance = (T)constructor.Invoke(null);
                        }
                    }

                return _instance;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// 创建单实例异常
    /// </summary>
    [Serializable]
    public class SingletonException
       : Exception
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SingletonException()
        {
        }

        /// <summary>
        /// Initializes a new instance with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SingletonException(string message)
           : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance with a reference to the inner 
        /// exception that is the cause of this exception.
        /// </summary>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, 
        /// or a null reference if no inner exception is specified.
        /// </param>
        public SingletonException(Exception innerException)
           : base(null, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance with a specified error message and a 
        /// reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, 
        /// or a null reference if no inner exception is specified.
        /// </param>
        public SingletonException(string message, Exception innerException)
           : base(message, innerException)
        {
        }

#if !WindowsCE
        /// <summary>
        /// Initializes a new instance with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the 
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains 
        /// contextual information about the source or destination.
        /// </param>
        /// <exception cref="System.ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected SingletonException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }
#endif
    }
}
