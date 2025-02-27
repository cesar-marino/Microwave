﻿using Microwave.Application.Services;
using Microwave.Application.UseCases.User.Commons;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;

namespace Microwave.Application.UseCases.User.Authentication
{
    public class AuthenticationHandler(
        IUserRepository userRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService,
        IUnitOfWork unitOfWork) : IAuthenticationHandler
    {
        public async Task<UserResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.FindByUsernameAsync(request.Username, cancellationToken);
            var passwordIsvalid = await encryptionService.CompareAsync(
                request.Password,
                user.Password,
                cancellationToken);

            if (!passwordIsvalid)
                throw new InvalidPasswordException("Senha incorreta");

            var token = await tokenService.GenerateTokenAsync(user.Id, user.Username, cancellationToken);
            user.ChangeToken(token);

            await userRepository.UpdateAsync(user, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return UserResponse.FromEntity(user);
        }
    }
}
