﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrecercoSpedizioni.data;

#nullable disable

namespace TrecercoSpedizioni.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240307123356_dletedNomeClienteCamp")]
    partial class dletedNomeClienteCamp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrecercoSpedizioni.Models.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCliente"));

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartitaIva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usertype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCliente");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("TrecercoSpedizioni.Models.DettagliSpedizioni", b =>
                {
                    b.Property<int>("idDettagliSpedizione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idDettagliSpedizione"));

                    b.Property<DateTime>("DataAggiornamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdSpedizione")
                        .HasColumnType("int");

                    b.Property<string>("LuogoCorrente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoteSpedizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShippingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatoSpedizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idDettagliSpedizione");

                    b.HasIndex("ShippingId");

                    b.ToTable("DettagliSpedizioni");
                });

            modelBuilder.Entity("TrecercoSpedizioni.Models.Spedizioni", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CittaDestinazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CostoSpedizione")
                        .HasColumnType("float");

                    b.Property<DateTime>("DataSpedizione")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("IndirizzoDestinatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NominativoDestinatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Spedizioni");
                });

            modelBuilder.Entity("TrecercoSpedizioni.Models.DettagliSpedizioni", b =>
                {
                    b.HasOne("TrecercoSpedizioni.Models.Spedizioni", "Shipping")
                        .WithMany("DettagliSpedizioni")
                        .HasForeignKey("ShippingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipping");
                });

            modelBuilder.Entity("TrecercoSpedizioni.Models.Spedizioni", b =>
                {
                    b.HasOne("TrecercoSpedizioni.Models.Cliente", "Cliente")
                        .WithMany("Spedizioni")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TrecercoSpedizioni.Models.Cliente", b =>
                {
                    b.Navigation("Spedizioni");
                });

            modelBuilder.Entity("TrecercoSpedizioni.Models.Spedizioni", b =>
                {
                    b.Navigation("DettagliSpedizioni");
                });
#pragma warning restore 612, 618
        }
    }
}
