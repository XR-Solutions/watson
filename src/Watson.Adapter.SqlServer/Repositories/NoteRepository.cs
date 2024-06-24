using Watson.Adapter.SqlServer.Contexts;
using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Adapter.SqlServer.Repositories
{
	public class NoteRepository(ApplicationDbContext dbContext)
		: GenericRepository<Note>(dbContext), INoteRepository
	{
	}
}
