using System;

namespace RainHyacinth
{
    /// <summary>
    /// RainHyacinth 框架异常接口
    /// </summary>
    public interface IRainHyacinthException
    {
        /// <summary>
        /// 错误码
        /// </summary>
        string ErrorCode { get; }
        /// <summary>
        /// 外部抛出异常
        /// </summary>
        Exception ThrowException { get; }
    }

    /// <summary>
    /// RainHyacinth框架异常
    /// </summary>
    public class RainHyacinthException : Exception, IRainHyacinthException
    {
        public RainHyacinthException(string code, string message) : base(message)
        {
            ErrorCode = code;
        }
        public RainHyacinthException(string code, string message, Exception ex) : base(message, ex)
        {
            ErrorCode = code;
            ThrowException = ex;
        }
        public string ErrorCode { get; }
        public Exception ThrowException { get; }
    }
    /// <summary>
    /// 未登录异常
    /// </summary>
    public class RainHyacinthNotLoginException : Exception, IRainHyacinthException
    {
        public RainHyacinthNotLoginException(string message) : base(message)
        {

        }
        public RainHyacinthNotLoginException(string message, Exception ex) : base(message, ex)
        {
            ThrowException = ex;
        }
        public string ErrorCode => RainHyacinthBusinessErrorCode.NotLogin;
        public Exception ThrowException { get; }
    }

}
