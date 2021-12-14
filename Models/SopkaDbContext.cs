using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Compromise.Models
{
    public partial class SopkaDbContext : DbContext
    {
        public SopkaDbContext()
        {
        }

        public SopkaDbContext(DbContextOptions<SopkaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<БазаИндикаторов> БазаИндикаторов { get; set; }
        public virtual DbSet<ДоверенныеРесурсы> ДоверенныеРесурсы { get; set; }
        public virtual DbSet<Индикаторы> Индикаторы { get; set; }
        public virtual DbSet<КатегорииИндикаторов> КатегорииИндикаторов { get; set; }
        public virtual DbSet<КонфигурацииСзи> КонфигурацииСзи { get; set; }
        public virtual DbSet<КритерииОценкиПолученныхРезультатов> КритерииОценкиПолученныхРезультатов { get; set; }
        public virtual DbSet<ОбогащенныеИндикаторы> ОбогащенныеИндикаторы { get; set; }
        public virtual DbSet<Отчеты> Отчеты { get; set; }
        public virtual DbSet<ПоставщикиДанных> ПоставщикиДанных { get; set; }
        public virtual DbSet<ПредварительноСобранныеИндикаторы> ПредварительноСобранныеИндикаторы { get; set; }
        public virtual DbSet<СтандартыОписанияДанных> СтандартыОписанияДанных { get; set; }
        public virtual DbSet<УполномоченныеСотрудники> УполномоченныеСотрудники { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-C5TJL8G;Initial Catalog=diploma;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<БазаИндикаторов>(entity =>
            {
                entity.HasKey(e => new { e.IdИндикатора, e.IdОбщегоИндикатора })
                    .HasName("XPKБаза_индикаторов");

                entity.HasOne(d => d.IdОбщегоИндикатораNavigation)
                    .WithMany(p => p.БазаИндикаторов)
                    .HasForeignKey(d => d.IdОбщегоИндикатора)
                    .HasConstraintName("FK__База_инди__id_об__4CA06362");
            });

            modelBuilder.Entity<ДоверенныеРесурсы>(entity =>
            {
                entity.HasKey(e => e.IdРесурса)
                    .HasName("XPKДоверенные_ресурсы");

                entity.Property(e => e.IpАдрес)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.НазваниеОрганизации).IsUnicode(false);

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ДоверенныеРесурсы)
                    .HasForeignKey(d => new { d.IdИндикатора, d.IdОбщегоИндикатора })
                    .HasConstraintName("R_13");
            });

            modelBuilder.Entity<Индикаторы>(entity =>
            {
                entity.HasKey(e => e.IdОбщегоИндикатора)
                    .HasName("XPKИндикаторы");

                entity.Property(e => e.IdОбщегоИндикатора).ValueGeneratedNever();

                entity.Property(e => e.Значение).IsUnicode(false);

                entity.Property(e => e.Контекст).IsUnicode(false);

                entity.Property(e => e.Тип).IsUnicode(false);

                entity.HasOne(d => d.IdКатегорииNavigation)
                    .WithMany(p => p.Индикаторы)
                    .HasForeignKey(d => d.IdКатегории)
                    .HasConstraintName("R_38");

                entity.HasOne(d => d.IdКритерияNavigation)
                    .WithMany(p => p.Индикаторы)
                    .HasForeignKey(d => d.IdКритерия)
                    .HasConstraintName("R_37");
            });

            modelBuilder.Entity<КатегорииИндикаторов>(entity =>
            {
                entity.HasKey(e => e.IdКатегории)
                    .HasName("XPKКатегории_индикаторов");

                entity.Property(e => e.КатегорияИндикатора).IsUnicode(false);
            });

            modelBuilder.Entity<КонфигурацииСзи>(entity =>
            {
                entity.HasKey(e => e.IdОповещения)
                    .HasName("XPKКонфигурации_СЗИ");

                entity.Property(e => e.IdОповещения).ValueGeneratedNever();

                entity.Property(e => e.ОписаниеОповещения).IsUnicode(false);

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.КонфигурацииСзи)
                    .HasForeignKey(d => new { d.IdИндикатора, d.IdОбщегоИндикатора })
                    .HasConstraintName("R_8");
            });

            modelBuilder.Entity<КритерииОценкиПолученныхРезультатов>(entity =>
            {
                entity.HasKey(e => e.IdКритерия)
                    .HasName("XPKКритерии_оценки_полученных_результатов");

                entity.Property(e => e.ПолнотаКонтекста)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdПоставщикаNavigation)
                    .WithMany(p => p.КритерииОценкиПолученныхРезультатов)
                    .HasForeignKey(d => d.IdПоставщика)
                    .HasConstraintName("R_20");

                entity.HasOne(d => d.IdСтандартаNavigation)
                    .WithMany(p => p.КритерииОценкиПолученныхРезультатов)
                    .HasForeignKey(d => d.IdСтандарта)
                    .HasConstraintName("R_19");
            });

            modelBuilder.Entity<ОбогащенныеИндикаторы>(entity =>
            {
                entity.HasKey(e => new { e.IdОбогащенногоИндикатора, e.IdОбщегоИндикатора })
                    .HasName("XPKОбогащенные_индикаторы");

                entity.HasOne(d => d.IdОбщегоИндикатораNavigation)
                    .WithMany(p => p.ОбогащенныеИндикаторы)
                    .HasForeignKey(d => d.IdОбщегоИндикатора)
                    .HasConstraintName("FK__Обогащенн__id_об__534D60F1");
            });

            modelBuilder.Entity<Отчеты>(entity =>
            {
                entity.HasKey(e => e.IdОтчета)
                    .HasName("XPKОтчеты");

                entity.Property(e => e.IdОтчета).ValueGeneratedNever();

                entity.Property(e => e.Результат).IsUnicode(false);

                entity.HasOne(d => d.IdСотрудникаNavigation)
                    .WithMany(p => p.Отчеты)
                    .HasForeignKey(d => d.IdСотрудника)
                    .HasConstraintName("R_7");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Отчеты)
                    .HasForeignKey(d => new { d.IdИндикатора, d.IdОбщегоИндикатора })
                    .HasConstraintName("R_5");
            });

            modelBuilder.Entity<ПоставщикиДанных>(entity =>
            {
                entity.HasKey(e => e.IdПоставщика)
                    .HasName("XPKПоставщики_данных");

                entity.Property(e => e.Поставщик).IsUnicode(false);
            });

            modelBuilder.Entity<ПредварительноСобранныеИндикаторы>(entity =>
            {
                entity.HasKey(e => new { e.IdПредварительноСобранногоИндикатора, e.IdОбщегоИндикатора })
                    .HasName("XPKПредварительно_собранные_индикаторы");

                entity.HasOne(d => d.IdОбщегоИндикатораNavigation)
                    .WithMany(p => p.ПредварительноСобранныеИндикаторы)
                    .HasForeignKey(d => d.IdОбщегоИндикатора)
                    .HasConstraintName("FK__Предварит__id_об__5629CD9C");
            });

            modelBuilder.Entity<СтандартыОписанияДанных>(entity =>
            {
                entity.HasKey(e => e.IdСтандарта)
                    .HasName("XPKСтандарты_описания_данных");

                entity.Property(e => e.СтандартОписания).IsUnicode(false);
            });

            modelBuilder.Entity<УполномоченныеСотрудники>(entity =>
            {
                entity.HasKey(e => e.IdСотрудника)
                    .HasName("XPKУполномоченные_сотрудники");

                entity.Property(e => e.Должность).IsUnicode(false);

                entity.Property(e => e.Имя).IsUnicode(false);

                entity.Property(e => e.Отчество).IsUnicode(false);

                entity.Property(e => e.Фамилия).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
