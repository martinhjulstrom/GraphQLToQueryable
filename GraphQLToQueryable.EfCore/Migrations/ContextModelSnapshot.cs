﻿// <auto-generated />
using System;
using GraphQLToQueryable.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLToQueryable.EfCore.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQLToQueryable.TestData.Entities.ChildEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("OtherEntityId");

                    b.HasKey("Id");

                    b.HasIndex("OtherEntityId");

                    b.ToTable("ChildEntity");
                });

            modelBuilder.Entity("GraphQLToQueryable.TestData.Entities.OtherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OtherEntity");
                });

            modelBuilder.Entity("GraphQLToQueryable.TestData.Entities.RootEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("OtherId");

                    b.HasKey("Id");

                    b.HasIndex("OtherId");

                    b.ToTable("RootEntities");
                });

            modelBuilder.Entity("GraphQLToQueryable.TestData.Entities.ChildEntity", b =>
                {
                    b.HasOne("GraphQLToQueryable.TestData.Entities.OtherEntity")
                        .WithMany("Children")
                        .HasForeignKey("OtherEntityId");
                });

            modelBuilder.Entity("GraphQLToQueryable.TestData.Entities.RootEntity", b =>
                {
                    b.HasOne("GraphQLToQueryable.TestData.Entities.OtherEntity", "Other")
                        .WithMany()
                        .HasForeignKey("OtherId");
                });
#pragma warning restore 612, 618
        }
    }
}
