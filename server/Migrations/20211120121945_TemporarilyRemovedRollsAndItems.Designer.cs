﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ggGURPS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211120121945_TemporarilyRemovedRollsAndItems")]
    partial class TemporarilyRemovedRollsAndItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Advantage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AffectedAttribute")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Advantages");
                });

            modelBuilder.Entity("AdvantageCharacter", b =>
                {
                    b.Property<long>("AdvantagesId")
                        .HasColumnType("bigint");

                    b.Property<long>("CharactersId")
                        .HasColumnType("bigint");

                    b.HasKey("AdvantagesId", "CharactersId");

                    b.HasIndex("CharactersId");

                    b.ToTable("TableRelations_CharactersToAdvantages");
                });

            modelBuilder.Entity("Campaign", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GameMasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("CampaignPlayer", b =>
                {
                    b.Property<long>("CampaignsId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlayersId")
                        .HasColumnType("bigint");

                    b.HasKey("CampaignsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("TableRelations_CampaignsToPlayers");
                });

            modelBuilder.Entity("Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birthday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CampaignId")
                        .HasColumnType("bigint");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("FatiguePoints")
                        .HasColumnType("int");

                    b.Property<long?>("GameMasterId")
                        .HasColumnType("bigint");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Inteligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Npc")
                        .HasColumnType("bit");

                    b.Property<int>("Perception")
                        .HasColumnType("int");

                    b.Property<string>("PhysicalDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<int>("RemainingPoints")
                        .HasColumnType("int");

                    b.Property<int>("SpentPoints")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("Will")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("GameMasterId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.Property<long>("CharactersId")
                        .HasColumnType("bigint");

                    b.Property<long>("SkillsId")
                        .HasColumnType("bigint");

                    b.HasKey("CharactersId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("TableRelations_CharactersToSkills");
                });

            modelBuilder.Entity("GameMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameMasters");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseAttribute")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpentPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("AdvantageCharacter", b =>
                {
                    b.HasOne("Advantage", null)
                        .WithMany()
                        .HasForeignKey("AdvantagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Campaign", b =>
                {
                    b.HasOne("GameMaster", "GameMaster")
                        .WithMany("Campaigns")
                        .HasForeignKey("GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMaster");
                });

            modelBuilder.Entity("CampaignPlayer", b =>
                {
                    b.HasOne("Campaign", null)
                        .WithMany()
                        .HasForeignKey("CampaignsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Character", b =>
                {
                    b.HasOne("Campaign", "Campaign")
                        .WithMany("Characters")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameMaster", "GameMaster")
                        .WithMany("Characters")
                        .HasForeignKey("GameMasterId");

                    b.HasOne("Player", "Player")
                        .WithMany("Characters")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Campaign");

                    b.Navigation("GameMaster");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.HasOne("Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Campaign", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("GameMaster", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
