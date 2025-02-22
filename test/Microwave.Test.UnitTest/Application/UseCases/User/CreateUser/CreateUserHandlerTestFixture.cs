using Microwave.Application.UseCases.User.CreateUser;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.User.CreateUser
{
    public class CreateUserHandlerTestFixture : FixtureBase
    {
        public CreateUserRequest MakeCreateUserRequest() => new(
            username: Faker.Internet.UserName(),
            password: Faker.Internet.Password());
    }
}
