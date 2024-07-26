using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace thesis_exercise.data;

public partial class ThesisExerciseContext : DbContext
{
    public ThesisExerciseContext()
    {
    }

    public ThesisExerciseContext(DbContextOptions<ThesisExerciseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<ComputerUsbPort> ComputerUsbPorts { get; set; }

    public virtual DbSet<HardDisk> HardDisks { get; set; }

    public virtual DbSet<Memory> Memories { get; set; }

    public virtual DbSet<Processor> Processors { get; set; }

    public virtual DbSet<ProcessorBrand> ProcessorBrands { get; set; }

    public virtual DbSet<SizeType> SizeTypes { get; set; }

    public virtual DbSet<UsbPort> UsbPorts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       base.OnConfiguring(optionsBuilder);
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Computer__3214EC07E2C81560");

            entity.ToTable("Computer");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.HardDisk).WithMany(p => p.Computers)
                .HasForeignKey(d => d.HardDiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computer__HardDi__4E88ABD4");

            entity.HasOne(d => d.Memory).WithMany(p => p.Computers)
                .HasForeignKey(d => d.MemoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computer__Memory__4D94879B");

            entity.HasOne(d => d.Processor).WithMany(p => p.Computers)
                .HasForeignKey(d => d.ProcessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computer__Proces__4CA06362");
        });

        modelBuilder.Entity<ComputerUsbPort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Computer__3214EC07ED020EDD");

            entity.ToTable("ComputerUsbPort");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Computer).WithMany(p => p.ComputerUsbPorts)
                .HasForeignKey(d => d.ComputerId)
                .HasConstraintName("FK__ComputerU__Compu__52593CB8");

            entity.HasOne(d => d.UsbPort).WithMany(p => p.ComputerUsbPorts)
                .HasForeignKey(d => d.UsbPortId)
                .HasConstraintName("FK__ComputerU__UsbPo__534D60F1");
        });

        modelBuilder.Entity<HardDisk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HardDisk__3214EC07F7A0FF00");

            entity.ToTable("HardDisk");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Size).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(3);

            entity.HasOne(d => d.SizeType).WithMany(p => p.HardDisks)
                .HasForeignKey(d => d.SizeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HardDisk__SizeTy__44FF419A");
        });

        modelBuilder.Entity<Memory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Memory__3214EC0759C9AA28");

            entity.ToTable("Memory");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.SizeType).WithMany(p => p.Memories)
                .HasForeignKey(d => d.SizeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Memory__SizeType__48CFD27E");
        });

        modelBuilder.Entity<Processor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Processo__3214EC07F42D0A84");

            entity.ToTable("Processor");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Model).HasMaxLength(50);

            entity.HasOne(d => d.Brand).WithMany(p => p.Processors)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Processor__Brand__3A81B327");
        });

        modelBuilder.Entity<ProcessorBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Processo__3214EC07FA8CBD9E");

            entity.ToTable("ProcessorBrand");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<SizeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SizeType__3214EC072DE959FD");

            entity.ToTable("SizeType");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.TypeCode).HasMaxLength(2);
            entity.Property(e => e.TypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<UsbPort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsbPort__3214EC070287FEF3");

            entity.ToTable("UsbPort");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Version).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
