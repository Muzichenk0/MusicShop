using MusicShop.Domain.Models.User;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MusicShop.Api.Tests.UserTests
{
    public class UserTests : IClassFixture<DbAppContextFactory>
    {
        private readonly DbAppContextFactory _dbContextFactory;
        public UserTests(DbAppContextFactory dbContextFactory)
            => _dbContextFactory = dbContextFactory;
        [Fact]
        public async Task User_GetById_Success()
        {
            //Arrange
            HttpClient client = _dbContextFactory.CreateClient();
            Guid id = DataSeedHelper.TestUserId;
            //Action
            using HttpResponseMessage response = await client.GetAsync($"/user?userId={id}");
            //Assert
            Assert.NotNull(response);
            User? user = await response.Content.ReadFromJsonAsync<User>();
            Assert.Equal("test_login", user!.Login);
            Assert.Equal("test_mail", user!.EMail);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
