﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Models;

namespace server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("AdvantageAndDisadvantage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AffectedAttribute")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PlayerCharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlayerCharacterId");

                    b.ToTable("AdvantageAndDisadvantage");
                });

            modelBuilder.Entity("Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attribute")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PlayerCharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlayerCharacterId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("server.Models.GameMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameMasters");
                });

            modelBuilder.Entity("server.Models.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Equipped")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long>("PlayerCharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("PlayerCharacterId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("server.Models.PlayerCharacter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Age")
                        .HasColumnType("TEXT");

                    b.Property<string>("CharacterName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Dexterity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FatiguePoints")
                        .HasColumnType("INTEGER");

                    b.Property<long>("GameMasterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Inteligence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Perception")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Will")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId");

                    b.ToTable("PlayerCharacters");
                });

            modelBuilder.Entity("AdvantageAndDisadvantage", b =>
                {
                    b.HasOne("server.Models.PlayerCharacter", null)
                        .WithMany("AdvantagesAndDisadvantages")
                        .HasForeignKey("PlayerCharacterId");
                });

            modelBuilder.Entity("Skill", b =>
                {
                    b.HasOne("server.Models.PlayerCharacter", null)
                        .WithMany("Skills")
                        .HasForeignKey("PlayerCharacterId");
                });

            modelBuilder.Entity("server.Models.Item", b =>
                {
                    b.HasOne("server.Models.PlayerCharacter", null)
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("server.Models.PlayerCharacter", b =>
                {
                    b.HasOne("server.Models.GameMaster", "GameMaster")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMaster");
                });

            modelBuilder.Entity("server.Models.GameMaster", b =>
                {
                    b.Navigation("PlayerCharacters");
                });

            modelBuilder.Entity("server.Models.PlayerCharacter", b =>
                {
                    b.Navigation("AdvantagesAndDisadvantages");

                    b.Navigation("Inventory");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
