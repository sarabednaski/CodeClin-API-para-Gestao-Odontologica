using AutoMapper;
using codeclin.Application.DTOs;
using codeclin.Domain.Entities;

namespace codeclin.MappingProfile
{
    public class MappingProfile : Profile   
    {
        public MappingProfile()
        {
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Dentista, DentistaDTO>().ReverseMap();
            CreateMap<Consulta, ConsultaDTO>().ReverseMap();
            CreateMap<Pagamento, PagamentoDTO>().ReverseMap();
        }
    }
}
