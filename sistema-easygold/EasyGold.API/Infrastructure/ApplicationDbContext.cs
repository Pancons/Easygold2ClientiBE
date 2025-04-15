using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models;
using EasyGold.API.Models.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace EasyGold.API.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DbCliente> Clienti { get; set; }
        public DbSet<DbUtente> Utenti { get; set; }
        public DbSet<DbModuloEasygoldLang> ModuloEasygoldLang { get; set; }
        public DbSet<DbModuloCliente> ModuloClienti { get; set; }
        public DbSet<DbModuloEasygold> ModuloEasygold { get; set; }
        public DbSet<DbDatiCliente> DatiClienti { get; set; }
        public DbSet<DbRuolo> Ruoli { get; set; }
        public DbSet<DbAllegato> Allegati { get; set; }
        public DbSet<DbNegozi> Negozi { get; set; }
        public DbSet<DbNazioni> Nazioni { get; set; }
        public DbSet<DbValute> Valute { get; set; }
        public DbSet<DbStatoCliente> StatiCliente { get; set; }

        // Utilizzata per tracciare tutte le modifiche ai record del DB
        public DbSet<DbAuditLog> AuditLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(t => typeof(BaseDbEntity).IsAssignableFrom(t.ClrType)))
            {
                var builder = modelBuilder.Entity(entityType.ClrType);

                builder.Property("rowcreated_at")
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAdd();

                builder.Property("rowupdated_at")
                    .ValueGeneratedNever();

                builder.Property("rowdeleted_at")
                    .ValueGeneratedNever();

                // Filtro sui record cancellati logicamente
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Call(
                    typeof(EF), nameof(EF.Property), new[] { typeof(DateTime?) },
                    parameter, Expression.Constant("rowdeleted_at"));

                var body = Expression.Equal(property, Expression.Constant(null));
                var lambda = Expression.Lambda(body, parameter);

                builder.HasQueryFilter(lambda);

            }

            modelBuilder.Entity<DbCliente>().HasKey(c => c.Utw_IDClienteAuto);
            modelBuilder.Entity<DbUtente>().HasKey(u => u.Ute_IDUtente);
            modelBuilder.Entity<DbModuloEasygoldLang>().HasKey(m => m.Mdeid_IDAuto); // Assuming Id is the primary key
            modelBuilder.Entity<DbModuloEasygold>().HasKey(m => m.Mde_IDAuto    ); // Assuming Id is the primary key
            modelBuilder.Entity<DbDatiCliente>().HasKey(d => d.Dtc_IDDatiCliente); // Assuming Id is the primary key
            modelBuilder.Entity<DbNazioni>().HasKey(n => n.Naz_id);
            modelBuilder.Entity<DbValute>().HasKey(v => v.Val_id);

            modelBuilder.Entity<DbModuloCliente>()
                .HasOne(mc => mc.Cliente)
                .WithMany(c => c.ModuliClienti)
                .HasForeignKey(mc => mc.Mdc_IDCliente);

            modelBuilder.Entity<DbModuloCliente>()
                .HasOne(mc => mc.Modulo)
                .WithMany(m => m.ModuliClienti)
                .HasForeignKey(mc => mc.Mdc_IDModulo);

            modelBuilder.Entity<DbUtente>()
                .HasOne(u => u.Ruolo)
                .WithMany()
                .HasForeignKey(u => u.Ute_IDRuolo);
        }

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

                        // Se Entity è derivata da BaseDbEntity, viene aggiornata la data ultima modifica del record
                        if (entry.Entity is BaseDbEntity entity)
                            entity.rowupdated_at = changeDate;
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

                        // Se Entity è derivata da BaseDbEntity, viene aggiornata la data ultima modifica del record
                        if (entry.Entity is BaseDbEntity entity)
                        {
                            entity.rowdeleted_at = changeDate;
                            entry.State = EntityState.Modified;
                        }
                    }
                }
            }

            // Salva le modifiche e registra il log
            if (auditEntries.Any())
            {
                AuditLogs.AddRange(auditEntries);
            }

            var result = base.SaveChangesAsync();
            return result;
        }
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
