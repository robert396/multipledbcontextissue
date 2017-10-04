﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MultipleDbIssues.Data;
using System;

namespace MultipleDbIssues.Data.Migrations.Sites
{
    [DbContext(typeof(SiteDbContext))]
    [Migration("20171004083511_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MultipleDbIssues.Data.Models.Site", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("SiteDomain");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });
#pragma warning restore 612, 618
        }
    }
}
