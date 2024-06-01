using Microsoft.EntityFrameworkCore;
using MWDotNetCore.NLayerDataAccess.Models;

namespace MWDotNetCore.NLayerDataAccess.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<BlogModel> Blogs { get; set; }
}
