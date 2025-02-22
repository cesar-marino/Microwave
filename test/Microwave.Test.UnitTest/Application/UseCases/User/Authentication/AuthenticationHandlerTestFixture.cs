using Microwave.Application.UseCases.User.Authentication;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.User.Authentication
{
    public class AuthenticationHandlerTestFixture : FixtureBase
    {
        public AuthenticationRequest MakeAuthenticationRequest() => new(
                username: Faker.Internet.UserName(),
                password: Faker.Internet.Password());
    }
}
