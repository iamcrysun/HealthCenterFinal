using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    public class dbContext: DbContext // использовалось в лабораторных
    {
        #region Constructor
        public dbContext(DbContextOptions<dbContext>
        options)
        : base(options)
        { }
        #endregion
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.ID).IsRequired();
            });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasOne(d => d.Categories)
                .WithMany(p => p.Doctor)
                .HasForeignKey(d => d.CategoryID);
            });
        }
    }
}
