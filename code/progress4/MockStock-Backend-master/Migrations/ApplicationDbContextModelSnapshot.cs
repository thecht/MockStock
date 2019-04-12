﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MockStockBackend.DataModels;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MockStockBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MockStockBackend.DataModels.League", b =>
                {
                    b.Property<string>("LeagueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LeagueCreationDate");

                    b.Property<int>("LeagueHost");

                    b.Property<string>("LeagueName");

                    b.Property<bool>("OpenEnrollment");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("MockStockBackend.DataModels.LeagueUser", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LeagueId");

                    b.Property<int>("PrivilegeLevel");

                    b.HasKey("UserId", "LeagueId");

                    b.HasIndex("LeagueId");

                    b.ToTable("LeagueUsers");
                });

            modelBuilder.Entity("MockStockBackend.DataModels.Stock", b =>
                {
                    b.Property<string>("StockId");

                    b.Property<int>("UserId");

                    b.Property<int>("StockQuantity");

                    b.HasKey("StockId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("MockStockBackend.DataModels.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StockId");

                    b.Property<decimal>("StockPrice");

                    b.Property<int>("StockQty");

                    b.Property<int>("TransactionDate");

                    b.Property<string>("TransactionType");

                    b.Property<int>("UserId");

                    b.HasKey("TransactionId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MockStockBackend.DataModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Token");

                    b.Property<decimal>("UserCurrency");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPassword");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MockStockBackend.DataModels.LeagueUser", b =>
                {
                    b.HasOne("MockStockBackend.DataModels.League", "League")
                        .WithMany("LeagueUsers")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MockStockBackend.DataModels.User", "User")
                        .WithMany("LeagueUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MockStockBackend.DataModels.Stock", b =>
                {
                    b.HasOne("MockStockBackend.DataModels.User", "User")
                        .WithMany("Stocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MockStockBackend.DataModels.Transaction", b =>
                {
                    b.HasOne("MockStockBackend.DataModels.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
