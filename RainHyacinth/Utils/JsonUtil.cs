using System;
using System.IO;
using Newtonsoft.Json;

namespace RainHyacinth.Utils
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public sealed class JsonUtil
    {
        /// <summary>
        /// Json序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// 格式化Json数据
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonFormat(string json)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(json);
            JsonTextReader jtr = new JsonTextReader(tr);
            try
            {
                object obj = serializer.Deserialize(jtr);
                if (obj == null)
                    return json;
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
