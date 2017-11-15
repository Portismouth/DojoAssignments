using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20171114202442_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

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
        }
    }
}
