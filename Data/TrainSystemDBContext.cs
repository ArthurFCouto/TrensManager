// Nesta classe é configurado o ORM da aplicação, utilizando o DbContext do EntityFrameworkCore.
// Através do DbContext é feita a configuração do bando de dados da aplicação.
// Cada DbSet será uma tabela no banco de dados, que utilizará o Model informado para a sua criação.
// OnModelCreating recebe as configuraçoes de cada tabela para criação, configuração esta feita no mapeamento.

using Microsoft.EntityFrameworkCore;
using TrensManager.Data.Map;
using TrensManager.Models;

namespace TrensManager.Data
{
    public class TrainSystemDBContext : DbContext
    {
        public TrainSystemDBContext(DbContextOptions<TrainSystemDBContext> options) : base(options) { }
        public DbSet<TrainModel> Train { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<VehicleModel> Vehicle { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainMap());
            modelBuilder.ApplyConfiguration(new  UserMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
