using System.Text.Json.Serialization;

namespace MainApp.Models.Users.Response
{
    public class UserResponse
    {
        [JsonPropertyName("users")]
        public List<User> Users { get; set; }
    }
}
