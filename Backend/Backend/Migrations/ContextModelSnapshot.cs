﻿// <auto-generated />
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.DbModel.DbCredentials", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personId")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.ToTable("credentials");
                });

            modelBuilder.Entity("Backend.DbModel.DbDoctor", b =>
                {
                    b.Property<string>("doctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clinicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ssn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("doctorId");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("Backend.DbModel.DbDoctorAppointmentTimes", b =>
                {
                    b.Property<string>("doctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("appointmentTime")
                        .HasColumnType("bigint");

                    b.HasKey("doctorId", "appointmentTime");

                    b.ToTable("doctorAppointmentTimes");
                });

            modelBuilder.Entity("Backend.DbModel.DbPatient", b =>
                {
                    b.Property<string>("patientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("birthday")
                        .HasColumnType("bigint");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ssn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("patientId");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Backend.DbModel.Specialization", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("name");

                    b.ToTable("specializations");
                });

            modelBuilder.Entity("Backend.Model.Appointment", b =>
                {
                    b.Property<int>("appointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("cancelled")
                        .HasColumnType("bit");

                    b.Property<long>("datetime")
                        .HasColumnType("bigint");

                    b.Property<string>("doctorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("symptoms")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("appointmentId");

                    b.ToTable("appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
