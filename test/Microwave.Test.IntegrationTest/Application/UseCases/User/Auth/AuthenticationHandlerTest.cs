using Microwave.Application.UseCases.User.Authentication;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;
using Microwave.Infrastructure.Services.Encryption;
using Microwave.Infrastructure.Services.Token;

namespace Microwave.Test.IntegrationTest.Application.UseCases.User.Auth
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
    }
}
