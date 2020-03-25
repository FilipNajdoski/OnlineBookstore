using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book>Books {get;set;} //table name
        public DbSet<Category>Categories {get;set;} //table name
        public DbSet<Subcategory>Subcategories {get;set;} //table name
        public DbSet<Publisher>Publishers {get;set;} //table name
        public DbSet<Photo>Photos {get;set;} //table name
        public DbSet<User>Users {get;set;} //table name
        public DbSet<Author> Authors { get; set; } //table name
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
