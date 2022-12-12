﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsletterOrganizer.EntityFramework;

#nullable disable

namespace NewsletterOrganizer.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221212155216_InitWithSeedData")]
    partial class InitWithSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("NewsletterOrganizer.Domain.Newsletters.NewsletterWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LanguageKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LanguageKey");

                    b.ToTable("NewsletterWords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageKey = "PL",
                            Word = "Anuluj Subskrybcję"
                        },
                        new
                        {
                            Id = 2,
                            LanguageKey = "PL",
                            Word = "Wypisz"
                        },
                        new
                        {
                            Id = 3,
                            LanguageKey = "PL",
                            Word = "Newsletter"
                        },
                        new
                        {
                            Id = 4,
                            LanguageKey = "PL",
                            Word = "Otrzymałeś tę wiadomość"
                        },
                        new
                        {
                            Id = 5,
                            LanguageKey = "EN",
                            Word = "Unsubscribe"
                        },
                        new
                        {
                            Id = 6,
                            LanguageKey = "EN",
                            Word = "Newsletter"
                        },
                        new
                        {
                            Id = 7,
                            LanguageKey = "EN",
                            Word = "Subscription"
                        });
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Settings.Language", b =>
                {
                    b.Property<string>("LanguageKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LanguageKey");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageKey = "PL",
                            Name = "Polski"
                        },
                        new
                        {
                            LanguageKey = "EN",
                            Name = "English"
                        });
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Users.EmailAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAccounts");
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Newsletters.NewsletterWord", b =>
                {
                    b.HasOne("NewsletterOrganizer.Domain.Settings.Language", "Language")
                        .WithMany("NewsletterWords")
                        .HasForeignKey("LanguageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Users.EmailAccount", b =>
                {
                    b.HasOne("NewsletterOrganizer.Domain.Users.User", "User")
                        .WithMany("EmailAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Settings.Language", b =>
                {
                    b.Navigation("NewsletterWords");
                });

            modelBuilder.Entity("NewsletterOrganizer.Domain.Users.User", b =>
                {
                    b.Navigation("EmailAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}