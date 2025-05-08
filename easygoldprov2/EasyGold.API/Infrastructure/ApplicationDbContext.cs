using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models;
using EasyGold.API.Models.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities.Allegati;
using EasyGold.API.Models.Entities.Config;
using EasyGold.API.Models.Entities.Moduli;
using EasyGold.API.Models.Entities.Nazioni;
using EasyGold.API.Models.Entities.NumeriRegIVA;
using EasyGold.API.Models.Entities.RegIVA;
using EasyGold.API.Models.Entities.Ruoli;
using EasyGold.API.Models.Entities.Utenti;
using EasyGold.API.Models.Entities.Valute;

namespace EasyGold.API.Infrastructure
{
    /// <summary>
    /// ApplicationDbContext gestisce l'accesso al database e il tracciamento delle entità.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DbUtente> Utenti { get; set; }
        public DbSet<DbModuloEasygoldLang> ModuloEasygoldLang { get; set; }
        public DbSet<DbModuloEasygold> ModuloEasygold { get; set; }
        public DbSet<DbRuolo> Ruoli { get; set; }
        public DbSet<DbAllegato> Allegati { get; set; }
        public DbSet<DbNegozi> Negozi { get; set; }
        public DbSet<DbNazioni> Nazioni { get; set; }
        public DbSet<DbValute> Valute { get; set; }
        public DbSet<DbAuditLog> AuditLogs { get; set; }

        // --- AGGIUNTA: Nuovi DbSet richiesti ---
        public DbSet<DbRegistroIVA> RegistriIVA { get; set; }
        public DbSet<DbNumeriRegIVA> NumeriRegIVA { get; set; }
        public DbSet<DbConfig> Configurazioni { get; set; }
        public DbSet<DbConfigLang> ConfigLag { get; set; }

        /// <summary>
        /// Configura le entità e le relazioni tra di esse.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<DbUtente>().HasKey(u => u.Ute_IDUtente);
            modelBuilder.Entity<DbModuloEasygoldLang>().HasKey(m => m.Mdeid_IDAuto);
            modelBuilder.Entity<DbModuloEasygold>().HasKey(m => m.Mde_IDAuto);
            modelBuilder.Entity<DbNazioni>().HasKey(n => n.Ntn_ISO1);
            modelBuilder.Entity<DbValute>().HasKey(v => v.Val_id);

            modelBuilder.Entity<DbUtente>()
            .HasOne(u => u.Ruolo)
            .WithMany()
            .HasForeignKey(u => u.Ute_IDRuolo);
        }

        /// <summary>
        /// Configura le opzioni del contesto, come il logging dei dati sensibili.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public Task<int> SaveChangesAsync()
        {
            var auditEntries = new List<DbAuditLog>();
            var changeTracker = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);

            foreach (var entry in changeTracker)
            {
                string tableName = entry.Entity.GetType().Name;
                string recordId = GetPrimaryKeyValue(entry);

                DateTime changeDate = DateTime.UtcNow;
                foreach (var prop in entry.Properties)
                {
                    if (entry.State == EntityState.Modified && prop.IsModified)
                    {
                        auditEntries.Add(new DbAuditLog
                        {
                            Log_TableName = tableName,
                            Log_RecordId = recordId,
                            Log_ColumnName = prop.Metadata.Name,
                            Log_OldValue = prop.OriginalValue?.ToString(),
                            Log_NewValue = prop.CurrentValue?.ToString(),
                            Log_ChangeDate = changeDate,
                            Log_User = "Sistema"
                        });
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        auditEntries.Add(new DbAuditLog
                        {
                            Log_TableName = tableName,
                            Log_RecordId = recordId,
                            Log_ColumnName = "RecordDeleted",
                            Log_OldValue = "EXISTING",
                            Log_NewValue = "DELETED",
                            Log_ChangeDate = changeDate,
                            Log_User = "Sistema"
                        });
                    }
                }
            }

            if (auditEntries.Any())
            {
                AuditLogs.AddRange(auditEntries);
            }

            var result = base.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Ottiene il valore della chiave primaria per una determinata entità.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns>Valore della chiave primaria come stringa.</returns>
        private string GetPrimaryKeyValue(EntityEntry entry)
        {
            var entityType = this.Model.FindEntityType(entry.Entity.GetType());
            var primaryKey = entityType.FindPrimaryKey();
            var keyValues = primaryKey.Properties
                .Select(p => entry.OriginalValues[p.Name]?.ToString())
                .ToArray();

            return string.Join(";", keyValues);
        }
    }
}
