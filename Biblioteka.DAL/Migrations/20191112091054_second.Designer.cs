﻿// <auto-generated />
using System;
using Biblioteka.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace Biblioteka.DAL.Migrations
{
    [DbContext(typeof(LibContext))]
    [Migration("20191112091054_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("Biblioteka.DAL.Entities.Autor", b =>
                {
                    b.Property<int>("aId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biografija");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.HasKey("aId");

                    b.ToTable("Autori");
                });

            modelBuilder.Entity("Biblioteka.DAL.Entities.AutorKnjiga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AutoraId");

                    b.Property<int?>("KnjigakId");

                    b.HasKey("Id");

                    b.HasIndex("AutoraId");

                    b.HasIndex("KnjigakId");

                    b.ToTable("AutKnjige");
                });

            modelBuilder.Entity("Biblioteka.DAL.Entities.Izdavac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Sjediste");

                    b.HasKey("Id");

                    b.ToTable("Izdavaci");
                });

            modelBuilder.Entity("Biblioteka.DAL.Entities.Knjiga", b =>
                {
                    b.Property<int>("kId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cijena");

                    b.Property<int?>("IzdavacId");

                    b.Property<string>("Naslov");

                    b.HasKey("kId");

                    b.HasIndex("IzdavacId");

                    b.ToTable("Knjige");
                });

            modelBuilder.Entity("Biblioteka.DAL.Entities.AutorKnjiga", b =>
                {
                    b.HasOne("Biblioteka.DAL.Entities.Autor", "Autor")
                        .WithMany("Knjige")
                        .HasForeignKey("AutoraId");

                    b.HasOne("Biblioteka.DAL.Entities.Knjiga", "Knjiga")
                        .WithMany("Autori")
                        .HasForeignKey("KnjigakId");
                });

            modelBuilder.Entity("Biblioteka.DAL.Entities.Knjiga", b =>
                {
                    b.HasOne("Biblioteka.DAL.Entities.Izdavac", "Izdavac")
                        .WithMany("Knjige")
                        .HasForeignKey("IzdavacId");
                });
#pragma warning restore 612, 618
        }
    }
}
