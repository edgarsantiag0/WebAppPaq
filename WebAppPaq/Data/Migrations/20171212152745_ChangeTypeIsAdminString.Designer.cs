using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebAppPaq.Data;

namespace WebAppPaq.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171212152745_ChangeTypeIsAdminString")]
    partial class ChangeTypeIsAdminString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebAppPaq.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("IsAdmin");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.DetalleFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacturaId");

                    b.Property<decimal>("MontoEnvio");

                    b.Property<float>("PesoProducto");

                    b.Property<decimal>("Precio");

                    b.Property<int>("SucursalId");

                    b.Property<string>("TipoProducto");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("SucursalId");

                    b.ToTable("DetalleFactura");
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidoClienteEnvia");

                    b.Property<string>("ApellidoClienteRecibe");

                    b.Property<string>("CedulaClienteEnvia");

                    b.Property<string>("CedulaClienteRecibe");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("NombreClienteEnvia");

                    b.Property<string>("NombreClienteRecibe");

                    b.Property<int?>("SucursalId");

                    b.Property<string>("TelefonoClienteEnvia");

                    b.Property<string>("TelefonoClienteRecibe");

                    b.Property<decimal>("Total");

                    b.Property<string>("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("SucursalId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ciudad");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Direccion");

                    b.HasKey("Id");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DetalleFacturaId");

                    b.Property<int>("EstadoId");

                    b.HasKey("TrackId");

                    b.HasIndex("DetalleFacturaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebAppPaq.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebAppPaq.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAppPaq.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.DetalleFactura", b =>
                {
                    b.HasOne("WebAppPaq.Models.Paq.Factura", "Factura")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAppPaq.Models.Paq.Sucursal", "Sucursal")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.Factura", b =>
                {
                    b.HasOne("WebAppPaq.Models.Paq.Sucursal", "Sucursal")
                        .WithMany("Facturas")
                        .HasForeignKey("SucursalId");
                });

            modelBuilder.Entity("WebAppPaq.Models.Paq.Track", b =>
                {
                    b.HasOne("WebAppPaq.Models.Paq.DetalleFactura", "DetalleFactura")
                        .WithMany("Tracks")
                        .HasForeignKey("DetalleFacturaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAppPaq.Models.Paq.Estado", "Estado")
                        .WithMany("Tracks")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
