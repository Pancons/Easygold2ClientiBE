using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_idiomiScelti")]
    public class DbIdiomiScelti : BaseDbEntity
    {
        /// <summary>
        /// Identificativo univoco per l'idioma.
        /// </summary>
        [Key]
        public int Idm_IDAuto { get; set; }
        
        /// <summary>
        /// ID del cliente associato.
        /// </summary>
        public int Idm_IDCliente { get; set; }

        /// <summary>
        /// ID dell'idioma scelto per il cliente.
        /// </summary>
        public int Idm_IDIdioma { get; set; }

    }
}