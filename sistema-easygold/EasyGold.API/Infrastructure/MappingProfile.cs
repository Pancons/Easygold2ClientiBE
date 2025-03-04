using AutoMapper;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Clients;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Roles;
using EasyGold.API.Models.Users;

namespace EasyGold.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbCliente, ClienteDTO>().ReverseMap();
            CreateMap<DbUtente, UtenteDTO>().ReverseMap();
            CreateMap<DbModuloEasygoldLang, ModuloDTO>().ReverseMap();
            CreateMap<DbModuloCliente, ModuloDTO>().ReverseMap();
            CreateMap<DbModuloEasygold, ModuloDTO>().ReverseMap();
            CreateMap<DbDatiCliente, ClienteDettaglioDTO>().ReverseMap();
            CreateMap<DbAllegato, AllegatoDTO>().ReverseMap();
            CreateMap<DbRuolo, RuoloDTO>().ReverseMap();
          
        }
    }
}
