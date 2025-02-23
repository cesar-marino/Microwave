using Microsoft.EntityFrameworkCore;
using Microwave.Application.UseCases.User.Authentication;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;
using Microwave.Infrastructure.Services.Encryption;
using Microwave.Infrastructure.Services.Token;

namespace Microwave.Test.IntegrationTest.Application.UseCases.User.Authentication
{
    public class AuthenticationHandlerTest(AuthenticationHandlerTestFixture fixture) : IClassFixture<AuthenticationHandlerTestFixture>
    {
        private readonly AuthenticationHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThrowNotFoundException))]
        [Trait("Integration/UseCase", "User - Authentication")]
        public async Task ShouldThrowNotFoundException()
        {
            var context = _fixture.MakeMicrowaveContext();
            var unitOfWork = new UnitOfWork(context);
            var repository = new UserRepository(context);
            var encryptionService = new EncryptionService();
            var tokenService = new TokenService(_fixture.MakeConfiguration());

            var sut = new AuthenticationHandler(
                userRepository: repository,
                encryptionService: encryptionService,
                tokenService: tokenService,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeAuthenticationRequest();
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Usuário não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowInvalidPasswordException))]
        [Trait("Integration/UseCase", "User - Authentication")]
        public async Task ShouldThrowInvalidPasswordException()
        {
            var encryptionService = new EncryptionService();
            var password = await encryptionService.EncyptAsync(_fixture.Faker.Internet.Password());
            var context = _fixture.MakeMicrowaveContext();
            var user = _fixture.MakeUserEntity(password: password);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context);
            var repository = new UserRepository(context);
            var tokenService = new TokenService(_fixture.MakeConfiguration());

            var sut = new AuthenticationHandler(
                userRepository: repository,
                encryptionService: encryptionService,
                tokenService: tokenService,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeAuthenticationRequest(username: user.Username);
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<InvalidPasswordException>(act);
            Assert.Equal("invalid-password", exception.Code);
            Assert.Equal("Senha incorreta", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnAuthenticatedUser))]
        [Trait("Integration/UseCase", "User - Authentication")]
        public async Task ShouldReturnAuthenticatedUser()
        {
            var encryptionService = new EncryptionService();
            var password = _fixture.Faker.Internet.Password();
            var encryptedPassword = await encryptionService.EncyptAsync(password);
            var user = _fixture.MakeUserEntity(password: encryptedPassword);
            var tokenService = new TokenService(_fixture.MakeConfiguration());

            var context = _fixture.MakeMicrowaveContext();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context);
            var repository = new UserRepository(context);

            var sut = new AuthenticationHandler(
                userRepository: repository,
                encryptionService: encryptionService,
                tokenService: tokenService,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeAuthenticationRequest(username: user.Username, password: password);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(user.Id, response.UserId);
            Assert.Equal(request.Username, response.Username);

            var userDb = await context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            Assert.NotNull(userDb);
            Assert.Equal(user.Id, userDb?.Id);
            Assert.Equal(request.Username, userDb?.Username);
            Assert.Equal(encryptedPassword, userDb?.Password);
            Assert.Equal(response.Token, userDb?.Token);
        }
    }
}
