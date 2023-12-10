﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test8.DB;

#nullable disable

namespace test8.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20221024215531_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("test8.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(7520));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(370),
                            FirstName = "yan",
                            LastName = "Maxim"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(470),
                            FirstName = "han",
                            LastName = "axim"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(470),
                            FirstName = "jan",
                            LastName = "amine"
                        });
                });

            modelBuilder.Entity("test8.Model.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(8030));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1530),
                            Name = "hello world",
                            categorie = "science"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1540),
                            Name = "life is good",
                            categorie = "romance"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1540),
                            Name = "wolf",
                            categorie = "horour"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1550),
                            Name = "docker",
                            categorie = "science"
                        });
                });

            modelBuilder.Entity("test8.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(8490));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Article = "no article",
                            BlogId = 1,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1980),
                            Title = "seremonie 1"
                        },
                        new
                        {
                            Id = 2,
                            Article = "no article",
                            BlogId = 1,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1990),
                            Title = "seremonie 2"
                        },
                        new
                        {
                            Id = 3,
                            Article = "no article",
                            BlogId = 2,
                            CreateDate = new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1990),
                            Title = "minasia"
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(8980));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FirstName")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "naie",
                            LastName = "nina",
                            _NumberPhone = "06611112577"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "noa",
                            LastName = "nella",
                            _NumberPhone = "06611112588"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "joelle",
                            LastName = "tisa",
                            _NumberPhone = "06611112599"
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(9380));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasCheckConstraint("CK_OrderDate", "[DeleveryDate] > [OrderDate]");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(9860));

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");

                    b.HasCheckConstraint("CheckQuantityNotEqualZero", "[OrderQuantity] >= 0");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            OrderQuantity = 3
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2,
                            OrderQuantity = 2
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2,
                            OrderQuantity = 5
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 2,
                            OrderQuantity = 2
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 5,
                            OrderQuantity = 4
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(370));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("productCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("productCategoryId");

                    b.ToTable("Products");

                    b.HasCheckConstraint("CK_AvailableQuantity", "[AvailableQuantity] >= 0");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 22,
                            Name = "hp omen 15",
                            productCategoryId = 3
                        },
                        new
                        {
                            Id = 2,
                            AvailableQuantity = 11,
                            Name = "asus 15",
                            productCategoryId = 3
                        },
                        new
                        {
                            Id = 3,
                            AvailableQuantity = 46,
                            Name = "s22",
                            productCategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            AvailableQuantity = 17,
                            Name = "ihone 12",
                            productCategoryId = 2
                        },
                        new
                        {
                            Id = 5,
                            AvailableQuantity = 80,
                            Name = "noelle",
                            productCategoryId = 1
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(890));

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "book"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "phone"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "laptop"
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.ProductCategoryProperty", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductPropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(1330));

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductCategoryId", "ProductPropertyId");

                    b.HasIndex("ProductPropertyId");

                    b.ToTable("ProductCategoryProperty");

                    b.HasData(
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 1
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 2
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 3
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 4
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 5
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 6
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 7
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 9
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductPropertyId = 12
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductPropertyId = 1
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductPropertyId = 7
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductPropertyId = 9
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductPropertyId = 13
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductPropertyId = 14
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductPropertyId = 12
                        },
                        new
                        {
                            ProductCategoryId = 1,
                            ProductPropertyId = 10
                        },
                        new
                        {
                            ProductCategoryId = 1,
                            ProductPropertyId = 11
                        },
                        new
                        {
                            ProductCategoryId = 1,
                            ProductPropertyId = 12
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.ProductProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(1810));

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("productProperties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PropertyName = "screen_size"
                        },
                        new
                        {
                            Id = 2,
                            PropertyName = "cpu_version"
                        },
                        new
                        {
                            Id = 3,
                            PropertyName = "cpu_type"
                        },
                        new
                        {
                            Id = 4,
                            PropertyName = "gpu_type"
                        },
                        new
                        {
                            Id = 5,
                            PropertyName = "gpu_version"
                        },
                        new
                        {
                            Id = 6,
                            PropertyName = "storage_type"
                        },
                        new
                        {
                            Id = 7,
                            PropertyName = "storage"
                        },
                        new
                        {
                            Id = 9,
                            PropertyName = "ram_storage"
                        },
                        new
                        {
                            Id = 10,
                            PropertyName = "author"
                        },
                        new
                        {
                            Id = 11,
                            PropertyName = "book_category"
                        },
                        new
                        {
                            Id = 12,
                            PropertyName = "mark"
                        },
                        new
                        {
                            Id = 13,
                            PropertyName = "arm_type"
                        },
                        new
                        {
                            Id = 14,
                            PropertyName = "arm_version"
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.ProductPropertyValue", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductPropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(2240));

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId", "ProductPropertyId");

                    b.HasIndex("ProductPropertyId");

                    b.ToTable("productPropertyValues");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 1,
                            Value = "15"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 2,
                            Value = "i7 10gen"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 3,
                            Value = "intel"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 4,
                            Value = "nvidia"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 5,
                            Value = "rtx 2060"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 6,
                            Value = "ssd m.2"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 7,
                            Value = "1To"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 9,
                            Value = "16Go"
                        },
                        new
                        {
                            ProductId = 1,
                            ProductPropertyId = 12,
                            Value = "hp"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 1,
                            Value = "16"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 2,
                            Value = "amd ryzen 5"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 3,
                            Value = "amd"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 4,
                            Value = "amd"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 5,
                            Value = "amd 6650"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 6,
                            Value = "hdd"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 7,
                            Value = "550go"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 9,
                            Value = "16Go"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductPropertyId = 12,
                            Value = "asus"
                        },
                        new
                        {
                            ProductId = 5,
                            ProductPropertyId = 10,
                            Value = "zack maid"
                        },
                        new
                        {
                            ProductId = 5,
                            ProductPropertyId = 11,
                            Value = "action"
                        });
                });

            modelBuilder.Entity("test8.Model.Shop.ShippingAdresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Maroc");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(2710));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("shippingAdresses");

                    b.HasCheckConstraint("CheckZipCode", "[ZipCode] between 100 and 9999");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "casablanca",
                            OrderId = 1,
                            ZipCode = 4000
                        },
                        new
                        {
                            Id = 2,
                            City = "casablanca",
                            OrderId = 2,
                            ZipCode = 6000
                        },
                        new
                        {
                            Id = 3,
                            City = "rabat",
                            OrderId = 3,
                            ZipCode = 2000
                        });
                });

            modelBuilder.Entity("test8.Model.Blog", b =>
                {
                    b.HasOne("test8.Model.Author", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("test8.Model.Post", b =>
                {
                    b.HasOne("test8.Model.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("test8.Model.Shop.Order", b =>
                {
                    b.HasOne("test8.Model.Shop.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("test8.Model.Shop.OrderDetails", b =>
                {
                    b.HasOne("test8.Model.Shop.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test8.Model.Shop.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("test8.Model.Shop.Product", b =>
                {
                    b.HasOne("test8.Model.Shop.ProductCategory", "productCategory")
                        .WithMany("products")
                        .HasForeignKey("productCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productCategory");
                });

            modelBuilder.Entity("test8.Model.Shop.ProductCategoryProperty", b =>
                {
                    b.HasOne("test8.Model.Shop.ProductCategory", "productCategory")
                        .WithMany("productCategoryProperties")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test8.Model.Shop.ProductProperty", "productProperty")
                        .WithMany("productCategoryProperties")
                        .HasForeignKey("ProductPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productCategory");

                    b.Navigation("productProperty");
                });

            modelBuilder.Entity("test8.Model.Shop.ProductPropertyValue", b =>
                {
                    b.HasOne("test8.Model.Shop.Product", "product")
                        .WithMany("productPropertiesValue")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test8.Model.Shop.ProductProperty", "ProductProperty")
                        .WithMany("productPropertyValue")
                        .HasForeignKey("ProductPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductProperty");

                    b.Navigation("product");
                });

            modelBuilder.Entity("test8.Model.Shop.ShippingAdresse", b =>
                {
                    b.HasOne("test8.Model.Shop.Order", "Order")
                        .WithOne("shippingAdresse")
                        .HasForeignKey("test8.Model.Shop.ShippingAdresse", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("test8.Model.Author", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("test8.Model.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("test8.Model.Shop.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("test8.Model.Shop.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("shippingAdresse")
                        .IsRequired();
                });

            modelBuilder.Entity("test8.Model.Shop.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("productPropertiesValue");
                });

            modelBuilder.Entity("test8.Model.Shop.ProductCategory", b =>
                {
                    b.Navigation("productCategoryProperties");

                    b.Navigation("products");
                });

            modelBuilder.Entity("test8.Model.Shop.ProductProperty", b =>
                {
                    b.Navigation("productCategoryProperties");

                    b.Navigation("productPropertyValue");
                });
#pragma warning restore 612, 618
        }
    }
}
