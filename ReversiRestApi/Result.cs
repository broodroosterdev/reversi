using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ReversiRestApi
{
    public class Result
    {
        public string? PlayerToken;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultType Type;

        public Result() { }

        public Result(string playerToken, ResultType type)
        {
            PlayerToken = playerToken;
            Type = type;
        }
    }

    public enum ResultType
    {
        Won,
        Draw,
        Resigned
    }   
}