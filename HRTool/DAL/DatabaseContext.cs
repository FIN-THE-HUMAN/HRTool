using HRTool.Models;
using Microsoft.EntityFrameworkCore;

namespace HRTool.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        
        public DbSet<SystemUser> Users { get; set; }
    }
}
