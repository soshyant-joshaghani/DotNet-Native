using DotnetNative.Modules.Apps.Sample;
using DotnetNative.Modules.Base.Users;
using Microsoft.EntityFrameworkCore;

namespace DotnetNative.Core.Db;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Note> Notes => Set<Note>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
