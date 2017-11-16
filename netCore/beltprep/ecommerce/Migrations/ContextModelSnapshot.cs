using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ecommerce.Models;

namespace ecommerce.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("ecommerce.Models.Customer", b =>
                {
                    b.Property<int>("customerid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createdat");

                    b.Property<string>("name");

                    b.HasKey("customerid");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ecommerce.Models.Order", b =>
                {
                    b.Property<int>("orderid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createdat");

                    b.Property<int?>("customerid");

                    b.Property<int?>("productid");

                    b.Property<int>("quantity");

                    b.HasKey("orderid");

                    b.HasIndex("customerid");

                    b.HasIndex("productid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ecommerce.Models.Product", b =>
                {
                    b.Property<int>("productid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("image");

                    b.Property<string>("name");

                    b.Property<int>("quantity");

                    b.HasKey("productid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ecommerce.Models.User", b =>
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

            modelBuilder.Entity("ecommerce.Models.Order", b =>
                {
                    b.HasOne("ecommerce.Models.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("customerid");

                    b.HasOne("ecommerce.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid");
                });
        }
    }
}
