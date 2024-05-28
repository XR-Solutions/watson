using Microsoft.EntityFrameworkCore;
using Watson.Adapter.SqlServer.Contexts;
using Watson.Application.Interfaces.Repositories;
using Watson.Core.Entities;

namespace Watson.Adapter.SqlServer.Repositories
{
    public class ChatSessionRepository : GenericRepository<ChatSession>, IChatSessionRepository
    {
        private readonly DbSet<ChatSession> _chatSessions;

        public ChatSessionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _chatSessions = dbContext.Set<ChatSession>();
        }
    }
}
