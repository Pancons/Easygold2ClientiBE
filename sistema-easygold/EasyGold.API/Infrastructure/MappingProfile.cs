using AutoMapper;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Negozi;
using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Configurazioni;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Ruoli;
using EasyGold.API.Models.Utenti;

namespace EasyGold.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping da (DbCliente + DbDatiCliente) a ClienteDTO
            CreateMap<(DbCliente Cliente, DbDatiCliente? DatiCliente), ClienteDTO>()
                .ForMember(dest => dest.Utw_IDClienteAuto, opt => opt.MapFrom(src => src.Cliente.Utw_IDClienteAuto))
                .ForMember(dest => dest.Dtc_RagioneSociale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_RagioneSociale))
                .ForMember(dest => dest.Dtc_Gioielleria, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Gioielleria))
                .ForMember(dest => dest.Dtc_Referente, opt => opt.MapFrom(src => src.DatiCliente.Dtc_ReferenteNome + " " + src.DatiCliente.Dtc_ReferenteCognome))
                .ForMember(dest => dest.Dtc_Telefono, opt => opt.MapFrom(src => src.DatiCliente.Dtc_ReferenteTelefono))
                .ForMember(dest => dest.Dtc_Email, opt => opt.MapFrom(src => src.DatiCliente.Dtc_ReferenteEmail))
                .ForMember(dest => dest.Dtc_Stato, opt => opt.MapFrom(src => src.DatiCliente.Dtc_StatoRegione))
                .ForMember(dest => dest.Dtc_Citta, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Localita))
                .ForMember(dest => dest.Utw_Bloccato, opt => opt.MapFrom(src => src.Cliente.Utw_Blocco));

            // Mapping per ClienteDettaglioIntermedio -> ClienteDettaglioDTO
            CreateMap<ClienteDettaglioIntermedio, ClienteDettaglioDTO>()
                .ForMember(dest => dest.Utw_IDClienteAuto, opt => opt.Ignore()) 
                .ForMember(dest => dest.Dtc_RagioneSociale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_RagioneSociale))
                .ForMember(dest => dest.Dtc_Gioielleria, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Gioielleria))
                .ForMember(dest => dest.Dtc_Indirizzo, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Indirizzo))
                .ForMember(dest => dest.Dtc_Citta, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Localita))
                .ForMember(dest => dest.Dtc_CAP, opt => opt.MapFrom(src => src.DatiCliente.Dtc_CAP))
                .ForMember(dest => dest.Dtc_Provincia, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Provincia))
                .ForMember(dest => dest.Dtc_StatoRegione, opt => opt.MapFrom(src => src.DatiCliente.Dtc_StatoRegione))
                .ForMember(dest => dest.Dtc_Nazione, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Nazione))
                .ForMember(dest => dest.Dtc_PartitaIVA, opt => opt.MapFrom(src => src.DatiCliente.Dtc_PartitaIVA))
                .ForMember(dest => dest.Dtc_CodiceFiscale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_CodiceFiscale))
                .ForMember(dest => dest.Dtc_REA, opt => opt.MapFrom(src => src.DatiCliente.Dtc_REA))
                .ForMember(dest => dest.Dtc_CapitaleSociale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_CapitaleSociale))
                .ForMember(dest => dest.Dtc_PEC, opt => opt.MapFrom(src => src.DatiCliente.Dtc_PEC))
                .ForMember(dest => dest.Utw_DataAttivazione, opt => opt.MapFrom(src => src.Cliente.Utw_DataAttivazione))
                .ForMember(dest => dest.Utw_DataDisattivazione, opt => opt.MapFrom(src => src.Cliente.Utw_DataDisattivazione))
                .ForMember(dest => dest.Utw_Bloccato, opt => opt.MapFrom(src => src.Cliente.Utw_Blocco))
                .ForMember(dest => dest.Moduli, opt => opt.MapFrom(src => src.Moduli))
                .ForMember(dest => dest.Allegati, opt => opt.MapFrom(src => src.Allegati))
                .ForMember(dest => dest.Negozi, opt => opt.MapFrom(src => src.Negozi))
                // Campi di DbCliente mappati in ConfigurazioneDTO
                .ForMember(dest => dest.Configurazione, opt => opt.MapFrom(src => new ConfigurazioneDTO
                {
                    Utw_NegoziAttivabili = src.Cliente.Utw_NegoziAttivabili,
                    Utw_NegoziVirtuali = src.Cliente.Utw_NegoziVirtuali,
                    Utw_UtentiAttivi = src.Cliente.Utw_UtentiAttivi,
                    Utw_DataAttivazione = src.Cliente.Utw_DataAttivazione,
                    Utw_DataDisattivazione = src.Cliente.Utw_DataDisattivazione,
                    Utw_Blocco = src.Cliente.Utw_Blocco
                }));

            CreateMap<ClienteDettaglioDTO, DbCliente>()
                .ForMember(dest => dest.Utw_IDClienteAuto, opt => opt.Ignore()) 
                .ForMember(dest => dest.Utw_NomeConnessione, opt => opt.MapFrom(src => src.Dtc_RagioneSociale))
                .ForMember(dest => dest.Utw_DataAttivazione, opt => opt.MapFrom(src => src.Utw_DataAttivazione))
                .ForMember(dest => dest.Utw_DataDisattivazione, opt => opt.MapFrom(src => src.Utw_DataDisattivazione))
                .ForMember(dest => dest.Utw_NegoziAttivabili, opt => opt.MapFrom(src => src.Configurazione.Utw_NegoziAttivabili))
                .ForMember(dest => dest.Utw_NegoziVirtuali, opt => opt.MapFrom(src => src.Configurazione.Utw_NegoziVirtuali))
                .ForMember(dest => dest.Utw_UtentiAttivi, opt => opt.MapFrom(src => src.Configurazione.Utw_UtentiAttivi))
                .ForMember(dest => dest.Utw_Blocco, opt => opt.MapFrom(src => src.Utw_Bloccato));
                // Altri mapping

            CreateMap<ClienteDettaglioDTO, DbDatiCliente>()
                .ForMember(dest => dest.Dtc_IDCliente, opt => opt.MapFrom(src => src.Utw_IDClienteAuto))
                .ForMember(dest => dest.Dtc_RagioneSociale, opt => opt.MapFrom(src => src.Dtc_RagioneSociale))
                .ForMember(dest => dest.Dtc_Gioielleria, opt => opt.MapFrom(src => src.Dtc_Gioielleria))
                .ForMember(dest => dest.Dtc_Indirizzo, opt => opt.MapFrom(src => src.Dtc_Indirizzo))
                .ForMember(dest => dest.Dtc_CAP, opt => opt.MapFrom(src => src.Dtc_CAP))
                .ForMember(dest => dest.Dtc_Localita, opt => opt.MapFrom(src => src.Dtc_Citta))
                .ForMember(dest => dest.Dtc_Provincia, opt => opt.MapFrom(src => src.Dtc_Provincia))
                .ForMember(dest => dest.Dtc_StatoRegione, opt => opt.MapFrom(src => src.Dtc_StatoRegione))
                .ForMember(dest => dest.Dtc_Nazione, opt => opt.MapFrom(src => src.Dtc_Nazione))
                .ForMember(dest => dest.Dtc_PartitaIVA, opt => opt.MapFrom(src => src.Dtc_PartitaIVA))
                .ForMember(dest => dest.Dtc_CodiceFiscale, opt => opt.MapFrom(src => src.Dtc_CodiceFiscale))
                .ForMember(dest => dest.Dtc_REA, opt => opt.MapFrom(src => src.Dtc_REA))
                .ForMember(dest => dest.Dtc_CapitaleSociale, opt => opt.MapFrom(src => src.Dtc_CapitaleSociale))
                .ForMember(dest => dest.Dtc_PEC, opt => opt.MapFrom(src => src.Dtc_PEC))
                .ForMember(dest => dest.Dtc_ReferenteCognome, opt => opt.MapFrom(src => src.Dtc_ReferenteCognome))
                .ForMember(dest => dest.Dtc_ReferenteNome, opt => opt.MapFrom(src => src.Dtc_ReferenteNome))
                .ForMember(dest => dest.Dtc_ReferenteTelefono, opt => opt.MapFrom(src => src.Dtc_ReferenteTelefono))
                .ForMember(dest => dest.Dtc_ReferenteCellulare, opt => opt.MapFrom(src => src.Dtc_ReferenteCellulare))
                .ForMember(dest => dest.Dtc_ReferenteEmail, opt => opt.MapFrom(src => src.Dtc_ReferenteEmail))
                .ForMember(dest => dest.Dtc_ReferenteWeb, opt => opt.MapFrom(src => src.Dtc_ReferenteWeb))
                .ForMember(dest => dest.Dtc_Ranking, opt => opt.MapFrom(src => src.Dtc_Ranking));

            CreateMap<ModuloDTO, DbModuloCliente>()
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Mdc_IDModulo));

            CreateMap<AllegatoDTO, DbAllegato>()
                .ForMember(dest => dest.All_EntitaRiferimento, opt => opt.MapFrom(src => "Cliente"))
                .ForMember(dest => dest.All_RecordId, opt => opt.Ignore()); 

            CreateMap<NegozioDTO, DbNegozi>()
                .ForMember(dest => dest.Neg_RagioneSociale, opt => opt.MapFrom(src => src.Neg_RagioneSociale))
                .ForMember(dest => dest.Neg_NomeNegozio, opt => opt.MapFrom(src => src.Neg_NomeNegozio))
                .ForMember(dest => dest.Neg_DataAttivazione, opt => opt.MapFrom(src => src.Neg_DataAttivazione))
                .ForMember(dest => dest.Neg_DataDisattivazione, opt => opt.MapFrom(src => src.Neg_DataDisattivazione))
                .ForMember(dest => dest.Neg_Bloccato, opt => opt.MapFrom(src => src.Neg_Bloccato))
                .ForMember(dest => dest.Neg_Note, opt => opt.MapFrom(src => src.Neg_Note));

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
