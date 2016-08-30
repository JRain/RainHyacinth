using System;

namespace RainHyacinth.Utils
{
    /// <summary>
    /// 时间戳工具类
    /// </summary>
    public static class TimeStampUtil
    {
        static readonly DateTime UnixStartTime = new DateTime(1970, 1, 1);
        /// <summary>
        /// 时间转换成时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <param name="unixStartTime"></param>
        /// <returns></returns>
        public static int TimeToStampSecondInt32(this DateTime time, DateTime unixStartTime)
        {
            return (int)time.TimeToStampSecondDouble(unixStartTime);
        }
        public static double TimeToStampSecondDouble(this DateTime time, DateTime unixStartTime)
        {
            return (time - TimeZone.CurrentTimeZone.ToLocalTime(unixStartTime)).TotalSeconds;
        }
        public static int TimeToStampSecondInt32(this DateTime time)
        {
            return time.TimeToStampSecondInt32(UnixStartTime);
        }
        public static double TimeToStampSecondDouble(this DateTime time)
        {
            return time.TimeToStampSecondDouble(UnixStartTime);
        }

        public static int TimeToStampMilliSecondInt32(this DateTime time, DateTime unixStartTime)
        {
            return (int)time.TimeToStampMilliSecondDouble(unixStartTime);
        }
        public static double TimeToStampMilliSecondDouble(this DateTime time, DateTime unixStartTime)
        {
            return (time - TimeZone.CurrentTimeZone.ToLocalTime(unixStartTime)).TotalMilliseconds;
        }
        public static int TimeToStampMilliSecondInt32(this DateTime time)
        {
            return time.TimeToStampMilliSecondInt32(UnixStartTime);
        }
        public static double TimeToStampMilliSecondDouble(this DateTime time)
        {
            return time.TimeToStampMilliSecondDouble(UnixStartTime);
        }

        /// <summary>
        /// 时间戳转换成时间
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="unixStartTime"></param>
        /// <returns></returns>
        public static DateTime SecondInt32StampToTime(this int stamp, DateTime unixStartTime)
        {
            return SecondDoubleStampToTime(stamp, unixStartTime);
        }
        public static DateTime SecondDoubleStampToTime(this double stamp, DateTime unixStartTime)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(unixStartTime).AddSeconds(stamp);
        }
        public static DateTime SecondInt32StampToTime(this int stamp)
        {
            return stamp.SecondInt32StampToTime(UnixStartTime);
        }
        public static DateTime SecondDoubleStampToTime(this double stamp)
        {
            return stamp.SecondDoubleStampToTime(UnixStartTime);
        }

        public static DateTime MilliSecondInt32StampToTime(this int stamp, DateTime unixStartTime)
        {
            return MilliSecondDoubleStampToTime(stamp, unixStartTime);
        }
        public static DateTime MilliSecondDoubleStampToTime(this double stamp, DateTime unixStartTime)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(unixStartTime).AddMilliseconds(stamp);
        }
        public static DateTime MilliSecondInt32StampToTime(this int stamp)
        {
            return stamp.MilliSecondInt32StampToTime(UnixStartTime);
        }
        public static DateTime MilliSecondDoubleStampToTime(this double stamp)
        {
            return stamp.MilliSecondDoubleStampToTime(UnixStartTime);
        }
    }
}
