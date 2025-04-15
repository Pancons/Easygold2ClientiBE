using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models;
using EasyGold.API.Models.Entities;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DbCliente>().HasKey(c => c.Utw_IDClienteAuto);
            modelBuilder.Entity<DbUtente>().HasKey(u => u.Ute_IDUtente);
            modelBuilder.Entity<DbModuloEasygoldLang>().HasKey(m => m.Mdeid_ID); // Assuming Id is the primary key
            modelBuilder.Entity<DbModuloEasygold>().HasKey(m => m.Mde_IDAuto    ); // Assuming Id is the primary key
            modelBuilder.Entity<DbDatiCliente>().HasKey(d => d.Dtc_IDCliente); // Assuming Id is the primary key
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
    }
}
