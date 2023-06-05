using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationPersonne.Models
{
    public partial class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personne> Personnes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>(entity =>
            {
                entity.ToTable("Personne");

                entity.Property(e => e.DateDeNaissance).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Utilisateur).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
