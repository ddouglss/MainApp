using MainApp.Data;
using MainApp.Models.Users;
using MainApp.Models.Users.Response;
using MainApp.Services.RequestProvider;

namespace MainApp.Services.Users
{
    public class UserService(IRequestProvider requestProvider) : SQliteConnection<User>, IUserService
    {
        private readonly IRequestProvider _requestProvider = requestProvider;
        public async Task<User> Add(User user)
        {
            #region Local Database
            user.Username = "douglas";
            await AddAsync(user);
            #endregion

            var uri = GlobalSettings.Instance.UserEndpoint + "/add";
            return await _requestProvider.PostAsync<User, User>(uri, user);
        }

        public async Task<UserToken> Authenticate(UserAuth auth)
        {
            #region Local Database
            var user = await GetAsync(x => x.Username.Equals(auth.Username));
            await AddAsync(user);

            #endregion

            var uri = GlobalSettings.Instance.UserEndpoint + "/login";
            return await _requestProvider.PostAsync<UserToken, UserAuth>(uri, auth);
        }

        public async Task<UserResponse> List()
        {
            var uri = GlobalSettings.Instance.UserEndpoint;
            return await _requestProvider.GetAsync<UserResponse>(uri);
        }
    }
}
