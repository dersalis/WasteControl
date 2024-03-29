﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WasteControl.Infrastructure.DAL;

#nullable disable

namespace WasteControl.Infrastructure.DAL.Migrations
{
    [DbContext(typeof(WasteControlDbContext))]
    [Migration("20240312163933_M202403121731")]
    partial class M202403121731
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WasteControl.Core.Entities.ReceivingCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("ReceivingCompanies");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.TransportCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("TransportCompanies");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.Waste", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("WasteExportId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("WasteExportId");

                    b.ToTable("Wastes");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.WasteExport", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ReceivingCompanyId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TransportCompanyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ReceivingCompanyId");

                    b.HasIndex("TransportCompanyId");

                    b.ToTable("WasteExports");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.ReceivingCompany", b =>
                {
                    b.HasOne("WasteControl.Core.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("WasteControl.Core.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.TransportCompany", b =>
                {
                    b.HasOne("WasteControl.Core.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("WasteControl.Core.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.User", b =>
                {
                    b.HasOne("WasteControl.Core.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("WasteControl.Core.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.Waste", b =>
                {
                    b.HasOne("WasteControl.Core.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("WasteControl.Core.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("WasteControl.Core.Entities.WasteExport", null)
                        .WithMany("Wastes")
                        .HasForeignKey("WasteExportId");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.WasteExport", b =>
                {
                    b.HasOne("WasteControl.Core.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("WasteControl.Core.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("WasteControl.Core.Entities.ReceivingCompany", "ReceivingCompany")
                        .WithMany()
                        .HasForeignKey("ReceivingCompanyId");

                    b.HasOne("WasteControl.Core.Entities.TransportCompany", "TransportCompany")
                        .WithMany()
                        .HasForeignKey("TransportCompanyId");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("ReceivingCompany");

                    b.Navigation("TransportCompany");
                });

            modelBuilder.Entity("WasteControl.Core.Entities.WasteExport", b =>
                {
                    b.Navigation("Wastes");
                });
#pragma warning restore 612, 618
        }
    }
}
