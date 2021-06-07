using ABTestRealDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ABTestRealDB
{
    public class PGEFContext : DbContext
    {
        public DbSet<UserActivity> UserActivity { get; set; }

        public PGEFContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch
            {
                               
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (File.Exists("Logpass.ini"))
            {            
                var MyIni = new IniParser("Logpass.ini");
                string connection = "Host=localhost;Port=5432;Database=abtestreal;Username=" + MyIni.GetSetting("Psql", "Username") + ";Password=" + MyIni.GetSetting("Psql", "Password" );
                optionsBuilder.UseNpgsql(connection);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserActivity>().HasKey(p => new { p.Id });
            modelBuilder.Entity<UserActivity>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
