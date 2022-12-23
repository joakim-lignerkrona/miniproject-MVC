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

    public virtual DbSet<GroupName> GroupNames { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonInGroup> PersonInGroups { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectGroup> ProjectGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupNam__3214EC07FC5BAEAA");

            entity.ToTable("GroupNames", "ConsultantRandomizer");

            entity.HasIndex(e => e.Name, "UQ__GroupNam__737584F6404C71BC").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC07367C0119");

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

        modelBuilder.Entity<PersonInGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonIn__3214EC075AA4DB35");

            entity.ToTable("PersonInGroup", "ConsultantRandomizer");

            entity.HasIndex(e => new { e.PersonId, e.ProjectGroupId }, "UQ__PersonIn__5B5EDE637CCED9B2").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.ProjectGroupId).HasColumnName("ProjectGroupID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonInGroups)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PersonInG__Perso__5535A963");

            entity.HasOne(d => d.ProjectGroup).WithMany(p => p.PersonInGroups)
                .HasForeignKey(d => d.ProjectGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PersonInG__Proje__5629CD9C");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC071744DBE4");

            entity.ToTable("Project", "ConsultantRandomizer");

            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<ProjectGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectG__3214EC070E4FAF6D");

            entity.ToTable("ProjectGroup", "ConsultantRandomizer");

            entity.HasIndex(e => new { e.ProjectId, e.Groupname }, "UQ__ProjectG__13D572B6749D0D97").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.GroupnameNavigation).WithMany(p => p.ProjectGroups)
                .HasForeignKey(d => d.Groupname)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectGr__Group__5165187F");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectGroups)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjectGr__Proje__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
