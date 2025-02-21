﻿using Microwave.Application.UseCases.HeatingProgram.Commons;
using Microwave.Domain.Repositories;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandler(IHeatingProgramRepository heatingProgramRepository) : IUpdateHeatingProgramHandler
    {
        public async Task<HeatingProgramResponse> Handle(UpdateHeatingProgramRequest request, CancellationToken cancellationToken)
        {
            await heatingProgramRepository.FindAsync(request.HeatingProgramId, cancellationToken);
            throw new NotImplementedException();
        }
    }
}
