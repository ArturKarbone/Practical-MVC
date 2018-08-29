﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Infrastructure;

namespace WebApplication5.Migrations
{
    [DbContext(typeof(BoardContext))]
    [Migration("20180825091745_Add card notes")]
    partial class Addcardnotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication5.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("WebApplication5.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ColumnId");

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("WebApplication5.Models.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("WebApplication5.Models.Card", b =>
                {
                    b.HasOne("WebApplication5.Models.Column")
                        .WithMany("Cards")
                        .HasForeignKey("ColumnId");
                });

            modelBuilder.Entity("WebApplication5.Models.Column", b =>
                {
                    b.HasOne("WebApplication5.Models.Board")
                        .WithMany("Columns")
                        .HasForeignKey("BoardId");
                });
#pragma warning restore 612, 618
        }
    }
}
