using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace RainHyacinth.Utils
{
    public class LoggerUtil
    {
        private static readonly IDictionary<string, MiniLogger> MiniLoggerDictionary = new ConcurrentDictionary<string, MiniLogger>();
        public static object LockObj = new object();
        public static MiniLogger GetMiniLogger(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name)) name = "RainHyacinth";
            if (!MiniLoggerDictionary.ContainsKey(name))
            {
                lock (LockObj)
                {
                    if (!MiniLoggerDictionary.ContainsKey(name))
                    {
                        MiniLoggerDictionary.Add(name, new MiniLogger($@"Logs\[DATE]-{name}.log"));
                    }
                }
            }
            return MiniLoggerDictionary[name];
        }
    }

    /// <summary>
    /// 轻量级日志
    /// </summary>
    public class MiniLogger
    {
        private readonly string _path;

        internal MiniLogger(string path)
        {
            _path = path;
        }
        public void Write(string message)
        {
            var now = DateTime.Now;
            message = $"time:{now.ToString("yyyy-MM-dd HH:mm:ss fff")}|ThreadId:{Thread.CurrentThread.ManagedThreadId}|message:{message}";
            var path = _path.Replace("[DATE]", $"{now:yyyy-MM-dd}");
            path = Regex.Replace(path, @"\|(?<name>\w+)\|", e =>
            {
                var name = e.Groups["name"].Value;
                return AppDomain.CurrentDomain.GetData(name) + "";
            }, RegexOptions.IgnoreCase);
            var dir = DirectoryUtil.GetApplicationRootPath() + Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            path = DirectoryUtil.GetApplicationRootPath() + path;
            lock (this)
            {
                File.AppendAllText(path, message + "\r\n", Encoding.UTF8);
            }
        }

        public void Write(Exception ex)
        {
            Write("", ex);
        }

        public void Write(string message, Exception ex)
        {
            Write(message + ex);
        }

        public void Write<T>(T objInfo) where T : new()
        {
            Write(JsonUtil.JsonSerialize(objInfo));
        }
    }
}
