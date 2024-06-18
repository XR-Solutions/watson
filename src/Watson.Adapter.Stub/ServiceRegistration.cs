using Microsoft.Extensions.DependencyInjection;
using Watson.Adapter.Stub.Repositories;
using Watson.Core.Ports;

namespace Watson.Adapter.Stub
{
	internal class ServiceRegistration
	{
		public static void AddAdapterStubs(IServiceCollection services)
		{
			services.AddSingleton<INoteRepository, NoteRepositoryStub>();
		}
	}
}
