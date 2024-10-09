using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrensManager.Models;

namespace TrensManager.Data.Map
{
    public class VehicleMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey((data) => data.Id);
            builder.Property((data) => data.Type).IsRequired();
            builder.Property((data) => data.Code).IsRequired().HasMaxLength(64);
            builder.Property((data) => data.TrainId);
            builder.HasOne((data) => data.Train).WithMany((data) => data.Vehicles).HasForeignKey((data) => data.TrainId);
        }
    }
}
