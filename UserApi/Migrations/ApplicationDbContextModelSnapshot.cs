using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserApi;
namespace UserApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);
            modelBuilder.Entity("UserApi.Model.EventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);
                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<int>("IdModel")
                        .HasColumnType("int");
                    b.Property<string>("TableModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("TimesTamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("Events");
                });
            modelBuilder.Entity("UserApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);
                    b.Property<string>("Cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("Users");
                });
        }
    }
}
