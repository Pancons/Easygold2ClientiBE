
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Entities
{
    public class DbDatiCliente
    {
        /// <summary>
        /// ID del cliente.
        /// </summary>
        [Key]
        public int Dtc_IDCliente { get; set; }

        /// <summary>
        /// Nome della gioielleria del cliente.
        /// </summary>
        public string Dtc_Gioielleria { get; set; }

        /// <summary>
        /// Ragione sociale del cliente.
        /// </summary>
        public string Dtc_RagioneSociale { get; set; }

        /// <summary>
        /// Indirizzo del cliente.
        /// </summary>
        public string Dtc_Indirizzo { get; set; }

        /// <summary>
        /// CAP del cliente.
        /// </summary>
        public string Dtc_CAP { get; set; }

        /// <summary>
        /// Località del cliente.
        /// </summary>
        public string? Dtc_Localita { get; set; }

        /// <summary>
        /// Provincia del cliente.
        /// </summary>
        public string Dtc_Provincia { get; set; }

        /// <summary>
        /// Stato o regione del cliente.
        /// </summary>
        public string Dtc_StatoRegione { get; set; }

        /// <summary>
        /// Nazione del cliente.
        /// </summary>
        public string Dtc_Nazione { get; set; }

        /// <summary>
        /// Partita IVA del cliente.
        /// </summary>
        public string Dtc_PartitaIVA { get; set; }

        /// <summary>
        /// Codice fiscale del cliente.
        /// </summary>
        public string Dtc_CodiceFiscale { get; set; }

        /// <summary>
        /// Numero REA del cliente.
        /// </summary>
        public string Dtc_REA { get; set; }

        /// <summary>
        /// Capitale sociale del cliente.
        /// </summary>
        public decimal Dtc_CapitaleSociale { get; set; }

        /// <summary>
        /// Indica se la ragione sociale è principale.
        /// </summary>
        public bool Dtc_RagSocialePrincipale { get; set; }

        /// <summary>
        /// Indica se il cliente è annullato.
        /// </summary>
        public bool Dtc_Annullato { get; set; }

        /// <summary>
        /// PEC del cliente.
        /// </summary>
        public string Dtc_PEC { get; set; }

        /// <summary>
        /// Cognome del referente del cliente.
        /// </summary>
        public string Dtc_ReferenteCognome { get; set; }

        /// <summary>
        /// Nome del referente del cliente.
        /// </summary>
        public string Dtc_ReferenteNome { get; set; }

        /// <summary>
        /// Telefono del referente del cliente.
        /// </summary>
        public string Dtc_ReferenteTelefono { get; set; }

        /// <summary>
        /// Cellulare del referente del cliente.
        /// </summary>
        public string Dtc_ReferenteCellulare { get; set; }

        /// <summary>
        /// Email del referente del cliente.
        /// </summary>
        public string Dtc_ReferenteEmail { get; set; }

        /// <summary>
        /// Sito web del referente del cliente.
        /// </summary>
        public string Dtc_ReferenteWeb { get; set; }

        /// <summary>
        /// Ranking del cliente.
        /// </summary>
        public int Dtc_Ranking { get; set; }

        /// <summary>
        /// Valuta corrente del cliente
        /// </summary>
        public string Dtc_Valuta { get; }

        /// <summary>
        /// Numero Contratto 
        /// </summary>
        public string Dtc_NumeroContratto { get; }

    }
}
