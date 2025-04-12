using AutoMapper;
using ddd.Application.Dtos.Requests;
using ddd.Application.Dtos.Responses;
using ddd.Domain.Entities;

namespace ddd.Application.Mappers
{
    public class EntityDtoMapper : Profile
    {
        public EntityDtoMapper()
        {
            CreateMap<EntityRequest, DomainEntity>();
            CreateMap<DomainEntity, EntityResponse>();            
        }
    }
}
