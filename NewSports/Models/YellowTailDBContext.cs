using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewSports.Models
{
    public partial class YellowTailDBContext : DbContext
    {
        public YellowTailDBContext()
        {
        }

        public YellowTailDBContext(DbContextOptions<YellowTailDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MemberLogin> MemberLogin { get; set; }
        public virtual DbSet<MemberSports> MemberSports { get; set; }
        public virtual DbSet<MembersTb> MembersTb { get; set; }
        public virtual DbSet<SportsTb> SportsTb { get; set; }
        public virtual DbSet<UserTb> UserTb { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberLogin>(entity =>
            {
                entity.HasKey(e => e.Fbname);

                entity.Property(e => e.Fbname)
                    .HasColumnName("FBName")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberLogin)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MemberLog__Membe__3F466844");
            });

            modelBuilder.Entity<MemberSports>(entity =>
            {
                entity.HasKey(e => e.SportsMemberId);

                entity.Property(e => e.SportsMemberId).HasColumnName("SportsMemberID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SportsId).HasColumnName("SportsID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberSports)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MemberSpo__Membe__3C69FB99");

                entity.HasOne(d => d.Sports)
                    .WithMany(p => p.MemberSports)
                    .HasForeignKey(d => d.SportsId)
                    .HasConstraintName("FK__MemberSpo__Sport__3D5E1FD2");
            });

            modelBuilder.Entity<MembersTb>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("MembersTB");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SportsTb>(entity =>
            {
                entity.HasKey(e => e.SportsId);

                entity.ToTable("SportsTB");

                entity.Property(e => e.SportsId).HasColumnName("SportsID");

                entity.Property(e => e.SportsName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTB");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
