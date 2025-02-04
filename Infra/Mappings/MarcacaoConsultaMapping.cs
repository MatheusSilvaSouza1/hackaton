using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Domain.Consulta>
    {
        public void Configure(EntityTypeBuilder<Domain.Consulta> builder)
        {
            builder.HasKey(e => e.Id);  // Define explicitamente a chave primária

            // Defina nomes para as colunas (opcional)
            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();            
        }
    }
}
