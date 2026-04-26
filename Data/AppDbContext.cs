using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Models; 

namespace ColegioSanJose.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ColegioSanJose> <Expedientes> { get; set; }
}