// Nesta classe é feito o mapeamento das tabelas do banco de dados
// É nesta classe que são feitas configurações adicionais como definição de primaryKey, campo obrigatório ou não...

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrensManager.Models;

namespace TrensManager.Data.Map
{
    public class TrainMap : IEntityTypeConfiguration<TrainModel>
    {
        public void Configure(EntityTypeBuilder<TrainModel> builder)
        {
            builder.HasKey((data) => data.Id);
            builder.HasIndex(x => x.NumberOS).IsUnique();
            builder.Property((data) => data.NumberOS).IsRequired().HasMaxLength(64);
            builder.Property((data) => data.Origin).IsRequired().HasMaxLength(255);
            builder.Property((data) => data.Destination).IsRequired().HasMaxLength(255);
        }
    }
}
