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
    [Migration("20180430131139_Danger1")]
    partial class Danger1
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

            modelBuilder.Entity("WhiteBook.Models.CyberThreat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountrySourceId");

                    b.Property<int?>("CyberThreatTypeId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Descr");

                    b.Property<int?>("RadicalOrganizationId");

                    b.Property<int?>("RiskyLevelId");

                    b.HasKey("Id");

                    b.HasIndex("CountrySourceId");

                    b.HasIndex("CyberThreatTypeId");

                    b.HasIndex("RadicalOrganizationId");

                    b.HasIndex("RiskyLevelId");

                    b.ToTable("CyberThreats");
                });

            modelBuilder.Entity("WhiteBook.Models.CyberThreatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("CyberThreatTypes");
                });

            modelBuilder.Entity("WhiteBook.Models.Danger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("Dangers");
                });

            modelBuilder.Entity("WhiteBook.Models.DangerYear", b =>
                {
                    b.Property<int>("DangerId");

                    b.Property<int>("YearId");

                    b.HasKey("DangerId", "YearId");

                    b.HasIndex("YearId");

                    b.ToTable("DangerYears");
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

                    b.Property<string>("Code")
                        .HasMaxLength(2);

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("GermanyRegions");
                });

            modelBuilder.Entity("WhiteBook.Models.MigrationFlow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("ConfessionId");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTill");

                    b.Property<string>("Descr");

                    b.Property<int?>("GermanyCityId");

                    b.Property<int?>("MigrationTypeId");

                    b.Property<int?>("RiskyLevelId");

                    b.HasKey("Id");

                    b.HasIndex("ConfessionId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GermanyCityId");

                    b.HasIndex("MigrationTypeId");

                    b.HasIndex("RiskyLevelId");

                    b.ToTable("MigrationFlow");
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

            modelBuilder.Entity("WhiteBook.Models.RadicalOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<int?>("PoliticalPartiesMovementId");

                    b.Property<int?>("ReligionId");

                    b.HasKey("Id");

                    b.HasIndex("PoliticalPartiesMovementId");

                    b.HasIndex("ReligionId");

                    b.ToTable("RadicalOrganizations");
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

            modelBuilder.Entity("WhiteBook.Models.TerroristAttack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Descr");

                    b.Property<int?>("GermanyCityId");

                    b.Property<int>("InjuredQuantity");

                    b.Property<int?>("RadicalOrganizationId");

                    b.Property<int?>("TerroristAttackTypeId");

                    b.Property<int>("VictimsQuantity");

                    b.HasKey("Id");

                    b.HasIndex("GermanyCityId");

                    b.HasIndex("RadicalOrganizationId");

                    b.HasIndex("TerroristAttackTypeId");

                    b.ToTable("TerroristAttacks");
                });

            modelBuilder.Entity("WhiteBook.Models.TerroristAttackType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("TerroristAttackTypes");
                });

            modelBuilder.Entity("WhiteBook.Models.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("WhiteBook.Models.Confession", b =>
                {
                    b.HasOne("WhiteBook.Models.Religion", "Religion")
                        .WithMany("Confessions")
                        .HasForeignKey("ReligionId");
                });

            modelBuilder.Entity("WhiteBook.Models.CyberThreat", b =>
                {
                    b.HasOne("WhiteBook.Models.Country", "CountrySource")
                        .WithMany()
                        .HasForeignKey("CountrySourceId");

                    b.HasOne("WhiteBook.Models.CyberThreatType", "CyberThreatType")
                        .WithMany()
                        .HasForeignKey("CyberThreatTypeId");

                    b.HasOne("WhiteBook.Models.RadicalOrganization", "RadicalOrganization")
                        .WithMany()
                        .HasForeignKey("RadicalOrganizationId");

                    b.HasOne("WhiteBook.Models.RiskyLevel", "RiskyLevel")
                        .WithMany()
                        .HasForeignKey("RiskyLevelId");
                });

            modelBuilder.Entity("WhiteBook.Models.DangerYear", b =>
                {
                    b.HasOne("WhiteBook.Models.Danger", "Danger")
                        .WithMany("DangerYears")
                        .HasForeignKey("DangerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhiteBook.Models.Year", "Year")
                        .WithMany("DangerYears")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhiteBook.Models.GermanyCity", b =>
                {
                    b.HasOne("WhiteBook.Models.GermanyRegion", "GermanyRegion")
                        .WithMany("GermanyCities")
                        .HasForeignKey("GermanyRegionId");
                });

            modelBuilder.Entity("WhiteBook.Models.MigrationFlow", b =>
                {
                    b.HasOne("WhiteBook.Models.Confession", "Confession")
                        .WithMany()
                        .HasForeignKey("ConfessionId");

                    b.HasOne("WhiteBook.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("WhiteBook.Models.GermanyCity", "GermanyCity")
                        .WithMany()
                        .HasForeignKey("GermanyCityId");

                    b.HasOne("WhiteBook.Models.MigrationType", "MigrationType")
                        .WithMany()
                        .HasForeignKey("MigrationTypeId");

                    b.HasOne("WhiteBook.Models.RiskyLevel", "RiskyLevel")
                        .WithMany()
                        .HasForeignKey("RiskyLevelId");
                });

            modelBuilder.Entity("WhiteBook.Models.RadicalOrganization", b =>
                {
                    b.HasOne("WhiteBook.Models.PoliticalPartiesMovement", "PoliticalPartiesMovement")
                        .WithMany()
                        .HasForeignKey("PoliticalPartiesMovementId");

                    b.HasOne("WhiteBook.Models.Religion", "Religion")
                        .WithMany()
                        .HasForeignKey("ReligionId");
                });

            modelBuilder.Entity("WhiteBook.Models.TerroristAttack", b =>
                {
                    b.HasOne("WhiteBook.Models.GermanyCity", "GermanyCity")
                        .WithMany()
                        .HasForeignKey("GermanyCityId");

                    b.HasOne("WhiteBook.Models.RadicalOrganization", "RadicalOrganization")
                        .WithMany()
                        .HasForeignKey("RadicalOrganizationId");

                    b.HasOne("WhiteBook.Models.TerroristAttackType", "TerroristAttackType")
                        .WithMany()
                        .HasForeignKey("TerroristAttackTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
