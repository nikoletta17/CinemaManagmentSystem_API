using System.Collections.Generic;
using System.Reflection.Emit;
using CinemaManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema_ManagementSystem.Data
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public CinemaDbContext()
        {
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CinemaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                optionsBuilder.UseSqlServer(connStr);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.Seed(modelBuilder);

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Description)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(d => d.Percentage)
                      .HasColumnType("decimal(5,2)");

                entity.HasMany(d => d.Sales)
                      .WithOne(s => s.Discount)
                      .HasForeignKey(s => s.DiscountId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.HallNumber)
                      .IsRequired();

                entity.Property(h => h.SeatsCount)
                      .IsRequired();

                entity.Property(h => h.HallType)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(h => h.Sessions)
                      .WithOne(s => s.Hall)
                      .HasForeignKey(s => s.HallId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(m => m.Genre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(m => m.Director)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(m => m.Description)
                      .HasMaxLength(1000);

                entity.Property(m => m.AgeRestriction)
                      .HasMaxLength(20);

                entity.HasMany(m => m.Sessions)
                      .WithOne(s => s.Movie)
                      .HasForeignKey(s => s.MovieId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.TicketsCount)
                       .IsRequired();

                entity.Property(s => s.TotalAmount)
                       .HasColumnType("decimal(10,2)");

                entity.Property(s => s.PurchaseDate)
                       .HasColumnType("datetime2")
                       .IsRequired();

                entity.HasOne(s => s.Discount)
                      .WithMany(d => d.Sales)
                      .HasForeignKey(s => s.DiscountId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(s => s.User)
                      .WithMany(u => u.Sales)
                      .HasForeignKey(s => s.UserId);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.DateTime)
                      .HasColumnType("datetime2")
                      .IsRequired();

                entity.Property(s => s.TicketPrice)
                       .HasColumnType("decimal(8,2)");

                entity.Property(s => s.Status)
                       .IsRequired()
                       .HasMaxLength(50);

                entity.HasOne(s => s.Movie)
                      .WithMany(m => m.Sessions)
                      .HasForeignKey(s => s.MovieId);

                entity.HasOne(s => s.Hall)
                      .WithMany(h => h.Sessions)
                      .HasForeignKey(s => s.HallId);

                entity.HasMany(s => s.Tickets)
                      .WithOne(t => t.Session)
                      .HasForeignKey(t => t.SessionId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.SeatNumber)
                      .IsRequired();

                entity.Property(t => t.Price)
                      .HasColumnType("decimal(8,2)");

                entity.Property(t => t.Status)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasOne(t => t.Session)
                      .WithMany(s => s.Tickets)
                      .HasForeignKey(t => t.SessionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .HasMaxLength(100);

                entity.Property(u => u.UserType)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.Bonuses)
                      .HasDefaultValue(0);

                entity.HasMany(u => u.Sales)
                      .WithOne(s => s.User)
                      .HasForeignKey(s => s.UserId);
            });

        }
    }
}