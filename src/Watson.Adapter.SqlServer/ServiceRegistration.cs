using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Watson.Adapter.SqlServer.Contexts;
using Watson.Adapter.SqlServer.Repositories;
using Watson.Application.Interfaces.Repositories;
using Watson.Application.Interfaces;
using Watson.Core.Ports;

namespace Watson.Adapter.SqlServer
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IChatSessionRepository, ChatSessionRepository>();
            #endregion
        }
    }

}
