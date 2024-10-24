using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TrensManager.Data;
using TrensManager.Enums;
using TrensManager.Repositories;
using TrensManager.Repositories.Interface;

namespace TrensManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen((data) =>
            {
                data.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainsManager", Version = "v1" });
                data.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                data.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddAuthentication((data) =>
            {
                data.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                data.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer((dataJwt) =>
                {
                    dataJwt.RequireHttpsMetadata = false;
                    dataJwt.SaveToken = true;
                    dataJwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization((options) =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("Role", UserRoles.User.ToString()));
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role", UserRoles.Admin.ToString()));
            });

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TrainSystemDBContext>(
                    (options) => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );

            builder.Services.AddScoped<ITrainRepository, TrainRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // Inserido ap�s a configura��o do JWT
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
