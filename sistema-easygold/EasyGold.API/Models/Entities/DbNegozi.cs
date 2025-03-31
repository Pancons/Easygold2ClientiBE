namespace EasyGold.API.Models.Entities
{
    using Swashbuckle.AspNetCore.Annotations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbNegozi
    {   
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Neg_id { get; set; }

        public int Neg_IDCliente { get; set; }
        
        /// <summary>
        /// Ragione sociale del negozio
        /// </summary>
        /// 
        [Required]
        [StringLength(255)]
        public string Neg_RagioneSociale { get; set; }


        /// <summary>
        /// Nome del negozio
        /// </summary>
        /// 
        [Required]
        [StringLength(255)]
        public string Neg_NomeNegozio { get; set; }


        /// <summary>
        ///  Data di attivazione
        /// </summary>
        /// 
        [DataType(DataType.Date)]
        public DateTime Neg_DataAttivazione { get; set; }

         /// <summary>
        /// Data disattivazione del negozio
        /// </summary>
        /// 
        [DataType(DataType.Date)]
        public DateTime Neg_DataDisattivazione { get; set; }

        /// <summary>
        /// Negozio è bloccato
        /// </summary>
        /// 
        public bool Neg_Bloccato { get; set; }


        /// <summary>
        /// Data e ora blocco del negozio
        /// </summary>
        /// 
        [DataType(DataType.DateTime)]
        public DateTime Neg_DataOraBlocco { get; set; }


        /// <summary>
        /// Nota sul negozio
        /// </summary>
        /// 
        [StringLength(500)]
        public string Neg_Note { get; set; }
    }
}