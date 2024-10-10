using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrensManager.Models;

namespace TrensManager.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey((data) => data.Id);
            builder.Property((data) => data.UserName).IsRequired().HasMaxLength(64);
            builder.Property((data) => data.UserPassword).IsRequired().HasMaxLength(64);
            builder.Property((data) => data.Roles).IsRequired();
        }
    }
}