using Gemilang.Models;
using Gemilang.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Data
{
    public class GemilangDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Guru> Guru { get; set; }
        public DbSet<Siswa> Siswa { get; set; }
        public DbSet<Kelas> Kelas { get; set; }
        public DbSet<MataPelajaran> MataPelajaran { get; set; }
        public DbSet<Topik> Topik { get; set; }
        public DbSet<NilaiSiswa> NilaiSiswa { get; set; }
        public DbSet<DataPengajaran> DataPengajaran { get; set; }
        public DbSet<TupleMataPelajaranKelas> TupleMataPelajaranKelas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;database=aplikasi_gemilang;user=root;password=", new MySqlServerVersion(new Version(10, 4, 32)));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Username).HasColumnType("VARCHAR(100)").HasColumnName("username");
                entity.Property(e => e.Email).HasColumnType("VARCHAR(255)").HasColumnName("email");
                entity.Property(e => e.Password).HasColumnType("CHAR(64)").HasColumnName("password");
                entity.Property(e => e.Role).HasConversion<string>();
                entity.HasKey(e => e.Id);
                entity.HasData(new Models.User() { Id = 1, Username = "Admin", Email = "admin@gmail.com", Password = Enkripsi.BuatSHA256Hash("admin"), Role = Role.admin });
                entity.HasIndex(e => e.Email).IsUnique();
                entity.ToTable("user");
            });

            modelBuilder.Entity<Siswa>(entity =>
            {
                entity.HasOne(e => e.Kelas).WithMany(e => e.ListSiswa).HasForeignKey(e => e.IdKelas);
                entity.ToTable("siswa");
            });

            modelBuilder.Entity<Guru>().ToTable("guru");

            modelBuilder.Entity<Kelas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nama).HasColumnType("VARCHAR(100)");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Nama).IsUnique();
            });

            modelBuilder.Entity<MataPelajaran>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nama).HasColumnType("VARCHAR(100)");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Nama).IsUnique();
                entity.ToTable("mata_pelajaran");
            });

            modelBuilder.Entity<Topik>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nama).HasColumnType("VARCHAR(100)");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Nama).IsUnique();
                entity.HasOne(e => e.TupleMataPelajaranKelas).WithMany(e => e.ListTopik).HasForeignKey(e => e.IdTupleMataPelajaranKelas);
                entity.ToTable("topik");
            });

            modelBuilder.Entity<NilaiSiswa>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Siswa).WithMany(e => e.ListNilaiSiswa).HasForeignKey(e => e.IdSiswa);
                entity.HasOne(e => e.Topik).WithMany(e => e.ListNilaiSiswa).HasForeignKey(e => e.IdTopik);
                entity.HasIndex(e => new { e.IdSiswa, e.IdTopik }).IsUnique();
                entity.ToTable("nilai_siswa");
            });

            modelBuilder.Entity<DataPengajaran>(entity =>
            {
                entity.HasKey(e => new { e.IdGuru, e.IdTupleMataPelajaranKelas });
                entity.HasOne(e => e.Guru).WithMany(e => e.ListDataPengajaran).HasForeignKey(e => e.IdGuru).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.TupleMataPelajaranKelas).WithMany(e => e.ListDataPengajaran).HasForeignKey(e => e.IdTupleMataPelajaranKelas).OnDelete(DeleteBehavior.Cascade);
                entity.ToTable("data_pengajaran");
            });


            modelBuilder.Entity<TupleMataPelajaranKelas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.MataPelajaran).WithMany(e => e.ListTupleMataPelajaranKelas).HasForeignKey(e => e.IdMataPelajaran).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Kelas).WithMany(e => e.ListTupleMataPelajaranKelas).HasForeignKey(e => e.IdKelas).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(u => new { u.IdMataPelajaran, u.IdKelas }).IsUnique();
                entity.ToTable("mata_pelajaran_kelas");
            });
        }
    }
}
