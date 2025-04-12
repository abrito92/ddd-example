using ddd.Domain.Entities;

namespace ddd.Data.Interfaces
{
    public interface IEntityRepository
    {
        public Task<DomainEntity> GetEntity(int parameter);
    }
}
