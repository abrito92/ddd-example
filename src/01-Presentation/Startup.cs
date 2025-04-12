using ddd.IoC;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ddd.Api
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder => builder
                                      .WithOrigins(
                                        "https://pmais-development.p4ed.com"
                                      )
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            services.AddControllers();
            services.AddServices(configuration);

            services.AddSwaggerGen(settings =>
            {
                settings.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                });
            });

            //autenticacao nova
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {

                    options.Authority = configuration["AUTHORITY"];

                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateAudience = false,                 
                        ValidateIssuer = true,
                        ValidIssuer = configuration["ISSUER"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero

                    };
                });
                
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddHealthChecks();
			
            return services;
        }

        public static WebApplication Configure(this WebApplication app)
        {
            app.UseCors("AllowSpecificOrigins");

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.DocumentTitle = "Poliedro - Example API";
            });

            app.UseHttpsRedirection();
            app.UseMiddleware<ControllerHandler.ControllerHandler>();
            app.MapHealthChecks("/api/health-check");
			
            app.MapControllers();

            return app;
        }
    }
}
