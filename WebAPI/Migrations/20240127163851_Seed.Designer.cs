﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240127163851_Seed")]
    partial class Seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Entity.Cluster", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Denominazione")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Cluster", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Denominazione = "ASD"
                        });
                });

            modelBuilder.Entity("WebAPI.Entity.ClusterStrutture", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("IDCluster")
                        .HasColumnType("bigint");

                    b.Property<long>("IDStruttura")
                        .HasColumnType("bigint");

                    b.Property<long>("Ordine")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("IDCluster");

                    b.ToTable("ClusterStrutture", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            IDCluster = 1L,
                            IDStruttura = 20L,
                            Ordine = 0L
                        },
                        new
                        {
                            ID = 2L,
                            IDCluster = 1L,
                            IDStruttura = 34L,
                            Ordine = 0L
                        });
                });

            modelBuilder.Entity("WebAPI.Entity.ClusterUtenti", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("IDCluster")
                        .HasColumnType("bigint");

                    b.Property<long>("IDUtente")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("IDCluster");

                    b.ToTable("ClusterUtenti", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            IDCluster = 1L,
                            IDUtente = 18L
                        });
                });

            modelBuilder.Entity("WebAPI.Entity.ClusterStrutture", b =>
                {
                    b.HasOne("WebAPI.Entity.Cluster", "Cluster")
                        .WithMany("ClusterStrutture")
                        .HasForeignKey("IDCluster")
                        .IsRequired()
                        .HasConstraintName("FK_ClusterStrutture_Cluster");

                    b.Navigation("Cluster");
                });

            modelBuilder.Entity("WebAPI.Entity.ClusterUtenti", b =>
                {
                    b.HasOne("WebAPI.Entity.Cluster", "Cluster")
                        .WithMany("ClusterUtenti")
                        .HasForeignKey("IDCluster")
                        .IsRequired()
                        .HasConstraintName("FK_ClusterUtenti_Cluster");

                    b.Navigation("Cluster");
                });

            modelBuilder.Entity("WebAPI.Entity.Cluster", b =>
                {
                    b.Navigation("ClusterStrutture");

                    b.Navigation("ClusterUtenti");
                });
#pragma warning restore 612, 618
        }
    }
}
