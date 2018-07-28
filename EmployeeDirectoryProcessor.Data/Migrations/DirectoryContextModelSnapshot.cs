﻿// <auto-generated />
using System;
using EmployeeDirectoryProcessor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeDirectoryProcessor.Data.Migrations
{
    [DbContext(typeof(DirectoryContext))]
    partial class DirectoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeDirectoryProcessor.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<int>("Age");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("CivilStatus");

                    b.Property<int>("ContactNumber");

                    b.Property<string>("Country");

                    b.Property<string>("Department");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("HobbiesAndInterest");

                    b.Property<string>("LanguagesSpoken");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int>("PasswordAttemptFail");

                    b.Property<string>("State");

                    b.Property<string>("UserName");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
