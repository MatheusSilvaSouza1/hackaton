using Domain;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        public virtual DbSet<Medico> Medicos => Set<Medico>();
        public virtual DbSet<Usuario> Usuarios => Set<Usuario>();
        public virtual DbSet<Consulta> Consultas => Set<Consulta>();
        public virtual DbSet<HorarioDisponivel> HorarioDisponiveis => Set<HorarioDisponivel>();
    }
}