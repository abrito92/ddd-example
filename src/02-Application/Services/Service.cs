using AutoMapper;
using ddd.Application.Dtos.Responses;
using ddd.Application.Interfaces;
using ddd.Data.Interfaces;

namespace ddd.Application.Services
{
    public class Service : IService
    {
        private readonly IEntityRepository _interfaceRepository;
        private IMapper _mapper;
        
        public Service(IEntityRepository interfaceRepository, IMapper mapper)
        {
            _interfaceRepository = interfaceRepository;
            _mapper = mapper;    
        }

        public async Task<EntityResponse> GetEntity(int parameter)
        {
            var entity = _interfaceRepository.GetEntity(parameter);
            var response = _mapper.Map<EntityResponse>(entity);
            throw new NotImplementedException();
        }
    }
}
