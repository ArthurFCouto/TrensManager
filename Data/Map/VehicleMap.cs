﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrensManager.Models;

namespace TrensManager.Data.Map
{
    public class VehicleMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasIndex(data => data.Code).IsUnique();
            builder.Property((data) => data.Code).IsRequired().HasMaxLength(64);
            builder.Property((data) => data.CreatedAt);
            builder.Property((data) => data.CreatedByUser);
            builder.HasKey((data) => data.Id);
            builder.HasOne((data) => data.Train).WithMany((data) => data.Vehicles).HasForeignKey((data) => data.TrainId);
            builder.Property((data) => data.TrainId);
            builder.Property((data) => data.Type).IsRequired();
            builder.Property((data) => data.UpdatedAt);
            builder.Property((data) => data.UpdatedByUser);
        }
    }
}
