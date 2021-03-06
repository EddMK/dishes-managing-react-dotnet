// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace dishesmanaging.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCategory");

                    b.HasIndex("IdCategory")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            IdCategory = 1,
                            Name = "Sandwichs"
                        },
                        new
                        {
                            IdCategory = 2,
                            Name = "Pates"
                        },
                        new
                        {
                            IdCategory = 3,
                            Name = "Sushis"
                        },
                        new
                        {
                            IdCategory = 4,
                            Name = "Desserts"
                        },
                        new
                        {
                            IdCategory = 5,
                            Name = "Pizzas"
                        },
                        new
                        {
                            IdCategory = 6,
                            Name = "Plats chauds"
                        });
                });

            modelBuilder.Entity("Models.Dish", b =>
                {
                    b.Property<int>("IdDish")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProviderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdDish");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IdDish")
                        .IsUnique();

                    b.HasIndex("ProviderId");

                    b.ToTable("Dishs");

                    b.HasData(
                        new
                        {
                            IdDish = 1,
                            CategoryId = 1,
                            Label = "Sandwich Américain",
                            Price = 3.5,
                            ProviderId = 1
                        },
                        new
                        {
                            IdDish = 2,
                            CategoryId = 5,
                            Label = "Pizza Forèstiere",
                            Price = 5.0,
                            ProviderId = 2
                        },
                        new
                        {
                            IdDish = 3,
                            CategoryId = 4,
                            Label = "Tiramisu",
                            Price = 3.0,
                            ProviderId = 5
                        },
                        new
                        {
                            IdDish = 4,
                            CategoryId = 2,
                            Label = "Pattes Napolitaines",
                            Price = 4.0,
                            ProviderId = 2
                        },
                        new
                        {
                            IdDish = 5,
                            CategoryId = 1,
                            Label = "Sandwich Poulet Pané",
                            Price = 4.0,
                            ProviderId = 3
                        });
                });

            modelBuilder.Entity("Models.Provider", b =>
                {
                    b.Property<int>("IdProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("IdProvider");

                    b.HasIndex("IdProvider")
                        .IsUnique();

                    b.ToTable("Providers");

                    b.HasData(
                        new
                        {
                            IdProvider = 1,
                            Name = "Tadal"
                        },
                        new
                        {
                            IdProvider = 2,
                            Name = "Miamland"
                        },
                        new
                        {
                            IdProvider = 3,
                            Name = "Vajra"
                        },
                        new
                        {
                            IdProvider = 4,
                            Name = "Serboc"
                        },
                        new
                        {
                            IdProvider = 5,
                            Name = "Delfood"
                        },
                        new
                        {
                            IdProvider = 6,
                            Name = "Foodex"
                        });
                });

            modelBuilder.Entity("Models.Dish", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany("Dishs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Provider", "Provider")
                        .WithMany("Dishs")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Navigation("Dishs");
                });

            modelBuilder.Entity("Models.Provider", b =>
                {
                    b.Navigation("Dishs");
                });
#pragma warning restore 612, 618
        }
    }
}
