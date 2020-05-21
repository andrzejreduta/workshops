using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exercises._04_Collections
{
    public class AuthorizationManagerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly AuthorizationManager _authorizationManager;

        public AuthorizationManagerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _authorizationManager = new AuthorizationManager(_userRepositoryMock.Object);
        }
        
        [Fact]
        public void AccessIsAllowedIfUserHaveRequiredPermissions()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.GetPermissions(userId)).Returns(new[]
            {
                new Permission("A"),
                new Permission("B"),
                new Permission("C"),
                new Permission("D"),
                new Permission("F"),
                new Permission("G"),
                new Permission("H"),
            });
            _authorizationManager.CheckPermissions(userId, 
                    new Permission("A"),
                    new Permission("F"),
                    new Permission("H"))
                .Should().BeTrue();
        }

        [Fact]
        public void AccessIsDeniedIfUserDoesNotHaveRequiredPermissions()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.GetPermissions(userId)).Returns(new[]
            {
                new Permission("A"),
                new Permission("B"),
                new Permission("C"),
                new Permission("D"),
                new Permission("F"),
                new Permission("G"),
                new Permission("H"),
            });
            _authorizationManager.CheckPermissions(userId, 
                new Permission("A"),
                new Permission("E"))
                .Should().BeFalse();
        }
    }
}