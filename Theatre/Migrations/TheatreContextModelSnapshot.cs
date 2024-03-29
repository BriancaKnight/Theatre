﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Theatre.Models;

#nullable disable

namespace Theatre.Migrations
{
    [DbContext(typeof(TheatreContext))]
    partial class TheatreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Theatre.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActorName")
                        .HasColumnType("longtext");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Theatre.Models.ActorShow", b =>
                {
                    b.Property<int>("ActorShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("ActorShowId");

                    b.HasIndex("ActorId");

                    b.HasIndex("ShowId");

                    b.ToTable("ActorShows");
                });

            modelBuilder.Entity("Theatre.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("longtext");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Theatre.Models.GenreShow", b =>
                {
                    b.Property<int>("GenreShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("GenreShowId");

                    b.HasIndex("GenreId");

                    b.HasIndex("ShowId");

                    b.ToTable("GenreShows");
                });

            modelBuilder.Entity("Theatre.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ShowName")
                        .HasColumnType("longtext");

                    b.HasKey("ShowId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("Theatre.Models.ActorShow", b =>
                {
                    b.HasOne("Theatre.Models.Actor", "Actor")
                        .WithMany("ActorShowJoinEntities")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Models.Show", "Show")
                        .WithMany("ActorShowJoinEntities")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Theatre.Models.GenreShow", b =>
                {
                    b.HasOne("Theatre.Models.Genre", "Genre")
                        .WithMany("GenreShowJoinEntities")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Models.Show", "Show")
                        .WithMany("GenreShowJoinEntities")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Theatre.Models.Actor", b =>
                {
                    b.Navigation("ActorShowJoinEntities");
                });

            modelBuilder.Entity("Theatre.Models.Genre", b =>
                {
                    b.Navigation("GenreShowJoinEntities");
                });

            modelBuilder.Entity("Theatre.Models.Show", b =>
                {
                    b.Navigation("ActorShowJoinEntities");

                    b.Navigation("GenreShowJoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
