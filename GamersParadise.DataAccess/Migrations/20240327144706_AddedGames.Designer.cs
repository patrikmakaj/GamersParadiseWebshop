﻿// <auto-generated />
using GamersParadise.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamersParadise.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240327144706_AddedGames")]
    partial class AddedGames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamersParadise.Models.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRating = "A",
                            Description = "Nova igrica",
                            GenreId = 1,
                            ImageUrl = "string",
                            Platform = "PC",
                            Price = 50.5,
                            Publisher = "EA Sports",
                            Title = "NewGame"
                        },
                        new
                        {
                            Id = 2,
                            AgeRating = "E",
                            Description = "Description for EA FC 24",
                            GenreId = 6,
                            ImageUrl = "imageUrlForEaFc24",
                            Platform = "PC",
                            Price = 60.0,
                            Publisher = "EA Sports",
                            Title = "EA FC 24"
                        },
                        new
                        {
                            Id = 3,
                            AgeRating = "M",
                            Description = "Description for Call of Duty",
                            GenreId = 1,
                            ImageUrl = "imageUrlForCod",
                            Platform = "PC",
                            Price = 59.990000000000002,
                            Publisher = "Activision",
                            Title = "Call of Duty"
                        },
                        new
                        {
                            Id = 4,
                            AgeRating = "E",
                            Description = "Description for Minecraft",
                            GenreId = 2,
                            ImageUrl = "imageUrlForMinecraft",
                            Platform = "PC",
                            Price = 26.949999999999999,
                            Publisher = "Mojang",
                            Title = "Minecraft"
                        });
                });

            modelBuilder.Entity("GamersParadise.Models.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Role-Playing"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 2,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 2,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 4,
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("GamersParadise.Models.Models.Game", b =>
                {
                    b.HasOne("GamersParadise.Models.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
