using Castle.Components.DictionaryAdapter.Xml;
using Microwave.Application.Services;
using Microwave.Application.UseCases.User.CreateUser;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.User
{
    public class CreateUserHandlerTest : IClassFixture<CreateUserHandlerTestFixture>
    {
        private readonly CreateUserHandlerTestFixture _fixture;
        private readonly CreateUserHandler _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IEncryptionService> _encryptionServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public CreateUserHandlerTest(CreateUserHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _userRepositoryMock = new();
            _encryptionServiceMock = new();
            _tokenServiceMock = new();
            _unitOfWorkMock = new();

            _sut = new(
                userRepository: _userRepositoryMock.Object,
                encryptionService: _encryptionServiceMock.Object,
                tokenService: _tokenServiceMock.Object,
                unitOfWork: _unitOfWorkMock.Object);
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

        [Fact(DisplayName = nameof(ShouldThrowUsernameInUseExceptionIfCheckUsernameAsyncReturnsTrue))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldThrowUsernameInUseExceptionIfCheckUsernameAsyncReturnsTrue()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var request = _fixture.MakeCreateUserRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UsernameInUseException>(act);
            Assert.Equal("username-in-use", exception.Code);
            Assert.Equal("Username já cadastrado para outro usuário", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatEncryptAsyncThrows))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldRethrowSameExceptionThatEncryptAsyncThrows()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _encryptionServiceMock
                .Setup(x => x.EncyptAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateUserRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatGenerateTokenAsyncThrows))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldRethrowSameExceptionThatGenerateTokenAsyncThrows()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _encryptionServiceMock
                .Setup(x => x.EncyptAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync("");

            _tokenServiceMock
                .Setup(x => x.GenerateTokenAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateUserRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatInsertAsyncThrows))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldRethrowSameExceptionThatInsertAsyncThrows()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _encryptionServiceMock
                .Setup(x => x.EncyptAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync("");

            _tokenServiceMock
                .Setup(x => x.GenerateTokenAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync("");

            _userRepositoryMock
                .Setup(x => x.InsertAsync(
                    It.IsAny<UserEntity>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateUserRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCommitAsyncThrows))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldRethrowSameExceptionThatCommitAsyncThrows()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _encryptionServiceMock
                .Setup(x => x.EncyptAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync("");

            _tokenServiceMock
                .Setup(x => x.GenerateTokenAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync("");

            _unitOfWorkMock
                .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateUserRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfUserIsSuccessfullyAdded))]
        [Trait("Unit/UseCase", "User - CreateUser")]
        public async Task ShouldReturnTheCorrectResponseIfUserIsSuccessfullyAdded()
        {
            _userRepositoryMock
                .Setup(x => x.CheckUsernameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var password = _fixture.Faker.Internet.Password();
            _encryptionServiceMock
                .Setup(x => x.EncyptAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(password);

            var token = _fixture.Faker.Random.Guid().ToString();
            _tokenServiceMock
                .Setup(x => x.GenerateTokenAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(token);

            var request = _fixture.MakeCreateUserRequest();
            var response = await _sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(token, response.Token);
            Assert.Equal(request.Username, response.Username);
        }
    }
}
