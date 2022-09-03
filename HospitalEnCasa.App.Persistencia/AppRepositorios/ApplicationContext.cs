using Microsoft.EntityFrameworkCore;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<FamiliarDesignado> FamiliarDesignados { get; set; }
        public DbSet<Enfermero> Enfermeras { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        //public DbSet<TipoSigno> TipoSignos{ get; set; }
        public DbSet<SignoVital> SignoVitales { get; set; }
        public DbSet<SugerenciaDeCuidado> sugerenciaCuidados{ get; set; }
        public DbSet<Historico> Historias { get; set; }
        //public DbSet<Medico> Medicos { get; set; }
       // public DbContextOptionsBuilder OptionBuilder {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEnCasaDataP");
            }
        
        
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //llaves primarias de entidades
            modelBuilder.Entity<Historico>()
                .HasKey(b => b.Id);
                modelBuilder.Entity<Persona>()
                .HasKey(b => b.Id);
                modelBuilder.Entity<SignoVital>()
                .HasKey(b => b.Id);
                modelBuilder.Entity<SugerenciaDeCuidado>()
                .HasKey(b => b.Id);
                modelBuilder.Entity<Hogar>()
                .HasKey(b => b.Id);
                modelBuilder.Entity<Hospital>()
                .HasKey(b => b.Id);
                //relaciones uno a uno
                modelBuilder.Entity<Paciente>()
               .HasOne(a => a.SuFamiliarDesinado)
               .WithOne(b => b.SuFamiliar)
               .HasForeignKey<FamiliarDesignado>(b => b.IdFamiliar);
               modelBuilder.Entity<Paciente>()
               .HasOne(a => a.HistorialMedico)
               .WithOne(b => b.ElPaciente)
               .HasForeignKey<Historico>(b => b.IdPaciente);
               modelBuilder.Entity<Paciente>()
               .HasOne(a => a.SuHogar)
               .WithOne(b => b.ElPaciente)
               .HasForeignKey<Hogar>(b => b.IdPaciente);
               //uno a muchos
               modelBuilder.Entity<Persona>()
               .HasOne(a => a.SuGenero)
               .WithMany(b => b.LaPersona);
               modelBuilder.Entity<Enfermero>()
               .HasMany(c => c.Pacientes)
               .WithOne(e => e.SuEnfermero);
                modelBuilder.Entity<Paciente>()
               .HasMany(c => c.SignsVitales)
               .WithOne(e => e.ElPaciente);
               modelBuilder.Entity<Hospital>()
               .HasMany(c => c.Auxiliares)
               .WithOne(e => e.SuHospital);
               modelBuilder.Entity<Hospital>()
               .HasMany(c => c.ListaPersonalDeSalud)
               .WithOne(e => e.SuHospital);
               //muchos a muchos
               modelBuilder.Entity<Medico>()
               .HasMany(c => c.Pacientes)
               .WithMany(e => e.SusMedicos);
               //separacion de tablas
               modelBuilder.Entity<Medico>().ToTable("Medicos");
               modelBuilder.Entity<Enfermero>().ToTable("Enfermeras");
               modelBuilder.Entity<FamiliarDesignado>().ToTable("FamiliaresDesignados");
               modelBuilder.Entity<Paciente>().ToTable("Pacientes");
               modelBuilder.Entity<Auxiliar>().ToTable("Auxiliares");
               modelBuilder.Entity<PersonalDeSalud>().ToTable("PersonaldeSalud");
        }

/*       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Medico>().ToTable("Medicos");
          modelBuilder.Entity<Enfermero>().ToTable("Enfermeros");
          modelBuilder.Entity<FamiliarDesignado>().ToTable("FamiliaresDesignados");
          modelBuilder.Entity<Paciente>().ToTable("Pacientes");
      //    modelBuilder.Entity<Medico>().Property(e => e.Id).ValueGeneratedNever();
        }*/

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasKey(b => b.id)
                .HasName("PersonaId");
            modelBuilder.Entity<Persona>()
           .Property(e => e.nombre).HasColumnType("VARCHAR").HasMaxLength(250);
            //  modelBuilder.Entity<Persona>()
            //      .HasIndex(b => b.nombre)
            //      .IsUnique();
            base.OnModelCreating(modelBuilder);
        }*/

    }
}