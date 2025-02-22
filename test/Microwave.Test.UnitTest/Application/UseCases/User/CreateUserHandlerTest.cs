﻿using Microwave.Application.UseCases.User.CreateUser;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.User
{
    public class CreateUserHandlerTest : IClassFixture<CreateUserHandlerTestFixture>
    {
        private readonly CreateUserHandlerTestFixture _fixture;
        private readonly CreateUserHandler _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public CreateUserHandlerTest(CreateUserHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _userRepositoryMock = new();
            _sut = new(userRepository: _userRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCheckUsernameAsyncThrows))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldRethrowSameExceptionThatCheckUsernameAsyncThrows()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateUserRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }
    }
}
