using AutoFixture;
using Moq;
using Shopping.Api.Controllers;
using Shopping.Api.Domain.Models;
using Shopping.Api.Domain.Repositories;
using Shopping.Api.Mappings;
using FluentAssertions;
using Xunit;

namespace Shopping.Api.Tests
{
    public class UserControllerTests
    {
        private Fixture _fixure;
        private Mock<IUserRepository> _userRepository;

        public UserControllerTests()
        {
            AutomapperMappings.Initialize();
            _fixure = new Fixture();

            _userRepository = new Mock<IUserRepository>();
        }

        private UserController CreateSut()
        {
            return new UserController(_userRepository.Object);
        }

        [Fact]
        public void MustReturnCorrectUser()
        {
            //Arrange
            var mockedUser = _fixure.Create<User>();

            _userRepository.Setup(g=> g.Get()).Returns(mockedUser);

            var controller = CreateSut();

            //Act 
            var result = controller.Get();

            //Assert
            mockedUser.Should().BeEquivalentTo(result);

        }
    }
}
