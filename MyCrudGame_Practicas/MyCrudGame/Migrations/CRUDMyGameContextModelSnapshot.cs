﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCrudGame.Data;

namespace MyCrudGame.Migrations
{
    [DbContext(typeof(CRUDMyGameContext))]
    partial class CRUDMyGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCrudGame.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("NickName")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("MyCrudGame.Models.PlayerSkin", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("SkinId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SkinId");

                    b.ToTable("PlayerSkin");
                });

            modelBuilder.Entity("MyCrudGame.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Icon")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("icon")
                        .IsFixedLength(true);

                    b.Property<double?>("MaxExperience")
                        .HasColumnType("float");

                    b.Property<double?>("MinExperience")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nchar(40)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("damage")
                        .HasColumnType("int");

                    b.Property<string>("devilHunterRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("itemUse")
                        .HasColumnType("int");

                    b.Property<int>("orbs")
                        .HasColumnType("int");

                    b.Property<int>("rankBonus")
                        .HasColumnType("int");

                    b.Property<int>("stylishPTS")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("ranks");
                });

            modelBuilder.Entity("MyCrudGame.Models.Skin", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nchar(60)")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("skins");
                });

            modelBuilder.Entity("MyCrudGame.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mnk")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("mnk")
                        .IsFixedLength(true);

                    b.Property<string>("Pasword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MyCrudGame.Models.Player", b =>
                {
                    b.HasOne("MyCrudGame.Models.User", "IdNavigation")
                        .WithOne("Player")
                        .HasForeignKey("MyCrudGame.Models.Player", "Id")
                        .HasConstraintName("FK_players_users")
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("MyCrudGame.Models.PlayerSkin", b =>
                {
                    b.HasOne("MyCrudGame.Models.Player", "Player")
                        .WithMany("PlayerSkins")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_PlayerSkin_players")
                        .IsRequired();

                    b.HasOne("MyCrudGame.Models.Skin", "Skin")
                        .WithMany("PlayerSkins")
                        .HasForeignKey("SkinId")
                        .HasConstraintName("FK_PlayerSkin_skins")
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Skin");
                });

            modelBuilder.Entity("MyCrudGame.Models.Rank", b =>
                {
                    b.HasOne("MyCrudGame.Models.Player", "Player")
                        .WithMany("Ranks")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_ranks_players");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MyCrudGame.Models.Player", b =>
                {
                    b.Navigation("PlayerSkins");

                    b.Navigation("Ranks");
                });

            modelBuilder.Entity("MyCrudGame.Models.Skin", b =>
                {
                    b.Navigation("PlayerSkins");
                });

            modelBuilder.Entity("MyCrudGame.Models.User", b =>
                {
                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
