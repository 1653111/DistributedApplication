﻿// <auto-generated />
using System;
using ApiService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiService.Models.QuestionManagement", b =>
                {
                    b.Property<int?>("qst_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("isActive")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("isPublished")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("qst_cont")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("qst_tag")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("rating")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("qst_id");

                    b.ToTable("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
