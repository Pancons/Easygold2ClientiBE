using AutoMapper;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Negozi;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Configurazioni;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Ruoli;
using EasyGold.API.Models.StatiCliente;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Models.Valute;
using EasyGold.API.Models.Variabili;

namespace EasyGold.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingClienti();
            MappingAllegati();
            MappingNegozi();
            MappingModuli();
            MappingUtenti();
            MappingValute();
            MappingValoriTabelle();

            // Reverse Mapping
            CreateMap<DbDatiCliente, ClienteDettaglioDTO>().ReverseMap();
            CreateMap<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<Tuple<DbModuloEasygold, DbModuloCliente>>? Moduli), ClienteDettaglioDTO>().ReverseMap();

            CreateMap<DbModuloEasygold, ModuloClienteDTO>().ReverseMap();
            CreateMap<DbModuloCliente, ModuloClienteDTO>().ReverseMap();
            CreateMap<DbAllegato, AllegatoDTO>().ReverseMap();
            CreateMap<DbRuolo, RuoloDTO>().ReverseMap();
            CreateMap<UtenteDTO, DbUtente>().ReverseMap();
            CreateMap<DbNazioni, NazioniDTO>().ReverseMap();
            CreateMap<DbStatoCliente, StatoClienteDTO>().ReverseMap();

        }

        private void MappingClienti()
        {
            CreateMap<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<Tuple<DbModuloEasygold, DbModuloCliente>>? Moduli, List<DbAllegato>? Allegati, List<DbNegozi>? Negozi, DbNazioni? Nazione, DbValute? Valuta, DbStatoCliente? StatoCliente), ClienteDettaglioDTO>()
                .ForMember(dest => dest.Utw_IDClienteAuto, opt => opt.MapFrom(src => src.Cliente.Utw_IDClienteAuto))
                .ForMember(dest => dest.Dtc_RagioneSociale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_RagioneSociale))
                .ForMember(dest => dest.Dtc_Gioielleria, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Gioielleria))
                .ForMember(dest => dest.Dtc_Indirizzo, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Indirizzo))
                .ForMember(dest => dest.Dtc_Citta, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Citta))
                .ForMember(dest => dest.Dtc_CAP, opt => opt.MapFrom(src => src.DatiCliente.Dtc_CAP))
                .ForMember(dest => dest.Dtc_Provincia, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Provincia))
                .ForMember(dest => dest.Dtc_StatoRegione, opt => opt.MapFrom(src => src.DatiCliente.Dtc_StatoRegione))
                .ForMember(dest => dest.Dtc_Nazione, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Nazione))
                .ForMember(dest => dest.Dtc_PartitaIVA, opt => opt.MapFrom(src => src.DatiCliente.Dtc_PartitaIVA))
                .ForMember(dest => dest.Dtc_CodiceFiscale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_CodiceFiscale))
                .ForMember(dest => dest.Dtc_REA, opt => opt.MapFrom(src => src.DatiCliente.Dtc_REA))
                .ForMember(dest => dest.Dtc_CapitaleSociale, opt => opt.MapFrom(src => src.DatiCliente.Dtc_CapitaleSociale))
                .ForMember(dest => dest.Dtc_PEC, opt => opt.MapFrom(src => src.DatiCliente.Dtc_PEC))
                .ForMember(dest => dest.Dtc_Ranking, opt => opt.MapFrom(src => src.DatiCliente.Dtc_Ranking))
                .ForMember(dest => dest.Moduli, opt => opt.MapFrom(src => src.Moduli))
                .ForMember(dest => dest.Allegati, opt => opt.MapFrom(src => src.Allegati ?? new List<DbAllegato>())) // Nella lista clienti gli allegati non servono, quindi restituisco un array vuoto
                .ForMember(dest => dest.Negozi, opt => opt.MapFrom(src => src.Negozi ?? new List<DbNegozi>())) // Nella lista clienti i negozi non servono, quindi restituisco un array vuoto
                .ForMember(dest => dest.Nazione, opt => opt.MapFrom(src => src.Nazione))
                // Campi di DbCliente mappati in ConfigurazioneDTO
                .ForMember(dest => dest.Configurazione, opt => opt.MapFrom(src => new ConfigurazioneDTO
                {
                    Utw_NegoziAttivabili = src.Cliente.Utw_NegoziAttivabili,
                    Utw_NegoziVirtuali = src.Cliente.Utw_NegoziVirtuali,
                    Utw_UtentiAttivi = src.Cliente.Utw_UtentiAttivi,
                    Utw_Postazioni = src.Cliente.Utw_Postazioni,
                    Utw_DataAttivazione = src.Cliente.Utw_DataAttivazione,
                    Utw_DataDisattivazione = src.Cliente.Utw_DataDisattivazione,
                    Utw_IdStatoCliente = src.Cliente.Utw_IdStatoCliente,
                    Utw_IDValuta = src.DatiCliente.Dtc_IDValuta,
                    Utw_NumeroContratto = src.DatiCliente.Dtc_NumeroContratto
                }))
                .ForPath(dest => dest.Configurazione.Valuta, opt => opt.MapFrom(src => src.Valuta))
                .ForPath(dest => dest.Configurazione.StatoCliente, opt => opt.MapFrom(src => src.StatoCliente));

            CreateMap<ClienteDettaglioDTO, DbCliente>()
                .ForMember(dest => dest.Utw_IDClienteAuto, opt => opt.Ignore())
                .ForMember(dest => dest.Utw_NomeConnessione, opt => opt.MapFrom(src => src.Dtc_RagioneSociale))
                .ForMember(dest => dest.Utw_DataAttivazione, opt => opt.MapFrom(src => src.Configurazione.Utw_DataAttivazione))
                .ForMember(dest => dest.Utw_DataDisattivazione, opt => opt.MapFrom(src => src.Configurazione.Utw_DataDisattivazione))
                .ForMember(dest => dest.Utw_NegoziAttivabili, opt => opt.MapFrom(src => src.Configurazione.Utw_NegoziAttivabili))
                .ForMember(dest => dest.Utw_NegoziVirtuali, opt => opt.MapFrom(src => src.Configurazione.Utw_NegoziVirtuali))
                .ForMember(dest => dest.Utw_UtentiAttivi, opt => opt.MapFrom(src => src.Configurazione.Utw_UtentiAttivi))
                .ForMember(dest => dest.Utw_Postazioni, opt => opt.MapFrom(src => src.Configurazione.Utw_Postazioni))
                .ForMember(dest => dest.Utw_IdStatoCliente, opt => opt.MapFrom(src => src.Configurazione.Utw_IdStatoCliente));
            // Altri mapping

            CreateMap<ClienteDettaglioDTO, DbDatiCliente>()
                .ForMember(dest => dest.Dtc_IDCliente, opt => opt.MapFrom(src => src.Utw_IDClienteAuto))
                .ForMember(dest => dest.Dtc_RagioneSociale, opt => opt.MapFrom(src => src.Dtc_RagioneSociale))
                .ForMember(dest => dest.Dtc_Gioielleria, opt => opt.MapFrom(src => src.Dtc_Gioielleria))
                .ForMember(dest => dest.Dtc_Indirizzo, opt => opt.MapFrom(src => src.Dtc_Indirizzo))
                .ForMember(dest => dest.Dtc_CAP, opt => opt.MapFrom(src => src.Dtc_CAP))
                .ForMember(dest => dest.Dtc_Citta, opt => opt.MapFrom(src => src.Dtc_Citta))
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
                .ForMember(dest => dest.Dtc_Ranking, opt => opt.MapFrom(src => src.Dtc_Ranking))
                .ForMember(dest => dest.Dtc_IDValuta, opt => opt.MapFrom(src => src.Configurazione != null ? src.Configurazione.Utw_IDValuta : (int?)null))
                .ForMember(dest => dest.Dtc_NumeroContratto, opt => opt.MapFrom(src => src.Configurazione != null ? src.Configurazione.Utw_NumeroContratto : null));


            CreateMap<DbDatiCliente, ClienteDettaglioDTO>()
                .ForMember(dest => dest.Configurazione, opt => opt.MapFrom(src => new ConfigurazioneDTO
                {
                    Utw_IDValuta = src.Dtc_IDValuta,
                    Utw_NumeroContratto = src.Dtc_NumeroContratto
                }));
        }
        private void MappingNegozi()
        {
            CreateMap<DbNegozi, NegozioDTO>()
            .ForMember(dest => dest.Neg_id, opt => opt.MapFrom(src => src.Neg_id))
            .ForMember(dest => dest.Neg_RagioneSociale, opt => opt.MapFrom(src => src.Neg_RagioneSociale))
            .ForMember(dest => dest.Neg_NomeNegozio, opt => opt.MapFrom(src => src.Neg_NomeNegozio))
            .ForMember(dest => dest.Neg_DataAttivazione, opt => opt.MapFrom(src => src.Neg_DataAttivazione))
            .ForMember(dest => dest.Neg_DataDisattivazione, opt => opt.MapFrom(src => src.Neg_DataDisattivazione))
            .ForMember(dest => dest.Neg_Bloccato, opt => opt.MapFrom(src => src.Neg_Bloccato))
            .ForMember(dest => dest.Neg_DataOraBlocco, opt => opt.MapFrom(src => src.Neg_DataOraBlocco))
            .ForMember(dest => dest.Neg_Note, opt => opt.MapFrom(src => src.Neg_Note));

            CreateMap<NegozioDTO, DbNegozi>()
                .ForMember(dest => dest.Neg_RagioneSociale, opt => opt.MapFrom(src => src.Neg_RagioneSociale))
                .ForMember(dest => dest.Neg_NomeNegozio, opt => opt.MapFrom(src => src.Neg_NomeNegozio))
                .ForMember(dest => dest.Neg_DataAttivazione, opt => opt.MapFrom(src => src.Neg_DataAttivazione))
                .ForMember(dest => dest.Neg_DataDisattivazione, opt => opt.MapFrom(src => src.Neg_DataDisattivazione))
                .ForMember(dest => dest.Neg_Bloccato, opt => opt.MapFrom(src => src.Neg_Bloccato))
                .ForMember(dest => dest.Neg_DataOraBlocco, opt => opt.MapFrom(src => src.Neg_DataOraBlocco))
                .ForMember(dest => dest.Neg_Note, opt => opt.MapFrom(src => src.Neg_Note));
        }
        private void MappingModuli()
        {
            // Mapping tra DbModuloEasygold e ModuloDTO
            CreateMap<DbModuloEasygold, ModuloDTO>()
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Mde_IDAuto))
                .ForMember(dest => dest.Mde_CodEcomm, opt => opt.MapFrom(src => src.Mde_CodEcomm))
                .ForMember(dest => dest.Mde_Descrizione, opt => opt.MapFrom(src => src.Mde_Descrizione))
                .ForMember(dest => dest.Mde_DescrizioneEstesa, opt => opt.MapFrom(src => src.Mde_DescrizioneEstesa));

            // Mapping tra DbModuloEasygold e ModuloDTO
            CreateMap<DbModuloEasygold, ModuloClienteDTO>()
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Mde_IDAuto))
                .ForMember(dest => dest.Mde_CodEcomm, opt => opt.MapFrom(src => src.Mde_CodEcomm))
                .ForMember(dest => dest.Mde_Descrizione, opt => opt.MapFrom(src => src.Mde_Descrizione))
                .ForMember(dest => dest.Mde_DescrizioneEstesa, opt => opt.MapFrom(src => src.Mde_DescrizioneEstesa));

            CreateMap<Tuple<DbModuloEasygold, DbModuloCliente>, ModuloClienteDTO>()
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Item1.Mde_IDAuto))
                .ForMember(dest => dest.Mde_CodEcomm, opt => opt.MapFrom(src => src.Item1.Mde_CodEcomm))
                .ForMember(dest => dest.Mde_Descrizione, opt => opt.MapFrom(src => src.Item1.Mde_Descrizione))
                .ForMember(dest => dest.Mde_DescrizioneEstesa, opt => opt.MapFrom(src => src.Item1.Mde_DescrizioneEstesa))
                .ForMember(dest => dest.Mdc_DataAttivazione, opt => opt.MapFrom(src => src.Item2.Mdc_DataAttivazione))
                .ForMember(dest => dest.Mdc_DataDisattivazione, opt => opt.MapFrom(src => src.Item2.Mdc_DataDisattivazione))
                .ForMember(dest => dest.Mdc_BloccoModulo, opt => opt.MapFrom(src => src.Item2.Mdc_BloccoModulo))
                .ForMember(dest => dest.Mdc_DataOraBlocco, opt => opt.MapFrom(src => src.Item2.Mdc_DataOraBlocco))
                .ForMember(dest => dest.Mdc_Nota, opt => opt.MapFrom(src => src.Item2.Mdc_Nota))
                .ForMember(dest => dest.Mdc_Selezionato, opt => opt.MapFrom(src => (src.Item2.Mdc_IDCliente != null && src.Item2.Mdc_IDCliente > 0 && src.Item2.Mdc_DataDisattivazione == null)));

            CreateMap<ModuloClienteDTO, (DbModuloEasygold, DbModuloCliente)>()
                .ForMember(dest => dest.Item1, opt => opt.MapFrom(src => new DbModuloEasygold
                {
                    Mde_IDAuto = src.Mdc_IDModulo,
                    Mde_CodEcomm = src.Mde_CodEcomm,
                    Mde_Descrizione = src.Mde_Descrizione,
                    Mde_DescrizioneEstesa = src.Mde_DescrizioneEstesa
                }))
                .ForMember(dest => dest.Item2, opt => opt.MapFrom(src => new DbModuloCliente
                {
                    Mdc_IDModulo = src.Mdc_IDModulo,
                    Mdc_DataAttivazione = src.Mdc_DataAttivazione,
                    Mdc_DataDisattivazione = src.Mdc_DataDisattivazione,
                    Mdc_BloccoModulo = src.Mdc_BloccoModulo,
                    Mdc_DataOraBlocco = src.Mdc_DataOraBlocco,
                    Mdc_Nota = src.Mdc_Nota,
                    Mdc_IDCliente = (src.Mdc_Selezionato ? -1 : 0)
                }));


            CreateMap<ModuloClienteDTO, DbModuloCliente>()
                .ForMember(dest => dest.Mdc_IDAuto, opt => opt.Ignore()) // ID gestito dal database
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Mdc_IDModulo))
                .ForMember(dest => dest.Mdc_DataAttivazione, opt => opt.MapFrom(src => src.Mdc_DataAttivazione))
                .ForMember(dest => dest.Mdc_DataDisattivazione, opt => opt.MapFrom(src => src.Mdc_DataDisattivazione))
                .ForMember(dest => dest.Mdc_BloccoModulo, opt => opt.MapFrom(src => src.Mdc_BloccoModulo))
                .ForMember(dest => dest.Mdc_DataOraBlocco, opt => opt.MapFrom(src => src.Mdc_DataOraBlocco))
                .ForMember(dest => dest.Mdc_Nota, opt => opt.MapFrom(src => src.Mdc_Nota));

            // Mapping tra ModuloDTO e ModuloIntermedio
            CreateMap<ModuloClienteDTO, ModuloIntermedio>().ReverseMap();

            // Mapping tra ModuloIntermedio e DbModuloEasygold
            CreateMap<ModuloIntermedio, DbModuloEasygold>()
                .ForMember(dest => dest.Mde_IDAuto, opt => opt.MapFrom(src => src.Mde_IDAuto))
                .ForMember(dest => dest.Mde_CodEcomm, opt => opt.MapFrom(src => src.Mde_CodEcomm))
                .ForMember(dest => dest.Mde_Descrizione, opt => opt.MapFrom(src => src.Mde_Descrizione))
                .ForMember(dest => dest.Mde_DescrizioneEstesa, opt => opt.MapFrom(src => src.Mde_DescrizioneEstesa))
                .ReverseMap();

            CreateMap<ModuloIntermedio, DbModuloCliente>()
                .ForMember(dest => dest.Mdc_IDModulo, opt => opt.MapFrom(src => src.Mde_IDAuto))
                .ForMember(dest => dest.Mdc_DataAttivazione, opt => opt.MapFrom(src => src.Mdc_DataAttivazione)) // ✅ Usa valore di default
                .ForMember(dest => dest.Mdc_DataDisattivazione, opt => opt.MapFrom(src => src.Mdc_DataDisattivazione)) // ✅ Usa valore di default
                .ForMember(dest => dest.Mdc_BloccoModulo, opt => opt.MapFrom(src => src.Mdc_BloccoModulo))
                .ForMember(dest => dest.Mdc_DataOraBlocco, opt => opt.MapFrom(src => src.Mdc_DataOraBlocco)) // ✅ Usa valore minimo per evitare null
                .ForMember(dest => dest.Mdc_Nota, opt => opt.MapFrom(src => src.Mdc_Nota))
                .ReverseMap();

            // **Mapping delle liste**
            CreateMap<List<ModuloClienteDTO>, List<ModuloIntermedio>>().ConvertUsing(src => src.Select(x => new ModuloIntermedio
            {
                Mde_CodEcomm = x.Mde_CodEcomm ?? "",
                Mde_Descrizione = x.Mde_Descrizione,
                Mde_DescrizioneEstesa = x.Mde_DescrizioneEstesa,
                Mdc_DataAttivazione = x.Mdc_DataAttivazione,
                Mdc_DataDisattivazione = x.Mdc_DataDisattivazione,
                Mdc_BloccoModulo = x.Mdc_BloccoModulo,
                Mdc_DataOraBlocco = x.Mdc_DataOraBlocco,
                Mdc_Nota = x.Mdc_Nota ?? ""
            }).ToList());

            CreateMap<List<ModuloIntermedio>, List<ModuloClienteDTO>>().ConvertUsing(src => src.Select(x => new ModuloClienteDTO
            {
                Mde_CodEcomm = x.Mde_CodEcomm,
                Mde_Descrizione = x.Mde_Descrizione,
                Mde_DescrizioneEstesa = x.Mde_DescrizioneEstesa,
                Mdc_DataAttivazione = x.Mdc_DataAttivazione,
                Mdc_DataDisattivazione = x.Mdc_DataDisattivazione,
                Mdc_BloccoModulo = x.Mdc_BloccoModulo,
                Mdc_DataOraBlocco = x.Mdc_DataOraBlocco,
                Mdc_Nota = x.Mdc_Nota,
                Mdc_Selezionato = true
            }).ToList());

            CreateMap<List<DbModuloEasygold>, List<ModuloDTO>>().ConvertUsing(src => src.Select(x => new ModuloDTO
            {
                Mdc_IDModulo = x.Mde_IDAuto,
                Mde_CodEcomm = x.Mde_CodEcomm,
                Mde_Descrizione = x.Mde_Descrizione,
                Mde_DescrizioneEstesa = x.Mde_DescrizioneEstesa,
            }).ToList());

            CreateMap<List<ModuloDTO>, List<DbModuloEasygold>>().ConvertUsing(src => src.Select(x => new DbModuloEasygold
            {
                Mde_IDAuto = x.Mdc_IDModulo,
                Mde_CodEcomm = x.Mde_CodEcomm,
                Mde_Descrizione = x.Mde_Descrizione,
                Mde_DescrizioneEstesa = x.Mde_DescrizioneEstesa,
            }).ToList());
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

        private void MappingValoriTabelle()
        {
            CreateMap<DbValoriTabelle, ValoriTabelleDTO>()
            .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.rowId))
            .ForMember(dest => dest.LstDescription, opt => opt.MapFrom(src => src.lst_description))
            .ForMember(dest => dest.LstItemType, opt => opt.MapFrom(src => src.lst_itemType))
            .ReverseMap();

            CreateMap<DbValoriTabelleLang, ValoriTabelleLangDTO>()
                .ForMember(dest => dest.RowId, opt => opt.MapFrom(src => src.rowId))
                .ForMember(dest => dest.LstlItemId, opt => opt.MapFrom(src => src.lstl_itemId))
                .ForMember(dest => dest.LstlLanguageId, opt => opt.MapFrom(src => src.lstl_languageId))
                .ForMember(dest => dest.LstlDescription, opt => opt.MapFrom(src => src.lstl_description))
                .ReverseMap();
        }

        private void MappingUtenti()
        {

        }
    }
}

