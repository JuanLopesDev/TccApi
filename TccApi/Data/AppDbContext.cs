using Microsoft.EntityFrameworkCore;
using TccApi.Models;

namespace TccApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tcc> Tccs { get; set; }
}