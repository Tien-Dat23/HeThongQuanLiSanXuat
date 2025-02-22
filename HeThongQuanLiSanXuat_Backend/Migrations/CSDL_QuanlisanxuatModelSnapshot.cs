﻿// <auto-generated />
using System;
using HeThongQuanLiSanXuat_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HeThongQuanLiSanXuat_Backend.Migrations
{
    [DbContext(typeof(CSDL_Quanlisanxuat))]
    partial class CSDL_QuanlisanxuatModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("department_code");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("department_name");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("DepartmentId")
                        .HasName("departments_pkey");

                    b.HasIndex(new[] { "DepartmentCode" }, "departments_department_code_key")
                        .IsUnique();

                    b.ToTable("departments");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Employee", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("department_id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.HasKey("Username")
                        .HasName("employees_pkey");

                    b.HasIndex("DepartmentId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("machine_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MachineId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("MachineCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("machine_code");

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("machine_name");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("serial_number");

                    b.HasKey("MachineId")
                        .HasName("machines_pkey");

                    b.ToTable("machines");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("product_code");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("product_name");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("unit");

                    b.HasKey("ProductId")
                        .HasName("products_pkey");

                    b.HasIndex(new[] { "ProductCode" }, "products_product_code_key")
                        .IsUnique();

                    b.ToTable("products");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.ProductionOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("order_code");

                    b.Property<string>("OrderName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("order_name");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("product_code");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("OrderId")
                        .HasName("production_orders_pkey");

                    b.HasIndex("ProductCode");

                    b.HasIndex(new[] { "OrderCode" }, "production_orders_order_code_key")
                        .IsUnique();

                    b.ToTable("production_orders");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("stage_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StageId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("StageCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("stage_code");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("stage_name");

                    b.HasKey("StageId")
                        .HasName("stages_pkey");

                    b.ToTable("stages");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Employee", b =>
                {
                    b.HasOne("HeThongQuanLiSanXuat_Backend.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("employees_department_id_fkey");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.ProductionOrder", b =>
                {
                    b.HasOne("HeThongQuanLiSanXuat_Backend.Model.Product", "ProductCodeNavigation")
                        .WithMany("ProductionOrders")
                        .HasForeignKey("ProductCode")
                        .HasPrincipalKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("production_orders_product_code_fkey");

                    b.Navigation("ProductCodeNavigation");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HeThongQuanLiSanXuat_Backend.Model.Product", b =>
                {
                    b.Navigation("ProductionOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
