using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Entities;



namespace EasyGold.API.Infrastructure
{
    /// <summary>
    /// ApplicationDbContext gestisce l'accesso al database e il tracciamento delle entità.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DbUtente> Utenti { get; set; }
        public DbSet<DbPwUtenti> PwUtenti { get; set; }
        public DbSet<DbGruppi> Gruppi { get; set; }
        public DbSet<DbNegozi> Negozi { get; set; }
        public DbSet<DbFiscalePostazioni> FiscalePostazioni { get; set; }
        public DbSet<DbFunzioni> Funzioni { get; set; }
        public DbSet<DbLettorePostazioni> LettorePostazioni { get; set; }
        public DbSet<DbModuliStampe> ModuliStampe { get; set; }
        public DbSet<DbPermessiGruppo> PermessiGruppo { get; set; }
        public DbSet<DbRegFiscale> RegFiscali { get; set; }
        public DbSet<DbSessioniEasyGold> SessioniEasyGold { get; set; }
        public DbSet<DbStampePostazioni> StampePostazioni { get; set; }
        public DbSet<DbTestataPostazioni> TestataPostazioni { get; set; }
        public DbSet<DbTipoPermesso> TipoPermesso { get; set; }
        public DbSet<DbTipoPw> TipoPw { get; set; }
        public DbSet<DbUtentePostazione> UtentePostazioni { get; set; }
        public DbSet<DbFunzioniLang> FunzioniLang { get; set; }
        public DbSet<DbGruppiLang> GruppiLang { get; set; }
        public DbSet<DbTestataPostazioniLang> TestataPostazioniLang { get; set; }
        public DbSet<DbTipoPermessoLang> TipoPermessoLang { get; set; }
        public DbSet<DbTipoPwLang> TipoPwLang { get; set; }
        public DbSet<DbUtenteNegozi> UtentiNegozi { get; set; }
        public DbSet<DbNazioneNegozio> NazioneNegozio { get; set; }
        public DbSet<DbNegoziAltro> NegoziAltro { get; set; }
        public DbSet<DbRefreshToken> RefreshTokens { get; set; }
        public DbSet<DbAuditLog> AuditLogs { get; set; }

        


        /// <summary>
        /// Configura le entità e le relazioni tra di esse.
        /// </summary>
        /// <param name="modelBuilder"></param>
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DbTestataPostazioniLang>().HasKey(e => new { e.tpoid_ISONum, e.tpoid_ID });
            modelBuilder.Entity<DbFunzioniLang>().HasKey(e => new { e.Ablid_ID, e.Ablid_ISONum });
            modelBuilder.Entity<DbGruppiLang>().HasKey(e => new { e.grpid_ISONum, e.grpid_ID });
            modelBuilder.Entity<DbTipoPermessoLang>().HasKey(e => new { e.Tpaid_ISONum, e.Tpaid_ID });
            modelBuilder.Entity<DbTipoPwLang>().HasKey(e => new { e.Tppid_ISONum, e.Tppid_ID });
           

            // Relazioni per DbUtente
            modelBuilder.Entity<DbUtente>()
                .HasKey(u => u.Ute_IDAuto);

            modelBuilder.Entity<DbUtente>()
                .HasOne(u => u.Gruppo)
                .WithMany(g => g.Utenti)
                .HasForeignKey(u => u.Ute_IDGruppo);

            modelBuilder.Entity<DbUtente>()
                .HasMany(u => u.PwUtenti)
                .WithOne(pw => pw.Utente)
                .HasForeignKey(pw => pw.Utp_IDUtente);

            modelBuilder.Entity<DbUtente>()
                .HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId);

            // Relazioni per DbUtenteNegozi
           
            modelBuilder.Entity<DbUtenteNegozi>()
                .HasOne(un => un.Utente)
                .WithMany(u => u.UtenteNegozi)
                .HasForeignKey(un => un.Utn_IDUtente);

            modelBuilder.Entity<DbUtenteNegozi>()
                .HasOne(un => un.Negozio)
                .WithMany()
                .HasForeignKey(un => un.Utn_IDNegozio);

            // Relazioni per DbLettorePostazioni
            modelBuilder.Entity<DbLettorePostazioni>()
                .HasOne(lp => lp.TestataPostazioni)
                .WithMany(tp => tp.LettorePostazioni)
                .HasForeignKey(lp => lp.Lpo_IDPostazione);

            // Relazioni per DbFiscalePostazioni
            modelBuilder.Entity<DbFiscalePostazioni>()
                .HasOne(fp => fp.TestataPostazioni)
                .WithMany(tp => tp.FiscalePostazioni)
                .HasForeignKey(fp => fp.Fpo_IDPostazione);

            modelBuilder.Entity<DbFiscalePostazioni>()
                .HasOne(fp => fp.RegFiscale)
                .WithMany()
                .HasForeignKey(fp => fp.Fpo_IDRegFiscale);

            // Relazioni per DbTestataPostazioni
            modelBuilder.Entity<DbTestataPostazioni>()
                .HasMany(tp => tp.StampePostazioni)
                .WithOne(sp => sp.TestataPostazioni)
                .HasForeignKey(sp => sp.Tpo_IDPostazione);

            // Relazioni per DbStampePostazioni
            modelBuilder.Entity<DbStampePostazioni>()
                .HasOne(sp => sp.ModuliStampe)
                .WithMany()
                .HasForeignKey(sp => sp.Tpo_IDStampa);

            // Relazioni per DbPwUtenti
            modelBuilder.Entity<DbPwUtenti>()
                .HasOne(pw => pw.TipoPw)
                .WithMany(tp => tp.PwUtenti)
                .HasForeignKey(pw => pw.Utp_TipoPw);

            // Relazioni per DbPermessiGruppo
            modelBuilder.Entity<DbPermessiGruppo>()
                .HasOne(pg => pg.Gruppi)
                .WithMany(g => g.PermessiGruppo)
                .HasForeignKey(pg => pg.Abg_IDGruppo);

            modelBuilder.Entity<DbPermessiGruppo>()
                .HasOne(pg => pg.Funzioni)
                .WithMany(f => f.PermessiGruppo)
                .HasForeignKey(pg => pg.Abg_IDFunzione);

            // Relazioni per DbFunzioniLang
            modelBuilder.Entity<DbFunzioniLang>()
                .HasOne(fl => fl.Funzione)
                .WithMany(f => f.FunzioniLang)
                .HasForeignKey(fl => fl.Ablid_ID);

            // Relazioni per DbGruppiLang
            modelBuilder.Entity<DbGruppiLang>()
                .HasOne(gl => gl.Gruppi)
                .WithMany()
                .HasForeignKey(gl => gl.grpid_ID);

            
            modelBuilder.Entity<DbNegozi>()
                .HasKey(negozio => negozio.Neg_id);

            modelBuilder.Entity<DbNegozi>()
                .HasMany(negozio => negozio.Utenti)
                .WithOne(utenteNegozio => utenteNegozio.Negozio)
                .HasForeignKey(utenteNegozio => utenteNegozio.Utn_IDNegozio);

            // Relazioni per DbNegoziAltro
            modelBuilder.Entity<DbNegoziAltro>()
                .HasKey(negoziAltro => negoziAltro.Nea_IDAuto);

            
            
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
