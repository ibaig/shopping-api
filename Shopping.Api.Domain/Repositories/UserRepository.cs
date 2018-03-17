using Microsoft.Extensions.Options;
using Shopping.Api.Common;
using Shopping.Api.Domain.Models;

namespace Shopping.Api.Domain.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns the api user
        /// </summary>
        /// <returns></returns>
        User Get();
    }

    //Serves as the user store
    public class UserRepository : IUserRepository
    {
        private Settings _settings;

        public UserRepository(IOptions<Settings> options)
        {
            _settings = options.Value;
        }

        public User Get()
        {
            //Returns user from the config. could potentially return it from other sources in future
            return new User
            {
                Name =  _settings.UserName,
                Token = _settings.Token
            };
        }
    }
}
