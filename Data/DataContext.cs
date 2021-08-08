using Microsoft.EntityFrameworkCore;
using NVSTravelSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        

        public DbSet<Landmark> Landmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureModel(ModelBuilder builder)
        {
            builder.Entity<Landmark>(b => {
                b.HasKey(p => p.LandmarkId);
                b.Property(p => p.LandmarkName).HasMaxLength(256).IsRequired();                
                b.Property(p => p.Latitude).IsRequired();                
                b.Property(p => p.Longitude).IsRequired();                
                b.Property(p => p.PointOrder).IsRequired();
                b.Property(p => p.Address).IsRequired();
                b.Property(p => p.CreatedDate).IsRequired();
                b.Property(p => p.Distance).HasColumnType("decimal(18,3").IsRequired();                
            });  
        }
    }
}
