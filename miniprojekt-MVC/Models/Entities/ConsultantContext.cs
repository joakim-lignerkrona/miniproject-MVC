using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace miniprojekt_MVC.Models.Entities;

public partial class ConsultantContext : DbContext
{
    public ConsultantContext(DbContextOptions<ConsultantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<PeopleInGroupProject> PeopleInGroupProjects { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Group__3214EC071AC8E3FB");

            entity.ToTable("Group", "ConsultantRandomizer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
        });

        modelBuilder.Entity<PeopleInGroupProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PeopleIn__3214EC075D6DD316");

            entity.ToTable("PeopleInGroupProject", "ConsultantRandomizer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Person).WithMany(p => p.PeopleInGroupProjects)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PeopleInG__Perso__2D27B809");

            entity.HasOne(d => d.Project).WithMany(p => p.PeopleInGroupProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PeopleInG__Proje__2E1BDC42");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC0706900B79");

            entity.ToTable("People", "ConsultantRandomizer");

            entity.Property(e => e.CustomDisplayName)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.DiscordId)
                .HasMaxLength(200)
                .IsFixedLength()
                .HasColumnName("DiscordID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07A1F3F3A1");

            entity.ToTable("Project", "ConsultantRandomizer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
