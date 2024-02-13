﻿// <auto-generated />
using System;
using API_Roteiriza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Roteiriza.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Roteiriza.Models.CardTravelModel", b =>
                {
                    b.Property<int>("travelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("travelId"));

                    b.Property<int?>("checkListId")
                        .HasColumnType("int");

                    b.Property<int?>("travelCostcostId")
                        .HasColumnType("int");

                    b.Property<string>("travelDescriptiion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("travelFinalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("travelInitialDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("travelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("travelId");

                    b.HasIndex("checkListId");

                    b.HasIndex("travelCostcostId");

                    b.ToTable("CardTravel");
                });

            modelBuilder.Entity("API_Roteiriza.Models.CheckList", b =>
                {
                    b.Property<int>("checkListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("checkListId"));

                    b.Property<string>("checkListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("travelId")
                        .HasColumnType("int");

                    b.HasKey("checkListId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("API_Roteiriza.Models.CostModel", b =>
                {
                    b.Property<int>("costId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("costId"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("costName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("travelId")
                        .HasColumnType("int");

                    b.HasKey("costId");

                    b.ToTable("Cost");
                });

            modelBuilder.Entity("API_Roteiriza.Models.UserModel", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<int?>("cardTraveltravelId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("cardTraveltravelId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API_Roteiriza.Models.CardTravelModel", b =>
                {
                    b.HasOne("API_Roteiriza.Models.CheckList", "checkList")
                        .WithMany()
                        .HasForeignKey("checkListId");

                    b.HasOne("API_Roteiriza.Models.CostModel", "travelCost")
                        .WithMany()
                        .HasForeignKey("travelCostcostId");

                    b.Navigation("checkList");

                    b.Navigation("travelCost");
                });

            modelBuilder.Entity("API_Roteiriza.Models.UserModel", b =>
                {
                    b.HasOne("API_Roteiriza.Models.CardTravelModel", "cardTravel")
                        .WithMany()
                        .HasForeignKey("cardTraveltravelId");

                    b.Navigation("cardTravel");
                });
#pragma warning restore 612, 618
        }
    }
}