using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.Author)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.PublishedAt)
                      .IsRequired();

                entity.Property(e => e.Price)
                      .IsRequired()
                      .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedAt)
                      .IsRequired();
            });
        }
    }
}
