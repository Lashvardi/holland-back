using doit.Models;
using Microsoft.EntityFrameworkCore;

namespace doit.Data;

public class DataContext : DbContext
{
    
    private readonly IConfiguration _configuration;
    
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
}