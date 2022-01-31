using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using MySql.Data.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace Models
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishs { get; set;} = null!;

        public DbSet<Category> Categories { get; set;} = null!;

        public DbSet<Provider> Providers { get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Dish>().HasIndex(d => d.IdDish).IsUnique();

            modelBuilder.Entity<Category>().HasIndex(c => c.IdCategory).IsUnique(); 

            modelBuilder.Entity<Provider>().HasIndex(p => p.IdProvider).IsUnique(); 
            
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany(c=>c.Dishs)
                .HasForeignKey(d => d.CategoryId);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Provider)
                .WithMany(p=>p.Dishs)
                .HasForeignKey(d => d.ProviderId);

            //modelBuilder.Entity<Dish>().HasIndex(d => d.IdDish).IsUnique(); 
            modelBuilder.Entity<Category>().HasData(
                new Category { IdCategory = 1, Name = "Sandwichs"},
                new Category { IdCategory = 2, Name = "Pates"},
                new Category { IdCategory = 3, Name = "Sushis"},
                new Category { IdCategory = 4, Name = "Desserts"},
                new Category { IdCategory = 5, Name = "Pizzas"},
                new Category { IdCategory = 6, Name = "Plats chauds"}
            );

            modelBuilder.Entity<Provider>().HasData(
                new Provider { IdProvider = 1, Name = "Tadal"},
                new Provider { IdProvider = 2, Name = "Miamland"},
                new Provider { IdProvider = 3, Name = "Vajra"},
                new Provider { IdProvider = 4, Name = "Serboc"},
                new Provider { IdProvider = 5, Name = "Delfood"},
                new Provider { IdProvider = 6, Name = "Foodex"}
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish { IdDish = 1, Label = "Sandwich Américain", Price = 3.5, CategoryId = 1, ProviderId = 1},
                new Dish { IdDish = 2, Label = "Pizza Forèstiere", Price = 5 , CategoryId = 5, ProviderId = 2},
                new Dish { IdDish = 3, Label = "Tiramisu", Price = 3 , CategoryId = 4, ProviderId = 5},
                new Dish { IdDish = 4, Label = "Pattes Napolitaines", Price = 4 , CategoryId = 2, ProviderId = 2},
                new Dish { IdDish = 5, Label = "Sandwich Poulet Pané", Price = 4 , CategoryId = 1, ProviderId = 3} 
            );

        } 

    }
}