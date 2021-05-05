﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using user.PostgreSQL;

namespace meistrelis.Migrations
{
    [DbContext(typeof(MeistrelisContext))]
    partial class MeistrelisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("meistrelis.Models.Reservation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId", "ServiceId", "Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("meistrelis.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Services");
                });

            modelBuilder.Entity("meistrelis.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<bool>("IsMechanic")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("meistrelis.Models.UserRating", b =>
                {
                    b.Property<int>("RatedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("RatedUserId", "ReviewerId", "Id");

                    b.HasIndex("ReviewerId");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("meistrelis.Models.UserService", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("UserId", "ServiceId", "Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("UserServices");
                });

            modelBuilder.Entity("meistrelis.Models.Reservation", b =>
                {
                    b.HasOne("meistrelis.Models.User", null)
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("meistrelis.Models.UserRating", b =>
                {
                    b.HasOne("meistrelis.Models.User", "RatedUser")
                        .WithMany("UserRatings")
                        .HasForeignKey("RatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("meistrelis.Models.User", "Reviewer")
                        .WithMany("ReviewedUsers")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RatedUser");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("meistrelis.Models.UserService", b =>
                {
                    b.HasOne("meistrelis.Models.Service", "Service")
                        .WithMany("UserServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("meistrelis.Models.User", "User")
                        .WithMany("UserServices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("meistrelis.Models.Service", b =>
                {
                    b.Navigation("UserServices");
                });

            modelBuilder.Entity("meistrelis.Models.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("ReviewedUsers");

                    b.Navigation("UserRatings");

                    b.Navigation("UserServices");
                });
#pragma warning restore 612, 618
        }
    }
}
