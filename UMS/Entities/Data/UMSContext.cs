using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UMS.Entities.Data
{
	public class UMSContext : DbContext
	{
        private readonly IConfiguration _configuration;

        public UMSContext(DbContextOptions<UMSContext> options, IConfiguration configuration)
        : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///you can defined connection here. Now we defined in program.cs
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///if you want customize table name
            //modelBuilder.Entity<User>().ToTable("tblUser");
        }

        //entities
        public DbSet<Users> Users { get; set; }
    }
}

