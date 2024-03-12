using IOTWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace IOTWebAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaving();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    private void OnBeforeSaving()
    {
        var entries = ChangeTracker.Entries();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.Entity is Gateway gateway)
            {
                if (entry.State == EntityState.Added)
                {
                    gateway.CreatedAt = utcNow;
                    gateway.UpdatedAt = utcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false; // Não altera o valor original de CreatedAt
                    gateway.UpdatedAt = utcNow;
                }
            }
        }
    }
    public DbSet<Gateway> Gateways { get; set; }
}