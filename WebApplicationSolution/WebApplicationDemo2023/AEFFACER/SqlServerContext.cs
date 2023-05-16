using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationDemo2023.AEFFACER
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

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Article2> Article2s { get; set; } = null!;
        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Facture> Factures { get; set; } = null!;
        public virtual DbSet<LigneFacture> LigneFactures { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Yves\\github\\csharp2023\\MaPremiereSolution\\SqlFacture\\Facture2023.mdf;Integrated Security=True;Connect Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.Designation).HasMaxLength(255);

                entity.Property(e => e.Nom).HasMaxLength(255);

                entity.Property(e => e.Prix).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("FK_Article_Categorie");
            });

            modelBuilder.Entity<Article2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("article2");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasMaxLength(255)
                    .HasColumnName("nom");

                entity.Property(e => e.Prix)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prix");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("Categorie");

                entity.HasIndex(e => e.Nom, "UQ__Categori__C7D1C61E059F8D2B")
                    .IsUnique();

                entity.Property(e => e.Estactif)
                    .IsRequired()
                    .HasColumnName("estactif")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Adresse).HasMaxLength(50);

                entity.Property(e => e.Localite)
                    .HasMaxLength(50)
                    .HasColumnName("localite");

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Npa)
                    .HasMaxLength(50)
                    .HasColumnName("npa");

                entity.Property(e => e.Prenom).HasMaxLength(50);
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.ToTable("Facture");

                entity.Property(e => e.DateFacture).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Facture_fk0");
            });

            modelBuilder.Entity<LigneFacture>(entity =>
            {
                entity.ToTable("LigneFacture");

                entity.Property(e => e.PrixUnitaire).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.LigneFactures)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LigneFacture_fk1");

                entity.HasOne(d => d.Facture)
                    .WithMany(p => p.LigneFactures)
                    .HasForeignKey(d => d.FactureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LigneFacture_fk0");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("Utilisateur");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.MotDePasse).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
