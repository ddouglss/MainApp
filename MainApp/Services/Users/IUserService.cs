using MainApp.Models.Users;
using MainApp.Models.Users.Response;

namespace MainApp.Services.Users
{
    public interface IUserService 
    {
        Task<UserResponse> List();
        Task<User> Add(User user);
        Task<UserToken> Authenticate(UserAuth auth);
    }
}
