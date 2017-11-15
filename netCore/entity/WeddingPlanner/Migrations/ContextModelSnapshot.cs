using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("WeddingPlanner.Models.Guest", b =>
                {
                    b.Property<int>("guestid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("userid");

                    b.Property<int>("weddingid");

                    b.HasKey("guestid");

                    b.HasIndex("userid");

                    b.HasIndex("weddingid");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createdat");

                    b.Property<string>("email");

                    b.Property<string>("firstname");

                    b.Property<string>("lastname");

                    b.Property<string>("password");

                    b.Property<DateTime>("updatedat");

                    b.HasKey("userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("weddingid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<DateTime>("createdat");

                    b.Property<DateTime>("date");

                    b.Property<string>("wedderone");

                    b.Property<string>("weddertwo");

                    b.HasKey("weddingid");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Guest", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "user")
                        .WithMany("weddings")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeddingPlanner.Models.Wedding", "wedding")
                        .WithMany("guests")
                        .HasForeignKey("weddingid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
