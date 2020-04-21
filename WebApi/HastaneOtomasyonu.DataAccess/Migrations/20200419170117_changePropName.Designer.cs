﻿// <auto-generated />
using System;
using HastaneOtomasyonu.DataAccess.Concreat.Entityframework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HastaneOtomasyonu.DataAccess.Migrations
{
    [DbContext(typeof(HastaneOtomasyonuDbContext))]
    [Migration("20200419170117_changePropName")]
    partial class changePropName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KullaniciAdi");

                    b.Property<string>("Parola");

                    b.HasKey("AdminId");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Bolum", b =>
                {
                    b.Property<int>("BolumId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BolumAdi");

                    b.Property<int>("HastaneId");

                    b.HasKey("BolumId");

                    b.HasIndex("HastaneId");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Doktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.Property<int>("BolumId");

                    b.Property<bool>("Cinsiyet");

                    b.Property<string>("Email");

                    b.Property<string>("Parola");

                    b.Property<string>("Soyad");

                    b.Property<string>("TC");

                    b.HasKey("DoktorId");

                    b.HasIndex("BolumId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Hasta", b =>
                {
                    b.Property<int>("HastaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.Property<bool>("Cinsiyet");

                    b.Property<string>("Email");

                    b.Property<string>("Parola");

                    b.Property<string>("Soyad");

                    b.Property<string>("TC");

                    b.HasKey("HastaId");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Hastane", b =>
                {
                    b.Property<int>("HastaneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HastaneAdi");

                    b.Property<string>("HastaneAdresi");

                    b.Property<int>("ilId");

                    b.HasKey("HastaneId");

                    b.HasIndex("ilId");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Il", b =>
                {
                    b.Property<int>("ilId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlakaNo");

                    b.Property<string>("TelefonKodu");

                    b.Property<string>("ilAdi");

                    b.HasKey("ilId");

                    b.ToTable("Iller");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Randevu", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoktorId");

                    b.Property<int>("HastaId");

                    b.Property<bool>("Iptal");

                    b.Property<DateTime>("RandevuTarihi");

                    b.HasKey("RandevuId");

                    b.HasIndex("DoktorId");

                    b.HasIndex("HastaId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Bolum", b =>
                {
                    b.HasOne("HastaneOtomasyonu.Entity.Hastane", "Hastane")
                        .WithMany("Bolumler")
                        .HasForeignKey("HastaneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Doktor", b =>
                {
                    b.HasOne("HastaneOtomasyonu.Entity.Bolum", "Bolum")
                        .WithMany("Doktorlar")
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Hastane", b =>
                {
                    b.HasOne("HastaneOtomasyonu.Entity.Il", "il")
                        .WithMany()
                        .HasForeignKey("ilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HastaneOtomasyonu.Entity.Randevu", b =>
                {
                    b.HasOne("HastaneOtomasyonu.Entity.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HastaneOtomasyonu.Entity.Hasta", "Hasta")
                        .WithMany()
                        .HasForeignKey("HastaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
