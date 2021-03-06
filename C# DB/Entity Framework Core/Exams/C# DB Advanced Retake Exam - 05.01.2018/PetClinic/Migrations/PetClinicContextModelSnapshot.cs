﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PetClinic.Data;
using System;

namespace PetClinic.Migrations
{
    [DbContext(typeof(PetClinicContext))]
    partial class PetClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetClinic.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PassportSerialNumber")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("PassportSerialNumber")
                        .IsUnique();

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("PetClinic.Models.AnimalAid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("AnimalAids");
                });

            modelBuilder.Entity("PetClinic.Models.Passport", b =>
                {
                    b.Property<string>("SerialNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OwnerMobilePhone")
                        .IsRequired();

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("SerialNumber");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("PetClinic.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnimalId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("VetId");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("VetId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("PetClinic.Models.ProcedureAnimalAid", b =>
                {
                    b.Property<int>("ProcedureId");

                    b.Property<int>("AnimalAidId");

                    b.HasKey("ProcedureId", "AnimalAidId");

                    b.HasIndex("AnimalAidId");

                    b.ToTable("ProceduresAnimalAids");
                });

            modelBuilder.Entity("PetClinic.Models.Vet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("PetClinic.Models.Animal", b =>
                {
                    b.HasOne("PetClinic.Models.Passport", "Passport")
                        .WithOne("Animal")
                        .HasForeignKey("PetClinic.Models.Animal", "PassportSerialNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetClinic.Models.Procedure", b =>
                {
                    b.HasOne("PetClinic.Models.Animal", "Animal")
                        .WithMany("Procedures")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetClinic.Models.Vet", "Vet")
                        .WithMany("Procedures")
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetClinic.Models.ProcedureAnimalAid", b =>
                {
                    b.HasOne("PetClinic.Models.AnimalAid", "AnimalAid")
                        .WithMany("ProcedureAnimalAids")
                        .HasForeignKey("AnimalAidId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetClinic.Models.Procedure", "Procedure")
                        .WithMany("ProcedureAnimalAids")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
