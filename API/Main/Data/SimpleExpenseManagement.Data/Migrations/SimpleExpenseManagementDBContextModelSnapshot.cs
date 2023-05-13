﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleExpenseManagement.Data;

#nullable disable

namespace SimpleExpenseManagement.Data.Migrations
{
    [DbContext(typeof(SimpleExpenseManagementDBContext))]
    partial class SimpleExpenseManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lookif.Layers.Core.MainCore.Identities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Lookif.Layers.Core.MainCore.Identities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Block")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastLoginDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<int>("AccountVisibilityStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("InitialValue")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("UserDetailId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Accounts.AccountVisibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AccountVisibilities");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Events.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("EventDefinition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Investments.Investment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FromAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<Guid>("FromUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ToAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<Guid>("ToUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeOfOperation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("FromUnitId");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("ToUnitId");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Loans.LoanDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LoanMasterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Paid")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime?>("PaidDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("LoanMasterId");

                    b.HasIndex("OperationId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Loans.LoanMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Freeze")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("InterestRate")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("OperationId");

                    b.ToTable("LoanMasters");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Operations.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeOfOperation")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("FromId");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("ToId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Tags.Operation_Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("OperationId");

                    b.HasIndex("TagId");

                    b.ToTable("Operation_Tags");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Tags.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Units.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Users.UserDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastEditedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LastEditedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Lookif.Layers.Core.MainCore.Identities.Role", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.Navigation("LastEditedUser");
                });

            modelBuilder.Entity("Lookif.Layers.Core.MainCore.Identities.User", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.Navigation("LastEditedUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Accounts.Account", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Users.UserDetail", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserDetailId");

                    b.Navigation("LastEditedUser");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Accounts.AccountVisibility", b =>
                {
                    b.HasOne("SimpleExpenseManagement.Core.Models.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("LastEditedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Events.Event", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.Navigation("LastEditedUser");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Investments.Investment", b =>
                {
                    b.HasOne("SimpleExpenseManagement.Core.Models.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SimpleExpenseManagement.Core.Models.Units.Unit", "FromUnit")
                        .WithMany()
                        .HasForeignKey("FromUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Units.Unit", "ToUnit")
                        .WithMany()
                        .HasForeignKey("ToUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("FromUnit");

                    b.Navigation("LastEditedUser");

                    b.Navigation("ToUnit");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Loans.LoanDetail", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Loans.LoanMaster", "LoanMaster")
                        .WithMany("LoanDetails")
                        .HasForeignKey("LoanMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SimpleExpenseManagement.Core.Models.Operations.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId");

                    b.Navigation("LastEditedUser");

                    b.Navigation("LoanMaster");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Loans.LoanMaster", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Operations.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId");

                    b.Navigation("LastEditedUser");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Operations.Operation", b =>
                {
                    b.HasOne("SimpleExpenseManagement.Core.Models.Events.Event", "Event")
                        .WithMany("Operations")
                        .HasForeignKey("EventId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Accounts.Account", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Accounts.Account", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.Navigation("Event");

                    b.Navigation("From");

                    b.Navigation("LastEditedUser");

                    b.Navigation("To");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Tags.Operation_Tag", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("SimpleExpenseManagement.Core.Models.Operations.Operation", "Operation")
                        .WithMany("Tags")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SimpleExpenseManagement.Core.Models.Tags.Tag", "Tag")
                        .WithMany("Operations")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LastEditedUser");

                    b.Navigation("Operation");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Tags.Tag", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.Navigation("LastEditedUser");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Units.Unit", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.Navigation("LastEditedUser");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Users.UserDetail", b =>
                {
                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "LastEditedUser")
                        .WithMany()
                        .HasForeignKey("LastEditedUserId");

                    b.HasOne("Lookif.Layers.Core.MainCore.Identities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LastEditedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Events.Event", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Loans.LoanMaster", b =>
                {
                    b.Navigation("LoanDetails");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Operations.Operation", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Tags.Tag", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("SimpleExpenseManagement.Core.Models.Users.UserDetail", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
