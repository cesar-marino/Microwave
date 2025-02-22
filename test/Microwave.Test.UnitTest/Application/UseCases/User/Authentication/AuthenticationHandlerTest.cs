using Microwave.Application.Services;
using Microwave.Application.UseCases.User.Authentication;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.User.Authentication
{
    public class AuthenticationHandlerTest : IClassFixture<AuthenticationHandlerTestFixture>
    {
        private readonly AuthenticationHandlerTestFixture _fixture;
        private readonly AuthenticationHandler _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IEncryptionService> _encryptionServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;

        public AuthenticationHandlerTest(AuthenticationHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _userRepositoryMock = new();
            _encryptionServiceMock = new();
            _tokenServiceMock = new();

            _sut = new(
                userRepository: _userRepositoryMock.Object,
                encryptionService: _encryptionServiceMock.Object,
                tokenService: _tokenServiceMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindByUsernameAsyncThrows))]
        [Trait("Unit/UseCase", "User - Authentication")]
        public async Task ShouldRethrowSameExceptionThatFindByUsernameAsyncThrows()
        {
            _userRepositoryMock
                .Setup(x => x.FindByUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException("Usuário não encontrado"));

            var request = _fixture.MakeAuthenticationRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Usuário não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCompareAsyncThrows))]
        [Trait("Unit/UseCase", "User - Authentication")]
        public async Task ShouldRethrowSameExceptionThatCompareAsyncThrows()
        {
            var user = _fixture.MakeUserEntity();
            _userRepositoryMock
                .Setup(x => x.FindByUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _encryptionServiceMock
                .Setup(x => x.CompareAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeAuthenticationRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowInvalidPasswordExceptionIfComapreAsyuncReturnsFalse))]
        [Trait("Unit/UseCase", "User - Authentication")]
        public async Task ShouldThrowInvalidPasswordExceptionIfComapreAsyuncReturnsFalse()
        {
            var user = _fixture.MakeUserEntity();
            _userRepositoryMock
                .Setup(x => x.FindByUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _encryptionServiceMock
                .Setup(x => x.CompareAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var request = _fixture.MakeAuthenticationRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<InvalidPasswordException>(act);
            Assert.Equal("invalid-password", exception.Code);
            Assert.Equal("Senha incorreta", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatGenerateTokenAsyncThrows))]
        [Trait("Unit/UseCase", "User - Authentication")]
        public async Task ShouldRethrowSameExceptionThatGenerateTokenAsyncThrows()
        {
            var user = _fixture.MakeUserEntity();
            _userRepositoryMock
                .Setup(x => x.FindByUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _encryptionServiceMock
                .Setup(x => x.CompareAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _tokenServiceMock
                .Setup(x => x.GenerateTokenAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeAuthenticationRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatUpdateAsyncThrows))]
        [Trait("Unit/UseCase", "User - Authentication")]
        public async Task ShouldRethrowSameExceptionThatUpdateAsyncThrows()
        {
            var user = _fixture.MakeUserEntity();
            _userRepositoryMock
                .Setup(x => x.FindByUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _encryptionServiceMock
                .Setup(x => x.CompareAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _userRepositoryMock
                .Setup(x => x.UpdateAsync(
                    It.IsAny<UserEntity>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeAuthenticationRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }
    }
}
