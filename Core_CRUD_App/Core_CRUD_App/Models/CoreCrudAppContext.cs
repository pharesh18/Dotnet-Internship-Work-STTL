using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core_CRUD_App.Models;

public partial class CoreCrudAppContext : DbContext
{
    public CoreCrudAppContext()
    {
    }

    public CoreCrudAppContext(DbContextOptions<CoreCrudAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
        //=> optionsBuilder.UseSqlServer("server=DESKTOP-LGBF31B\\SQLEXPRESS; database=Core_Crud_App; trusted_connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3213E83F3AB5B1B5");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(30)
                .HasColumnName("fname");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lname)
                .HasMaxLength(30)
                .HasColumnName("lname");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
