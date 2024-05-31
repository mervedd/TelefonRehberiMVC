﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelefonRehberiMVC.Models.MVCDbContext;

#nullable disable

namespace TelefonRehberiMVC.Migrations
{
    [DbContext(typeof(TelefonRehberiDbContext))]
    [Migration("20240110115732_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TelefonRehberiMVC.Models.Persons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TelefonRehberiMVC.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("TelefonRehberiMVC.Models.Persons", b =>
                {
                    b.HasOne("TelefonRehberiMVC.Models.Phone", "Phones")
                        .WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
