using Watson.Adapter.SqlServer.Contexts;
using Watson.Application.Interfaces.Repositories;
using Watson.Core.Entities;

namespace Watson.Adapter.SqlServer.Repositories
{
	public class NoteImageRepository(ApplicationDbContext dbContext)
		: GenericRepository<NoteImage>(dbContext), INoteImageRepository
	{
	}
}
