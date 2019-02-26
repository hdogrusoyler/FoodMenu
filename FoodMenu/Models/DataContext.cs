using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .Property(e => e.FoodName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuDate)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(e => e.TCKN)
                .IsRequired()
                .HasMaxLength(11);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.isAdmin)
                .HasDefaultValue(false);

            modelBuilder.Entity<FoodMenu>()
                .HasKey(fm => new { fm.FoodId, fm.MenuId });

            modelBuilder.Entity<FoodMenu>()
                .HasOne(fm => fm.Food)
                .WithMany(f => f.FoodMenus)
                .HasForeignKey(fm => fm.FoodId);

            modelBuilder.Entity<FoodMenu>()
                .HasOne(fm => fm.Menu)
                .WithMany(m => m.FoodMenus)
                .HasForeignKey(fm => fm.MenuId);

            modelBuilder.Entity<UserMenu>()
                .HasKey(um => new { um.UserId, um.MenuId });

            modelBuilder.Entity<UserMenu>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMenus)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserMenu>()
                .HasOne(um => um.Menu)
                .WithMany(m => m.UserMenus)
                .HasForeignKey(um => um.MenuId);
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
    }
}
