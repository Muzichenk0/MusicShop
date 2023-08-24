using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Contracts.User;
using MusicShop.Domain.Models.User;
using System.Text.Json;

namespace MusicShop.WebApi.Controllers.User
{
    [ApiController()]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private ILogger<UserController> _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userRepository"></param>
        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userToAdd"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/users")]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest userToAdd, CancellationToken token = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToAdd)} was transfered into adding handle pipeline");
            await _userRepository.AddAsync(userToAdd);

            return Ok();
        }
    }
}
