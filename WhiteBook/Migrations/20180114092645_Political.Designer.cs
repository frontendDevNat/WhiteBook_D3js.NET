﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WhiteBook.Models;

namespace WhiteBook.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180114092645_Political")]
    partial class Political
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhiteBook.Models.Confession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<int?>("ReligionId");

                    b.HasKey("Id");

                    b.HasIndex("ReligionId");

                    b.ToTable("Confessions");
                });

            modelBuilder.Entity("WhiteBook.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WhiteBook.Models.CyberThreatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("CyberThreatTypes");
                });

            modelBuilder.Entity("WhiteBook.Models.GermanyCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<int?>("GermanyRegionId");

                    b.HasKey("Id");

                    b.HasIndex("GermanyRegionId");

                    b.ToTable("GermanyCities");
                });

            modelBuilder.Entity("WhiteBook.Models.GermanyRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("GermanyRegions");
                });

            modelBuilder.Entity("WhiteBook.Models.MigrationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("MigrationTypes");
                });

            modelBuilder.Entity("WhiteBook.Models.PoliticalPartiesMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("PoliticalPartiesMovements");
                });

            modelBuilder.Entity("WhiteBook.Models.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("WhiteBook.Models.RiskyLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("RiskyLevels");
                });

            modelBuilder.Entity("WhiteBook.Models.TerroristAttackType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("TerroristAttackTyps");
                });

            modelBuilder.Entity("WhiteBook.Models.Confession", b =>
                {
                    b.HasOne("WhiteBook.Models.Religion", "Religion")
                        .WithMany("Confessions")
                        .HasForeignKey("ReligionId");
                });

            modelBuilder.Entity("WhiteBook.Models.GermanyCity", b =>
                {
                    b.HasOne("WhiteBook.Models.GermanyRegion", "GermanyRegion")
                        .WithMany("GermanyCities")
                        .HasForeignKey("GermanyRegionId");
                });
#pragma warning restore 612, 618
        }
    }
}