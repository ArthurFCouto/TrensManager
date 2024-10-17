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
            builder.Property((data) => data.CreatedAt);
            builder.Property((data) => data.CreatedByUserID);
            builder.Property((data) => data.Destination).IsRequired().HasMaxLength(255);
            builder.HasKey((data) => data.Id);
            builder.HasIndex(x => x.OSNumber).IsUnique();
            builder.Property((data) => data.OSNumber).IsRequired().HasMaxLength(64);
            builder.Property((data) => data.Origin).IsRequired().HasMaxLength(255);
            builder.Property((data) => data.UpdatedAt);
            builder.Property((data) => data.UpdatedByUserID);
            builder.HasOne((data) => data.User).WithMany((data) => data.Trains).HasForeignKey((data) => data.UserID);
            builder.Property((data) => data.UserID);
        }
    }
}
