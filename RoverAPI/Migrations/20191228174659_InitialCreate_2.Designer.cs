﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoverAPI.Persistence;

namespace RoverAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191228174659_InitialCreate_2")]
    partial class InitialCreate_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("RoverAPI.Domain.Models.MarsRover", b =>
                {
                    b.Property<string>("RoverId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacingDirection")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XPosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YPosition")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoverId");

                    b.ToTable("MarsRovers");
                });
#pragma warning restore 612, 618
        }
    }
}
