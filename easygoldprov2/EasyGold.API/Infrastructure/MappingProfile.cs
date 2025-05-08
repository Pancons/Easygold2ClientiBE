using AutoMapper;
using EasyGold.API.Models.DTO.Allegati;
using EasyGold.API.Models.DTO.Moduli;
using EasyGold.API.Models.DTO.Nazioni;
using EasyGold.API.Models.DTO.Ruoli;
using EasyGold.API.Models.DTO.Utenti;
using EasyGold.API.Models.DTO.Valute;
using EasyGold.API.Models.DTO.Variabili;
using EasyGold.API.Models.Entities.Allegati;
using EasyGold.API.Models.Entities.Moduli;
using EasyGold.API.Models.Entities.Nazioni;
using EasyGold.API.Models.Entities.Ruoli;
using EasyGold.API.Models.Entities.Utenti;
using EasyGold.API.Models.Entities.Valute;

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

