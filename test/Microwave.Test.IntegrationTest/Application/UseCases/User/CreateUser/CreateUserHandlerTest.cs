using Microsoft.EntityFrameworkCore;
using Microwave.Application.UseCases.User.CreateUser;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;
using Microwave.Infrastructure.Services.Encryption;
using Microwave.Infrastructure.Services.Token;

namespace Microwave.Test.IntegrationTest.Application.UseCases.User.CreateUser
{
    public class CreateUserHandlerTest(CreateUserHandlerTestFixture fixture) : IClassFixture<CreateUserHandlerTestFixture>
    {
        private readonly CreateUserHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThrowUsernameInUseException))]
        [Trait("Integration/UseCase", "User - CreateUser")]
        public async Task ShouldThrowUsernameInUseException()
        {
            var user = _fixture.MakeUserEntity();
            var context = _fixture.MakeMicrowaveContext();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var encryptionService = new EncryptionService();
            var tokenService = new TokenService(_fixture.MakeConfiguration());

            var unitOfWork = new UnitOfWork(context);
            var repository = new UserRepository(context);

            var sut = new CreateUserHandler(
                userRepository: repository,
                encryptionService: encryptionService,
                tokenService: tokenService,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeCreateUserRequest(username: user.Username);
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UsernameInUseException>(act);
            Assert.Equal("username-in-use", exception.Code);
            Assert.Equal("Username já cadastrado para outro usuário", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldCreateUser))]
        [Trait("Integration/UseCase", "User - CreateUser")]
        public async Task ShouldCreateUser()
        {
            var context = _fixture.MakeMicrowaveContext();
            var encryptionService = new EncryptionService();
            var tokenService = new TokenService(_fixture.MakeConfiguration());
            var unitOfWork = new UnitOfWork(context);
            var repository = new UserRepository(context);

            var sut = new CreateUserHandler(
                userRepository: repository,
                encryptionService: encryptionService,
                tokenService: tokenService,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeCreateUserRequest();
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(response.Username, request.Username);

            var userDb = await context.Users.FirstOrDefaultAsync(x => x.Id == response.UserId);
            Assert.NotNull(userDb);
            Assert.Equal(response.Token, userDb?.Token);
            Assert.Equal(response.UserId, userDb?.Id);
            Assert.Equal(response.Username, userDb?.Username);
        }
    }
}
