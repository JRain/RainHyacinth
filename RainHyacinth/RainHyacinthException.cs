using System;

namespace RainHyacinth
{
    /// <summary>
    /// RainHyacinth框架异常
    /// </summary>
    public class RainHyacinthException : Exception
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
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; private set; }
        /// <summary>
        /// 外部抛出异常
        /// </summary>
        public Exception ThrowException { get; private set; }
    }
}
