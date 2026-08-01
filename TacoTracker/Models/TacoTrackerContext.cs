using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TacoTracker.Models;

public partial class TacoTrackerContext : DbContext
{
    public TacoTrackerContext()
    {
    }

    public TacoTrackerContext(DbContextOptions<TacoTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guess> Guesses { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<RolesType> RolesTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tacotracker;Username=tacouser;Password=tacopass");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Guess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("guesses_pkey");

            entity.ToTable("guesses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actual_date");
            entity.Property(e => e.GuessedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("guessed_date");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Guesses)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guesses_userid_fkey");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("locations_pkey");

            entity.ToTable("locations");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("location_id");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .HasColumnName("location_name");
            entity.Property(e => e.LocationZip)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("location would never have leading zero")
                .HasColumnName("location_zip");
        });

        modelBuilder.Entity<RolesType>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_types_pkey");

            entity.ToTable("roles_types");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(255)
                .HasColumnName("role_description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Userid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("userid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PreferredLocationId).HasColumnName("preferred_location_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("zip_code");

            entity.HasOne(d => d.PreferredLocation).WithMany(p => p.Users)
                .HasForeignKey(d => d.PreferredLocationId)
                .HasConstraintName("users_preferred_location_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
