using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options) // primary constructor syntax instead of defining separate constructor
{
    public DbSet<AppUser> Users { get; set; }
}