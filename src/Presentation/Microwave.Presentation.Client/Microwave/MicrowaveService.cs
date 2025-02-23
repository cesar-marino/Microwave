using Microwave.Presentation.Client.Models;

namespace Microwave.Presentation.Client.Microwave
{
    public class MicrowaveService : IMicrowaveService
    {
        public Task<List<ProgramModel>> GetListPrograms(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
