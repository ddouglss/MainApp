using System.Text.Json.Serialization;

namespace MainApp.Models.Users
{
    public class UserAuth
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("expiresInMins")]
        public int ExpiresInMins { get; set; }
    }
}
