using System.Text.Json;

namespace Common.Helper;

public static class StringExtension
{
    public static T? ToObject<T>(this string data)
    {
        return string.IsNullOrEmpty(data) ? default : JsonSerializer.Deserialize<T>(data);
    }
}
