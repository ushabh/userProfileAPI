using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace userprofileAPI.Models;

public partial class ProfileDbContext : DbContext
{
    public ProfileDbContext()
    {
    }

    public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactRequest> ContactRequests { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:userprofiledb.database.windows.net,1433;Initial Catalog=profileDB;Persist Security Info=False;User ID=ushabh;Password=Password@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactR__3214EC0724420F4D");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNo).HasMaxLength(15);
            entity.Property(e => e.SubmittedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Expertise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Expertis__3214EC076DC3D078");

            entity.ToTable("Expertise");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
