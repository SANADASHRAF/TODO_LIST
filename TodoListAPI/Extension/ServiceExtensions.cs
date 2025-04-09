using Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service;
using Service.Contracts;
using System.Text;

namespace TodoListAPI.Extension
{
    public static class ServiceExtensions 
    {
        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
              builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
          });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
         services.AddSqlServer<RepositoryContext>((configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
          services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
           services.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var secretKey = Environment.GetEnvironmentVariable("SECRET") ?? jwtSettings["Key"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }


    }
}
