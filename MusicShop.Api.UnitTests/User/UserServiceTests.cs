
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.AppData.Contexts.User.Services;
using MusicShop.Contracts.User;
using Xunit.Abstractions;

namespace Board.Tests
{
    public class UserServiceTests : IClassFixture<UserListFixture>
    {
        public UserServiceTests(ITestOutputHelper output, UserListFixture fixture)
        {
            _output = output;
            _fixture = fixture;

            _output.WriteLine($"Test {nameof(UserServiceTests)} created");
        }

        private readonly ITestOutputHelper _output;
        private readonly UserListFixture _fixture;

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task User_GetById_Success1(int index)
        {
            // Arrange
            Guid id = UserListFixture.Ids[index];

            CancellationToken token = new CancellationToken(false);

            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<IConfiguration> configMock = new Mock<IConfiguration>();

            UserInfoResponse expected = _fixture.List.First(x => x.Id == id);

            userRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

            IUserService service = new UserService(userRepositoryMock.Object,null, configMock.Object);

            // Act
            UserInfoResponse? result = await service.GetUserByIdAsync(id, token);


            // Assert

            //result.Should(null);

            //id.ShouldBe(result.Id);
            //expected.Name.ShouldBe(result.Name);
            //expected.CreatedAt.ShouldBe(result.CreatedAt);
            //expected.IsActive.ShouldBe(result.IsActive);
            //expected.ParentId.ShouldBe(result.ParentId);

            Assert.Equal(expected, result);
            Assert.Equal(expected.Login, result.Login);

            userRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        }

        //public static IEnumerable<object[]> GetByIdSuccessParams =>
        //    new List<object[]>
        //    {
        //        new object[] { 0, DateTime.Now },
        //        new object[] { 1, DateTime.Now }
        //    };

        //[Theory]
        //[MemberData(nameof(GetByIdSuccessParams))]
        //public async Task Category_GetById_Success2(int index, DateTime dt)
        //{
        //    _output.WriteLine($"Index: {index}, Time: {dt.Ticks}");

        //    // Arrange
        //    Guid id = UserListFixture.Ids[index];

        //    CancellationToken token = new CancellationToken(false);

        //    Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
        //    Mock<IMapper> mapperMock = new Mock<IMapper>();
            
        //    var expected = _fixture.List.First(x => x.Id == id);

        //    categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

        //    CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

        //    // Act
        //    var result = await service.GetByIdAsync(id, token);

        //    // Assert
        //    result.ShouldNotBe(null);

        //    id.ShouldBe(result.Id);
        //    expected.Name.ShouldBe(result.Name);
        //    expected.CreatedAt.ShouldBe(result.CreatedAt);
        //    expected.IsActive.ShouldBe(result.IsActive);
        //    expected.ParentId.ShouldBe(result.ParentId);
            
        //    categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        //}

        //[Theory]
        //[ClassData(typeof(CategoryIdTestData))]
        //public async Task Category_GetById_Success3(Guid id)
        //{
        //    _output.WriteLine($"Id: {id}");

        //    // Arrange

        //    CancellationToken token = new CancellationToken(false);

        //    Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
        //    Mock<IMapper> mapperMock = new Mock<IMapper>();

        //    var expected = _fixture.List.First(x => x.Id == id);

        //    categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

        //    CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

        //    // Act
        //    var result = await service.GetByIdAsync(id, token);

        //    // Assert
        //    result.ShouldNotBe(null);

        //    id.ShouldBe(result.Id);
        //    expected.Name.ShouldBe(result.Name);
        //    expected.CreatedAt.ShouldBe(result.CreatedAt);
        //    expected.IsActive.ShouldBe(result.IsActive);
        //    expected.ParentId.ShouldBe(result.ParentId);

        //    categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        //}

        //[Fact]
        //public async Task Category_GetById_Fail()
        //{
        //    // Arrange
        //    var id = Guid.NewGuid();
        //    _output.WriteLine($"Id: {id}");

        //    CancellationToken token = new CancellationToken(false);

        //    Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
        //    Mock<IMapper> mapperMock = new Mock<IMapper>();

        //    categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => null);

        //    CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

        //    // Act
        //    var result = await service.GetByIdAsync(id, token);

        //    // Assert
        //    result.ShouldBe(null);
        //    categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        //}
    }
}