using Microsoft.EntityFrameworkCore;

namespace Internship.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
		{
		}
        public Context()
        {
        }
        public DbSet<User> Users { get; set; }
    }
}