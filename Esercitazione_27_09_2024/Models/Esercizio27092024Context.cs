using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_27_09_2024.Models;

public partial class Esercizio27092024Context : DbContext
{
    public Esercizio27092024Context()
    {
    }

    public Esercizio27092024Context(DbContextOptions<Esercizio27092024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Libri> Libris { get; set; }

    public virtual DbSet<Prestito> Prestitos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-32\\SQLEXPRESS;Database=Esercizio27_09_2024;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libri>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libri__35A1EC8DF1B07980");

            entity.ToTable("Libri");

            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.StatoDisp)
                .HasDefaultValue(true)
                .HasColumnName("statoDisp");
            entity.Property(e => e.Titolo)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prestito>(entity =>
        {
            entity.HasKey(e => e.PrestitoId).HasName("PK__Prestito__740F9C28669DB064");

            entity.ToTable("Prestito");

            entity.Property(e => e.PrestitoId).HasColumnName("PrestitoID");

            entity.HasOne(d => d.LibroRifNavigation).WithMany(p => p.Prestitos)
                .HasForeignKey(d => d.LibroRif)
                .HasConstraintName("FK__Prestito__LibroR__403A8C7D");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Prestitos)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Prestito__Utente__3F466844");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__489EA72AA579AC83");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Email, "UQ__Utente__A9D10534ABC43620").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("UtenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
