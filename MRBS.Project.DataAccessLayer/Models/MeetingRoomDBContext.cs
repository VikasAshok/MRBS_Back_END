using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MRBS.Project.DataAccessLayer.ViewModel;

namespace MRBS.Project.API.Models
{
    public partial class MeetingRoomDBContext : DbContext
    {
        public MeetingRoomDBContext()
        {
        }

        public MeetingRoomDBContext(DbContextOptions<MeetingRoomDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Meeting> Meetings { get; set; } = null!;
        public virtual DbSet<MeetingRoom> MeetingRooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<MeetingsViewModel> MeetingsViewModels { get; set; } = null;
        public virtual DbSet<BookedNewMeetingViewModel> BookedNewMeetingViewModels { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=KANINI-LTP-321;Database=MeetingRoomDB;UID=sa;Password=Vikas@jakate1990;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location_name");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.MeetingTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("meeting_title");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meetings__room_i__2B3F6F97");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meetings__user_i__2C3393D0");
            });

            modelBuilder.Entity<MeetingRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("PK__MeetingR__19675A8ACB3E5E4E");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("room_name");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MeetingRooms)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MeetingRo__locat__286302EC");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<MeetingsViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
                entity.Property(e => e.MeetingTitle).HasColumnName("meeting_title");
                entity.Property(e => e.StartTime).HasColumnName("start_time");
                entity.Property(e => e.EndTime).HasColumnName("end_time");         
                entity.Property(e => e.RoomName).HasColumnName("room_name");
                entity.Property(e => e.UserName).HasColumnName("UserName");
            });

            modelBuilder.Entity<BookedNewMeetingViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
                entity.Property(e => e.MeetingTitle).HasColumnName("meeting_title");
                entity.Property(e => e.StartTime).HasColumnName("start_time");
                entity.Property(e => e.EndTime).HasColumnName("end_time");
                entity.Property(e => e.RoomId).HasColumnName("room_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
