
using System;

namespace EasyGold.API.Models.Entities
{
public class DbModuloCliente
    {
        /// <summary>
        /// ID del cliente associato al modulo.
        /// </summary>
        public int Mdc_IDCliente { get; set; }

        /// <summary>
        /// ID del modulo associato al cliente.
        /// </summary>
        public int Mdc_IDModulo { get; set; }

        /// <summary>
        /// Data di attivazione del modulo per il cliente.
        /// </summary>
        public DateTime Mdc_DataAttivazione { get; set; }

        /// <summary>
        /// Data di disattivazione del modulo per il cliente.
        /// </summary>
        public DateTime Mdc_DataDisattivazione { get; set; }

        /// <summary>
        /// Indica se il modulo è bloccato per il cliente.
        /// </summary>
        public bool Mdc_BloccoModulo { get; set; }

        /// <summary>
        /// Data e ora del blocco del modulo.
        /// </summary>
        public DateTime Mdc_DataOraBlocco { get; set; }

        /// <summary>
        /// Note aggiuntive sul modulo per il cliente.
        /// </summary>
        public string Mdc_Nota { get; set; }
    }
}
