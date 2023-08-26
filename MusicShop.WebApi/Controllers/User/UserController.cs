using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Contracts.User;
using System.Net;
using System.Text.Json;

namespace MusicShop.WebApi.Controllers.User
{
    /// <summary>
    /// Контроллер с конечными точками, для обработки входящих запросов, нацеленных на сущность - пользователь.
    /// </summary>
    [ApiController()]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Экземпляр конкретной сущности из зависимости <see cref="IUserRepository"/>
        /// </summary>
        private IUserRepository _userRepository;
        /// <summary>
        /// Экземпляр конкретной сущности из зависимости <see cref="ILogger"/>
        /// </summary>
        private ILogger<UserController> _logger;
        /// <summary>
        /// Конструктор сущности <see cref="UserController"/>
        /// </summary>
        /// <param name="logger">Взятый из зависимости логгер</param>
        /// <param name="userRepository">Репозиторий, нацеленный на работу с сущностью - пользователь</param>
        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Метод-обработчик входящего запроса по маршруту - /user, относительно адреса:порта сервера.
        /// </summary>
        /// <param name="userToAdd">Информация о пользователе для добавления в БД</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpPost("/creatingUser")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest userToAdd, CancellationToken token = default)
        {
            await _userRepository.AddAsync(userToAdd,token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToAdd)} was added into database");
            
            return Created("/creatingUser",userToAdd);
        }

        /// <summary>
        /// Получение каждого пользователя, асинхронно.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpGet("/users")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUsersAsync(CancellationToken token = default)
        {
            IQueryable<UserInfoResponse> usersInfo = await _userRepository.GetAllAsync(token);

            //foreach (UserInfoResponse userInfo in usersInfo)
                //_logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userInfo)} was taken from database");

            return Ok(usersInfo);
        }

        /// <summary>
        /// Получение пользователя с помощью <paramref name="userId"/>
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpGet("/userById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserByIdAsync([FromHeader]Guid userId, CancellationToken token = default)
        {
            UserInfoResponse foundUserInfo = await _userRepository.GetByIdAsync(userId, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(foundUserInfo)} was taken from database");

            return Ok(foundUserInfo);
        }

        /// <summary>
        /// Удаление пользователя из базы данных, асинхронно.
        /// </summary>
        /// <param name="userToDelete">Информация о пользователе, для удаления того из БД</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpDelete("/deletingUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUserAsync([FromBody]DeleteUserRequest userToDelete, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            await _userRepository.DeleteAsync(userToDelete, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToDelete)} was deleted from database");;

            return Ok();
        }

        /// <summary>
        /// Обновление информации о пользователе, асинхронно.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="userToDelete">Информация о пользователе, для обновления того в БД</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpPut("/updatingUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserAsync(Guid userId,[FromBody]UpdateUserRequest userToDelete, CancellationToken token = default)
        {
            await _userRepository.UpdateAsync(userId,userToDelete,token);
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userId)} was updated in database");
            return Ok();
        }
    }
}
