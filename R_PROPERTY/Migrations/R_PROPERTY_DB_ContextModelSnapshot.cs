﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using R_PROPERTY.Data;

namespace R_PROPERTY.Migrations
{
    [DbContext(typeof(R_PROPERTY_DB_Context))]
    partial class R_PROPERTY_DB_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("R_PROPERTY.Models.inquiry", b =>
                {
                    b.Property<int>("inquiry_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateTime_inquiry")
                        .HasColumnType("datetime2");

                    b.Property<int?>("property_Detailsproperty_id")
                        .HasColumnType("int");

                    b.Property<int>("property_id")
                        .HasColumnType("int");

                    b.Property<int?>("user_detailsuser_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("user_massege")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("inquiry_id");

                    b.HasIndex("property_Detailsproperty_id");

                    b.HasIndex("user_detailsuser_id");

                    b.ToTable("inquiry");
                });

            modelBuilder.Entity("R_PROPERTY.Models.property_details", b =>
                {
                    b.Property<int>("property_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("property_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("property_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("property_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("property_value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("property_id");

                    b.ToTable("property_details");
                });

            modelBuilder.Entity("R_PROPERTY.Models.user_details", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("user_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("user_details");
                });

            modelBuilder.Entity("R_PROPERTY.Models.wishlist", b =>
                {
                    b.Property<int>("wishlist_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("property_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("wishlist_id");

                    b.ToTable("wishlist");
                });

            modelBuilder.Entity("R_PROPERTY.Models.inquiry", b =>
                {
                    b.HasOne("R_PROPERTY.Models.property_details", "property_Details")
                        .WithMany()
                        .HasForeignKey("property_Detailsproperty_id");

                    b.HasOne("R_PROPERTY.Models.user_details", "user_details")
                        .WithMany()
                        .HasForeignKey("user_detailsuser_id");
                });
#pragma warning restore 612, 618
        }
    }
}
