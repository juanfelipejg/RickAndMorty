﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RickAndMorty.Infrastracture.Data;

#nullable disable

namespace RickAndMorty.Infrastracture.Migrations
{
    [DbContext(typeof(RickAndMortyContext))]
    [Migration("20230604022255_Se establece nuevamente relacion muchos a muchos entre character y episode")]
    partial class Seestablecenuevamenterelacionmuchosamuchosentrecharacteryepisode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CharacterEpisode", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "EpisodesId");

                    b.HasIndex("EpisodesId");

                    b.ToTable("CharacterEpisode");
                });

            modelBuilder.Entity("RickAndMorty.Domain.Models.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Specie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("RickAndMorty.Domain.Models.Episodes.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("CharacterEpisode", b =>
                {
                    b.HasOne("RickAndMorty.Domain.Models.Characters.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RickAndMorty.Domain.Models.Episodes.Episode", null)
                        .WithMany()
                        .HasForeignKey("EpisodesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
