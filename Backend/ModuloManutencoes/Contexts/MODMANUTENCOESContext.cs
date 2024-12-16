using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModuloManutencoes.Models;

namespace ModuloManutencoes.Contexts
{
    public partial class MODMANUTENCOESContext : DbContext
    {

        public MODMANUTENCOESContext(DbContextOptions<MODMANUTENCOESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dispositivo> Dispositivo { get; set; } = null!;
        public virtual DbSet<Disptype> Disptype { get; set; } = null!;
        public virtual DbSet<Manutenco> Manutencoes { get; set; } = null!;
        public virtual DbSet<Ramtype> Ramtype { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vramtype> Vramtype { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.ToTable("DISPOSITIVOS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .IsFixedLength();

                entity.Property(e => e.Cpu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cpu");

                entity.Property(e => e.DispName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("disp_name");

                entity.Property(e => e.DispType).HasColumnName("disp_type");

                entity.Property(e => e.Gpu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gpu");

                entity.Property(e => e.Mb)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mb");

                entity.Property(e => e.Note)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Psu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("psu");

                entity.Property(e => e.RamQtd).HasColumnName("ram_qtd");

                entity.Property(e => e.RamType).HasColumnName("ram_type");

                entity.Property(e => e.Storage).HasColumnName("storage");

                entity.Property(e => e.VramQtd).HasColumnName("vram_qtd");

                entity.Property(e => e.VramType).HasColumnName("vram_type");

                entity.HasOne(d => d.DispTypeNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.DispType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DISPOSITI__disp___52593CB8");

                entity.HasOne(d => d.RamTypeNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.RamType)
                    .HasConstraintName("FK__DISPOSITI__ram_t__534D60F1");

                entity.HasOne(d => d.VramTypeNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.VramType)
                    .HasConstraintName("FK__DISPOSITI__vram___5441852A");
            });

            modelBuilder.Entity<Disptype>(entity =>
            {
                entity.ToTable("DISPTYPE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .IsFixedLength();

                entity.Property(e => e.TypeDisp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_disp");
            });

            modelBuilder.Entity<Manutenco>(entity =>
            {
                entity.ToTable("MANUTENCOES");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create");

                entity.Property(e => e.DateEnded)
                    .HasColumnType("datetime")
                    .HasColumnName("date_ended");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DispId).HasColumnName("disp_id");

                entity.Property(e => e.ItEnded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("it_ended")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Disp)
                    .WithMany(p => p.Manutencos)
                    .HasForeignKey(d => d.DispId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANUTENCO__disp___5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Manutencos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANUTENCO__user___571DF1D5");
            });

            modelBuilder.Entity<Ramtype>(entity =>
            {
                entity.ToTable("RAMTYPE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .IsFixedLength();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Mail, "UQ_mail_unico")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .IsFixedLength();

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthDate");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Mail)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Mail2)
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("mail2");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.State)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Admin)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("admin");

                entity.Property(e => e.SuperAdmin)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("superAdmin");
            });

            modelBuilder.Entity<Vramtype>(entity =>
            {
                entity.ToTable("VRAMTYPE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .IsFixedLength();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
