using Microsoft.EntityFrameworkCore;
using Watson.Core.Common;
using Watson.Core.Entities;

namespace Watson.Adapter.SqlServer.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<ChatSession> ChatSessions { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        //public virtual DbSet<ChatCitation> ChatCitations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateUTC = DateTime.Now; // TODO: use date service
                        entry.Entity.CreatedBy = "TODO: User ID"; // TODO: User id
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDateUTC = DateTime.Now; // TODO: Use date service
                        entry.Entity.LastUpdatedBy = "TODO: User ID"; // TODO: User id
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
