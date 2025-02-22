using Microwave.Application.Services;
using Microwave.Application.UseCases.User.Commons;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;

namespace Microwave.Application.UseCases.User.CreateUser
{
    public class CreateUserHandler(
        IUserRepository userRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService,
        IUnitOfWork unitOfWork) : ICreateUserHandler
    {
        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var usernameInUse = await userRepository.CheckUsernameAsync(request.Username, cancellationToken);
            if (usernameInUse)
                throw new UsernameInUseException("Username já cadastrado para outro usuário");

            var passwordEncrypted = await encryptionService.EncyptAsync(request.Password, cancellationToken);

            var user = new UserEntity(
                username: request.Username,
                password: passwordEncrypted);

            var token = await tokenService.GenerateTokenAsync(
                id: user.Id,
                username: user.Username,
                cancellationToken);

            user.ChangeToken(token);
            await userRepository.InsertAsync(user, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return UserResponse.FromEntity(user);
        }
    }
}
