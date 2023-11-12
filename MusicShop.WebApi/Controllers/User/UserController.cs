using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.User.Services;
using MusicShop.Contracts.User;
using System.Net;
using System.Text.Json;

namespace MusicShop.WebApi.Controllers.User
{
    /// <summary>
    /// Модель - контроллер, определяющая интерфейс, с поведением из конечных точек, для обработки входящих запросов, нацеленных на сущность - пользователь.
    /// </summary>
    [Route("/user")]
    [ApiController()]
    public sealed class UserController : ControllerBase
    {
        /// <summary>
        /// Экземпляр конкретной сущности из зависимости <see cref="IUserService"/>
        /// </summary>
        private IUserService _userService;
        /// <summary>
        /// Экземпляр конкретной сущности из зависимости <see cref="ILogger"/>
        /// </summary>
        private ILogger<UserController> _logger;
        /// <summary>
        /// Конструктор сущности <see cref="UserController"/>
        /// </summary>
        /// <param name="logger">Взятый из зависимости логгер</param>
        /// <param name="userService">Репозиторий, нацеленный на работу с сущностью - пользователь</param>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }
        /// <summary>
        /// Создание пользователя, на основе дто модели - <paramref name="userToAdd"/>, асинхронно.
        /// </summary>
        /// <param name="userToAdd">Информация о пользователе для добавления в БД</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest userToAdd, CancellationToken token = default)
        { 
            Guid newUserGuid = await _userService.AddUserAsync(userToAdd,token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToAdd)} was added into database");
            
            return Created("/user", newUserGuid);
        }
        /// <summary>
        /// Получение каждого пользователя, асинхронно.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(IQueryable<UserInfoResponse>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUsersAsync(CancellationToken token = default)
        {
            IQueryable<UserInfoResponse> usersInfo = await _userService.GetAllUsersAsync(token);

            foreach (UserInfoResponse userInfo in usersInfo)
                _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userInfo)} was taken from database");

            return Ok(usersInfo);
        }
        /// <summary>
        /// Получение пользователя, чей ID согласован с <paramref name="userId"/>, асинхронно.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("{userId:guid}")]
        [ProducesResponseType(typeof(UserInfoResponse),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid userId, CancellationToken token = default)
        {
            UserInfoResponse foundUserInfo = await _userService.GetUserByIdAsync(userId, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(foundUserInfo)} was taken from database");

            return Ok(foundUserInfo);
        }
        /// <summary>
        /// Удаление пользователя из базы данных, асинхронно.
        /// </summary>
        /// <param name="userToDelete">Информация о пользователе, для удаления того из БД</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete()]
        [Authorize()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUserAsync([FromQuery] DeleteUserRequest userToDelete, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            await _userService.DeleteUserAsync(userToDelete, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToDelete)} was deleted from database");;

            return Ok();
        }
        /// <summary>
        /// Обновление информации о пользователе, асинхронно.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="updateInfo">Информация о пользователе, для обновления того в БД</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPut("{userId:guid}")]
        [Authorize()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserAsync(Guid userId,[FromBody] UpdateUserRequest updateInfo, CancellationToken token = default)
        {
            await _userService.UpdateUserAsync(userId,updateInfo,token);
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userId)} was updated in database");
            return Ok();
        }
        /// <summary>
        /// Получение информации о текущем, активном пользователе в сессии клиента.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpGet("current")]
        [Authorize()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetCurrentUser(CancellationToken token = default)
        {
            UserInfoResponse foundUser = await _userService.GetCurrentUser(token);
            _logger.Log(LogLevel.Information, $" User with ID:{foundUser.Id} and Login: {foundUser.Login} in session.");
            return Ok(foundUser);
        }

        /// <summary>
        /// Аутентификация пользователя.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpPost("authentication")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromQuery]string email, CancellationToken token = default)
        {
            string jwtToken = await _userService.Login(email, token);
            _logger.Log(LogLevel.Information, $"user with email: {email} was authorized into session");
            return Created("/authorization", jwtToken);
        }
    }
}
