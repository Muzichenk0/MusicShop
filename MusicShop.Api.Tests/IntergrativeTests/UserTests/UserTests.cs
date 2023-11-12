using MusicShop.Api.Tests.IntegrationTests;
using MusicShop.Api.Tests.IntergrativeTests;
using MusicShop.Domain.Models.User;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit;

namespace MusicShop.Api.Tests.UserTests
{
    /// <summary>
    /// Интеграционные тесты, связанные с моделью предметной области - пользователь.
    /// </summary>
    public class UserTests : IClassFixture<DbAppContextFactory>
    {
        private readonly DbAppContextFactory _dbContextFactory;
        public UserTests(DbAppContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// Тестирование идентификации, аутентификации, авторизации текущего пользователя.
        /// </summary>
        [Fact()]
        public async Task User_Login_Success()
        {
            //Arrange
            HttpClient httpClient = _dbContextFactory.CreateClient();
            //Action
            using HttpResponseMessage authResponse = await httpClient.PostAsync("/user/authorization?email=test_mail", null);
            string? jwToken = await authResponse.Content.ReadAsStringAsync();
            //Assert
            Assert.Equal(HttpStatusCode.Created, authResponse.StatusCode);
            Assert.NotNull(jwToken);
        }
        /// <summary>
        /// Получение информации о текущем, авторизованном пользователе в активной сессии.
        /// </summary>
        [Fact()]
        public async Task User_Current_Success()
        {
            //Arrange
            HttpClient client = _dbContextFactory.CreateClient();
            //Action
            HttpResponseMessage authResponse = await client.PostAsync("user/authorization?email=test_mail", null);
            string? jwToken = await authResponse.Content.ReadAsStringAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwToken);
            HttpResponseMessage foundUserResponse = await client.GetAsync("user/current");
            User? foundUser = await foundUserResponse.Content.ReadFromJsonAsync<User?>();
            //Assert
            Assert.Equal(HttpStatusCode.OK, foundUserResponse.StatusCode);
            Assert.NotNull(foundUser);
            Assert.Equal(DataSeedHelper.TestUserId, foundUser.Id);
        }
        /// <summary>
        /// Получение записи из таблицы "пользователи" с помощью идентификатора.
        /// </summary>
        [Fact()]
        public async Task User_GetById_Success()
        {
            //Arrange
            using HttpClient client = _dbContextFactory.CreateClient();
            Guid id = DataSeedHelper.TestUserId;
            //Action
            using HttpResponseMessage response = await client.GetAsync($"/user/{id}");
            User? user = await response.Content.ReadFromJsonAsync<User>();
            //Assert
            Assert.NotNull(response);
            Assert.Equal("test_login", user!.Login);
            Assert.Equal("test_mail", user!.EMail);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
