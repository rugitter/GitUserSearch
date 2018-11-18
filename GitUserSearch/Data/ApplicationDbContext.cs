using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitUserSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace GitUserSearch.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<GitUser> GitUsers { get; set; }
        public DbSet<UserSearch> UserSearches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GitUser>().ToTable("GitHubUser");
            builder.Entity<UserSearch>().ToTable("UserSearch");

            //    //builder.Entity<GitUser>().HasKey(x => new { x.Id });
        }
    }
}

