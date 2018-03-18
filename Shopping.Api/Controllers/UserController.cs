using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Domain.Repositories;
using Shopping.Api.Dtos;

namespace Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        // GET api/user
        [HttpGet]
        public UserDto Get()
        {
            //Todo: Error handling 
            //Logging 
            //Calling to repository directly. No logic so skipping layer.
            var user =  _userRepository?.Get();
            return Mapper.Map<UserDto>(user);
        }

      
    }
}
