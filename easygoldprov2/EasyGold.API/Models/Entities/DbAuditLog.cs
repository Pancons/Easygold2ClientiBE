using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Entities
{
    public class DbAuditLog
    {
        [Key]
        public int Log_Id { get; set; } // Chiave primaria
        public string Log_TableName { get; set; } // Nome della tabella
        public string Log_RecordId { get; set; } // ID del record modificato
        public string Log_ColumnName { get; set; } // Nome della colonna modificata
        public string? Log_OldValue { get; set; } // Valore precedente
        public string? Log_NewValue { get; set; } // Nuovo valore
        public DateTime Log_ChangeDate { get; set; } = DateTime.UtcNow; // Data modifica
        public string Log_User { get; set; } // Utente che ha effettuato la modifica    }
    }
}
