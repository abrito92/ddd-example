using ddd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ddd.Data.Mappers
{
    public class EntityMapper : IEntityTypeConfiguration<DomainEntity>
    {
        public void Configure(EntityTypeBuilder<DomainEntity> modelBuilder)
        {

        }
    }
}
