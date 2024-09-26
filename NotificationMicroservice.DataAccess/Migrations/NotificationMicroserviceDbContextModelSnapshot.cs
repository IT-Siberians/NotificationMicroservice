﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationMicroservice.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    [DbContext(typeof(NotificationMicroserviceDbContext))]
    partial class NotificationMicroserviceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.MessageTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("TypeId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.MessageType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.Message", b =>
                {
                    b.HasOne("NotificationMicroservice.Domain.Entities.MessageType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.MessageTemplate", b =>
                {
                    b.HasOne("NotificationMicroservice.Domain.Entities.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotificationMicroservice.Domain.Entities.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.HasOne("NotificationMicroservice.Domain.Entities.MessageType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("ModifiedByUser");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("NotificationMicroservice.Domain.Entities.MessageType", b =>
                {
                    b.HasOne("NotificationMicroservice.Domain.Entities.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotificationMicroservice.Domain.Entities.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.Navigation("CreatedByUser");

                    b.Navigation("ModifiedByUser");
                });
#pragma warning restore 612, 618
        }
    }
}
