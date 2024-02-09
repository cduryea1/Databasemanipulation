﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using a;

#nullable disable

namespace DatabaseManipulations.Migrations
{
    [DbContext(typeof(CityDB))]
    partial class CityDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("a.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("lat")
                        .HasColumnType("REAL");

                    b.Property<double>("lon")
                        .HasColumnType("REAL");

                    b.Property<int>("population")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("cities");
                });
#pragma warning restore 612, 618
        }
    }
}
