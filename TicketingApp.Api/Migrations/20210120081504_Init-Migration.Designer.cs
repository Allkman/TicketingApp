﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingApp.Models.Data;

namespace TicketingApp.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210120081504_Init-Migration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TicketingApp.Models.Domain.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TicketsCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UserProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.EventImage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ThumbUrl")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventImages");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.EventTag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventTags");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.JobApplication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppliedUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CvUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrganizerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppliedUserId");

                    b.HasIndex("EventId");

                    b.HasIndex("EventId1");

                    b.HasIndex("OrganizerId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.Like", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LikedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsOrganizer")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.WishlistEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("WishlistEvents");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.Event", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.UserProfile", "UserProfile")
                        .WithMany("Events")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.EventImage", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.Event", "Event")
                        .WithMany("EventImages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.EventTag", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.Event", "Event")
                        .WithMany("EventTags")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.JobApplication", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.UserProfile", "AppliedUser")
                        .WithMany("SentApplications")
                        .HasForeignKey("AppliedUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TicketingApp.Models.Domain.Event", null)
                        .WithMany("ReceivedApplications")
                        .HasForeignKey("EventId");

                    b.HasOne("TicketingApp.Models.Domain.Event", null)
                        .WithMany("SentApplications")
                        .HasForeignKey("EventId1");

                    b.HasOne("TicketingApp.Models.Domain.UserProfile", "Organizer")
                        .WithMany("ReceivedApplications")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AppliedUser");

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.Like", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.Event", "Event")
                        .WithMany("Likes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TicketingApp.Models.Domain.UserProfile", "UserProfile")
                        .WithMany("Likes")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Event");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.Ticket", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TicketingApp.Models.Domain.UserProfile", "UserProfile")
                        .WithMany("Tickets")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Event");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.WishlistEvent", b =>
                {
                    b.HasOne("TicketingApp.Models.Domain.Event", "Event")
                        .WithMany("WishlistEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TicketingApp.Models.Domain.UserProfile", "UserProfile")
                        .WithMany("WishlistEvents")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Event");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.Event", b =>
                {
                    b.Navigation("EventImages");

                    b.Navigation("EventTags");

                    b.Navigation("Likes");

                    b.Navigation("ReceivedApplications");

                    b.Navigation("SentApplications");

                    b.Navigation("Tickets");

                    b.Navigation("WishlistEvents");
                });

            modelBuilder.Entity("TicketingApp.Models.Domain.UserProfile", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Likes");

                    b.Navigation("ReceivedApplications");

                    b.Navigation("SentApplications");

                    b.Navigation("Tickets");

                    b.Navigation("WishlistEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
