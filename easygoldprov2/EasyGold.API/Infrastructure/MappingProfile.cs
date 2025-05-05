using AutoMapper;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Ruoli;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Models.Valute;
using EasyGold.API.Models.Variabili;

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

