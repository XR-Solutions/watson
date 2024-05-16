using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Watson.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Watson - REST Api",
                    Description = "The backend REST Api for the Watson Mixed Reality app",
                    Contact = new OpenApiContact
                    {
                        Name = "XR Solutions",
                    },
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access certain resources. " +
                    "To get a token you can use the login endpoint from the account controller.",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }
        public static void AddCorsExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("AllowedOrigins").Value.Split(';');

            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            }));
        }

        public static void AddVersioningPrefix(this IServiceCollection services)
        {
            // Adds prefix to all controllers. Example version 1.0: -> /api/v1.0/users
            services.AddControllersWithViews(options =>
            {
                options.UseGeneralRoutePrefix("api/v{version:apiVersion}");
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                // Specify the default API Version. ApiVersion.Default -> 1.0
                options.DefaultApiVersion = ApiVersion.Default;
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Return supported API versions under a particular endpoint
                options.ReportApiVersions = true;
            });
        }
    }
}
