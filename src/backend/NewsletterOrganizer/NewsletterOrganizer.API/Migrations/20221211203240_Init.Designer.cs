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
    [Migration("20221211203240_Init")]
    partial class Init
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

                    b.Property<string>("LanguageKey1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LanguageKey1");

                    b.ToTable("NewsletterWords");
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
                        .HasForeignKey("LanguageKey1");

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