namespace RainHyacinth.Encrypt
{
    /// <summary>
    /// 加密算法接口
    /// </summary>
    public interface IEncryptService
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string Encrypt(string text, string key);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string Decrypt(string text, string key);
    }
}
