using Microsoft.EntityFrameworkCore;
using Moment3.Models;
using System;
using System.Collections.Generic;

namespace Moment3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<CD> CDs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Artist>().HasKey(a => a.Id);
            modelBuilder.Entity<Artist>().Property(a => a.Id).ValueGeneratedOnAdd();
           
            modelBuilder.Entity<CD>().HasKey(a => a.Id);
            modelBuilder.Entity<CD>().Property(a => a.Id).ValueGeneratedOnAdd();
        }
            

    }

}
