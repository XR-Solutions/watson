using Microsoft.EntityFrameworkCore;
using Watson.Core.Common;

namespace Watson.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        // TODO: place DbSets here

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
