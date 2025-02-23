using Microwave.Application.UseCases.User.CreateUser;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.User.CreateUser
{
    public class CreateUserHandlerTestFixture : FixtureBase
    {
        public CreateUserRequest MakeCreateUserRequest(
            string? username = null,
            string? password = null) => new(
                username: username ?? Faker.Internet.UserName(),
                password: password ?? Faker.Internet.Password());
    }
}
