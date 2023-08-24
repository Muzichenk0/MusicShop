using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Contracts.User;
using System.Net;
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
        /// Метод-обработчик входящего запроса по маршруту - /user, относительно адреса:порта сервера.
        /// </summary>
        /// <param name="userToAdd"></param>
        /// <param name="token"></param>
        [HttpPost("/creatingUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest userToAdd, CancellationToken token = default)
        {
            await _userRepository.AddAsync(userToAdd,token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToAdd)} was added into database");
            
            return Ok();
        }
        /// <summary>
        /// Получение каждого пользователя, асинхронно.
        /// </summary>
        /// <param name="token"></param>
        [HttpGet("/users")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUsersAsync(CancellationToken token = default)
        {
            IQueryable<UserInfoResponse> usersInfo = await _userRepository.GetAllAsync(token);

            foreach (UserInfoResponse userInfo in usersInfo)
                _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userInfo)} was taken from database");

            return Ok(usersInfo);
        }

        /// <summary>
        /// Получение пользователя с помощью <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        [HttpGet("/userById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserByIdAsync([FromHeader]Guid id, CancellationToken token = default)
        {
            UserInfoResponse foundUserInfo = await _userRepository.GetByIdAsync(id, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(foundUserInfo)} was taken from database");

            return Ok(foundUserInfo);
        }

        /// <summary>
        /// Удаление пользователя из базы данных, асинхронно.
        /// </summary>
        /// <param name="userToDelete"></param>
        /// <param name="token"></param>
        [HttpDelete("/deletingUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUserAsync([FromBody]DeleteUserRequest userToDelete, CancellationToken token = default)
        {
            await _userRepository.DeleteAsync(userToDelete);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToDelete)} was deleted from database");;

            return Ok();
        } 

        /// <summary>
        /// Обновление информации о пользователе, асинхронно.
        /// </summary>
        /// <param name="userToDelete"></param>
        /// <param name="token"></param>
        [HttpPut("/updatingUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUserAsync([FromBody]UpdateUserRequest userToDelete, CancellationToken token = default)
        {
            await _userRepository.UpdateAsync(userToDelete,token);
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToDelete)} was updated in database");
            return Ok();
        }
    }
}
