namespace EasyGold.API.Models.DTO.Config
{
    public class ConfigResponseDTO
    {
        public ConfigVenditeDto Vendite { get; set; }
        public ConfigPagamentoDto Pagamento { get; set; }
        public ConfigProdottiDaParteDto ProdottiDaParte { get; set; }
        public ConfigCvenditaFornitoreDto CvenditaFornitore { get; set; }
        public ConfigRagioniSocialiDiverseDto Ragionisocialidiverse { get; set; }
        public ConfigAcquistiDto Acquisti { get; set; }
        public ConfigInventarioDto Inventario { get; set; }
        public ConfigTrasferimentoTraNegoziDto TrasferimentoTraNegozi { get; set; }
        public ConfigDistintaBaseDto DistintaBase { get; set; }
        public ConfigRiparazioniDto Riparazioni { get; set; }
        public ConfigRiparazioneDto Riparazione { get; set; }
        public ConfigDdtDto DDT { get; set; }
        public ConfigAutoFatturaDto AutoFattura { get; set; }
    }

    public class ConfigVenditeDto
    {
        public int Causale { get; set; }
        public int Listino { get; set; }
        public int TipoArrotondamento { get; set; }
        public int ValoreArrotondamento { get; set; }
        public bool AvvertiGiacenzaNegativa { get; set; }
        public bool StampaPrivacy { get; set; }
        public bool ClienteObbligatorio { get; set; }
        public string ImportoMaxContante { get; set; }
        public bool ImportoContantisuValoreProdotto { get; set; }
        public bool BottoneSuperamentoImportoContanti { get; set; }
        public string ImportoperRichiestaCodiceFiscale { get; set; }
        public int CodiceProdotto { get; set; }
        public int DescrizioneProdotto { get; set; }
        public bool ScontrinodiCortesia { get; set; }
        public bool OmettiNumeroMovimento { get; set; }
        public bool NoModalitàdiPagamento { get; set; }
    }

    public class ConfigPagamentoDto
    {
        public bool AbilitaValuteeCartediCredito { get; set; }
        public bool UtilizzaBuoniAccontidiTuttiiNegozi { get; set; }
    }

    public class ConfigProdottiDaParteDto
    {
        public int Causale { get; set; }
    }

    public class ConfigCvenditaFornitoreDto
    {
        public int NegozioAcquistiCVendita { get; set; }
        public int CausaleAcquistoCVendita { get; set; }
        public int CausaleAcquistodaCVendita { get; set; }
        public int CausaleResoCVenditaFornitore { get; set; }
    }

    public class ConfigRagioniSocialiDiverseDto
    {
        public int CausaleCaricoCVenditaFornitore { get; set; }
        public int CalcoloCostoProdotto { get; set; }
        public int CostoProdotto { get; set; }
        public int CostoProdottoIva { get; set; }
        public int CostoProdottoPercentuale { get; set; }
        public int CostoProdottoIvaPercentuale { get; set; }
        public int PercentualeSulCostoDelProdotto { get; set; }
        public int ComeCliente { get; set; }
        public int ComeFornitore { get; set; }
    }

    public class ConfigAcquistiDto
    {
        public int NuovoAcquisto { get; set; }
        public int NuovoOrdine { get; set; }
    }

    public class ConfigInventarioDto
    {
        public int RettificaPositiva { get; set; }
        public int RettificaNegativa { get; set; }
    }

    public class ConfigTrasferimentoTraNegoziDto
    {
        public int TrasferitoANegozio { get; set; }
        public int RicevutoDaNegozio { get; set; }
        public bool DdtObbligatorio { get; set; }
        public bool AbilitaTrasferimentiProdottiinCVendita { get; set; }
        public bool AbilitaTrasferimentifraSocietà { get; set; }
        public bool AbilitaConfermaRicezione { get; set; }
        public int CasualeRicezioneDaConfermare { get; set; }
    }

    public class ConfigDistintaBaseDto
    {
        public int CausaleScaricoSemilavorati { get; set; }
    }

    public class ConfigRiparazioniDto
    {
        public int Numerazione { get; set; }
        public bool InviareAObbligatorio { get; set; }
        public bool CostoSpedizioneObbligatorio { get; set; }
        public bool CostoRiparatoreObbligatorio { get; set; }
        public string Preventivo { get; set; }
    }

    public class ConfigRiparazioneDto
    {
        public string DataIntermediaUrgente { get; set; }
        public string DataPrevistaConsegna { get; set; }
        public bool AttivaGestioneQuestura { get; set; }
    }

    public class ConfigDdtDto
    {
        public string Prefisso { get; set; }
        public string Suffisso { get; set; }
    }

    public class ConfigAutoFatturaDto
    {
        public int ClienteAutofattura { get; set; }
        public string Prefisso { get; set; }
        public string Suffisso { get; set; }
    }


}
