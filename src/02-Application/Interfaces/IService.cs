using ddd.Application.Dtos.Responses;

namespace ddd.Application.Interfaces
{
    public interface IService
    {
        public Task<EntityResponse> GetEntity(int application_id);
    }
}
