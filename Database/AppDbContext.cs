﻿using Microsoft.EntityFrameworkCore;
using TestForServer.Models;

namespace TestForServer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("name=ConnectionStrings:DefaultConnection");
        }

        public DbSet<Text> Texts { get; set; }
    }
}
