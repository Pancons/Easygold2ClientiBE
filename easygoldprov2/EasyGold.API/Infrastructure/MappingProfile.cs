using AutoMapper;
using EasyGold.Web2.Models.Cliente.Allegati;
using EasyGold.Web2.Models.Cliente.ConfigProgramma;
using EasyGold.Web2.Models.Comune.GEO;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Comune.Valute;
using EasyGold.Web2.Models.Variabili;
using EasyGold.Web2.Models.Cliente.Entities.Allegati;
using EasyGold.Web2.Models.Cliente.Entities.ConfigProgramma;
using EasyGold.Web2.Models.Comune.Entities.GEO;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            MappingAllegati();
            MappingModuli();
            MappingUtenti();
            MappingValute();
           

            // Reverse Mapping
             CreateMap<DbUtente, UtenteDTO>().ReverseMap();
       
            CreateMap<DbAllegato, AllegatoDTO>().ReverseMap();
            CreateMap<DbRuolo, RuoloDTO>().ReverseMap();
            CreateMap<DbNazioni, NazioniDTO>().ReverseMap();
          
        }

       
        private void MappingModuli()
        {
            // Mapping tra DbModuloEasygold e ModuloDTO
            CreateMap<DbModuloEasygold, ModuloDTO>()
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Mde_IDAuto))
                .ForMember(dest => dest.Mde_CodEcomm, opt => opt.MapFrom(src => src.Mde_CodEcomm))
                .ForMember(dest => dest.Mde_Descrizione, opt => opt.MapFrom(src => src.Mde_Descrizione))
                .ForMember(dest => dest.Mde_DescrizioneEstesa, opt => opt.MapFrom(src => src.Mde_DescrizioneEstesa));

        }
        private void MappingAllegati()
        {
            CreateMap<AllegatoDTO, DbAllegato>()
                .ForMember(dest => dest.All_EntitaRiferimento, opt => opt.MapFrom(src => "Cliente"))
                .ForMember(dest => dest.All_RecordId, opt => opt.Ignore());
        }

        private void MappingValute()
        {
            CreateMap<DbValute, ValuteDTO>();

            CreateMap<ValuteDTO, DbValute>();
        }


        private void MappingUtenti()
        {

        }
    }
}

