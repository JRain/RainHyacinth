using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RainHyacinth.Encrypt.Imp
{
    /// <summary>
    /// DES加密算法
    /// </summary>
    public class DesEncryptService : IEncryptService
    {
        private DesEncryptService()
        {
        }

        static readonly Lazy<IEncryptService> Lazy = new Lazy<IEncryptService>(() => new DesEncryptService());
        public static IEncryptService Instance => Lazy.Value;
        public string Decrypt(string text, string key = "zinnia!@#")
        {
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                var inputByteArray = new byte[text.Length / 2];
                for (var x = 0; x < text.Length / 2; x++)
                {
                    var i = (Convert.ToInt32(text.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                desCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(key);
                desCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(key);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cryptoStream.FlushFinalBlock();

                        return Encoding.Default.GetString(memoryStream.ToArray());
                    }
                }
            }
        }

        public string Encrypt(string text, string key = "316701c0")
        {
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                var inputByteArray = Encoding.Default.GetBytes(text);
                desCryptoServiceProvider.Key = desCryptoServiceProvider.IV = EncryptKeyToDecryptKeyBytes(key);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cryptoStream.FlushFinalBlock();
                        var builder = new StringBuilder();
                        foreach (var b in memoryStream.ToArray())
                        {
                            builder.AppendFormat("{0:X2}", b);
                        }
                        return builder.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 加密秘钥转成解密秘钥(单向转)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncryptKeyToDecryptKey(string key)
        {
            return EncryptKeyToDecryptKeyBytes(key).Aggregate(string.Empty, (current, b) => current + (char)b);
        }

        /// <summary>
        /// 加密秘钥转成解密秘钥byte[]数组(单向转)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] EncryptKeyToDecryptKeyBytes(string key)
        {
            using (var md5CryptoServiceProvider = new MD5CryptoServiceProvider())
            {
                var data = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key), 0, key.Length);
                var builder = new StringBuilder();
                foreach (var t in data)
                {
                    builder.Append(t.ToString("x2"));
                }
                return Encoding.ASCII.GetBytes(builder.ToString().Substring(0, 8));
            }
        }
    }
}
