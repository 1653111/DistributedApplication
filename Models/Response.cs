using System.Text.Json;
using System.Text.Json.Serialization;
namespace ApiService.Models
{
    public class Response<T>
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}