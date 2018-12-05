using System;
using Microsoft.EntityFrameworkCore;
using SimpleAPIWithBackingSvc.Models;

namespace SimpleAPIWithBackingSvc.Repositories
{
    public partial class SimpleAPIContext : DbContext
    {
        public SimpleAPIContext()
        {
        }

        public SimpleAPIContext(DbContextOptions<SimpleAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<User> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // warning To protect potentially sensitive information in your connection string, you should move it out of source code.
                // See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
                var connection = Environment.GetEnvironmentVariable("SIMPLEAPI_DBCONN");
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ID).IsRequired();
            });

            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.HasOne(d => d.Blog)
            //         .WithMany(p => p.Post)
            //         .HasForeignKey(d => d.BlogId);
            // });
        }
    }
}