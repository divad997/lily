using Internship.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Internship.Models
{
    public class Context : DbContext
    {
        public static ProjectConfiguration Configuration;
        public Context(DbContextOptions<Context> options, ProjectConfiguration configuration) : base(options)
		{
            if(configuration != null)
			{
				Context.Configuration = configuration;
			}
		}
        public Context()
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if(optionsBuilder.IsConfigured)
			{
				return;
			}
			optionsBuilder.UseSqlServer(Context.Configuration.DatabaseConfiguration.ConnectionString);
		}
    }
}