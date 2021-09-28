﻿// <auto-generated />
using System;
using Events.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Events.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20210918165932_addTitlePhotoToEvent")]
    partial class addTitlePhotoToEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Event_Shop.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountOwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("AccountOwnerId1")
                        .HasColumnType("int");

                    b.Property<long?>("BankAccountNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PayPalAccountNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountOwnerId1");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Event_Shop.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Event_Shop.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Event_Shop.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<int?>("EventCreatorId")
                        .HasColumnType("int");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnlyForAdults")
                        .HasColumnType("bit");

                    b.Property<int>("PossibleTicketForBuyQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TicketPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TicketQuantity")
                        .HasColumnType("int");

                    b.Property<string>("TitlePhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventCreatorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Event_Shop.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Event_Shop.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Event_Shop.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Event_Shop.Entities.Account", b =>
                {
                    b.HasOne("Event_Shop.Entities.User", "AccountOwner")
                        .WithMany()
                        .HasForeignKey("AccountOwnerId1");

                    b.Navigation("AccountOwner");
                });

            modelBuilder.Entity("Event_Shop.Entities.Adress", b =>
                {
                    b.HasOne("Event_Shop.Entities.Event", null)
                        .WithOne("EventAdress")
                        .HasForeignKey("Event_Shop.Entities.Adress", "EventId");

                    b.HasOne("Event_Shop.Entities.User", null)
                        .WithOne("Adress")
                        .HasForeignKey("Event_Shop.Entities.Adress", "UserId");
                });

            modelBuilder.Entity("Event_Shop.Entities.Comment", b =>
                {
                    b.HasOne("Event_Shop.Entities.Event", null)
                        .WithMany("Comments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Shop.Entities.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Event_Shop.Entities.Event", b =>
                {
                    b.HasOne("Event_Shop.Entities.User", "EventCreator")
                        .WithMany()
                        .HasForeignKey("EventCreatorId");

                    b.Navigation("EventCreator");
                });

            modelBuilder.Entity("Event_Shop.Entities.Participant", b =>
                {
                    b.HasOne("Event_Shop.Entities.Event", null)
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Shop.Entities.User", null)
                        .WithMany("Participant")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Event_Shop.Entities.Ticket", b =>
                {
                    b.HasOne("Event_Shop.Entities.Event", null)
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Shop.Entities.User", null)
                        .WithMany("Tickets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Event_Shop.Entities.Event", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("EventAdress")
                        .IsRequired();

                    b.Navigation("Participants");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Event_Shop.Entities.User", b =>
                {
                    b.Navigation("Adress")
                        .IsRequired();

                    b.Navigation("Comments");

                    b.Navigation("Participant");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
