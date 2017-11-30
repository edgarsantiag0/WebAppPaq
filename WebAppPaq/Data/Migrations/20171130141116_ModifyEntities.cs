using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPaq.Data.Migrations
{
    public partial class ModifyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Sucursal_Sucursal1Id",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Sucursal_Sucursal2Id",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_Sucursal1Id",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Sucursal1Id",
                table: "Factura");

            migrationBuilder.RenameColumn(
                name: "TelefonoCliente",
                table: "Factura",
                newName: "TelefonoClienteRecibe");

            migrationBuilder.RenameColumn(
                name: "Sucursal2Id",
                table: "Factura",
                newName: "SucursalId");

            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "Factura",
                newName: "TelefonoClienteEnvia");

            migrationBuilder.RenameColumn(
                name: "CedulaCliente",
                table: "Factura",
                newName: "NombreClienteRecibe");

            migrationBuilder.RenameColumn(
                name: "ApellidoCliente",
                table: "Factura",
                newName: "NombreClienteEnvia");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_Sucursal2Id",
                table: "Factura",
                newName: "IX_Factura_SucursalId");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoClienteEnvia",
                table: "Factura",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoClienteRecibe",
                table: "Factura",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CedulaClienteEnvia",
                table: "Factura",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CedulaClienteRecibe",
                table: "Factura",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "DetalleFactura",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_SucursalId",
                table: "DetalleFactura",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Sucursal_SucursalId",
                table: "DetalleFactura",
                column: "SucursalId",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Sucursal_SucursalId",
                table: "Factura",
                column: "SucursalId",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Sucursal_SucursalId",
                table: "DetalleFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Sucursal_SucursalId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_SucursalId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "ApellidoClienteEnvia",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ApellidoClienteRecibe",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "CedulaClienteEnvia",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "CedulaClienteRecibe",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "DetalleFactura");

            migrationBuilder.RenameColumn(
                name: "TelefonoClienteRecibe",
                table: "Factura",
                newName: "TelefonoCliente");

            migrationBuilder.RenameColumn(
                name: "TelefonoClienteEnvia",
                table: "Factura",
                newName: "NombreCliente");

            migrationBuilder.RenameColumn(
                name: "SucursalId",
                table: "Factura",
                newName: "Sucursal2Id");

            migrationBuilder.RenameColumn(
                name: "NombreClienteRecibe",
                table: "Factura",
                newName: "CedulaCliente");

            migrationBuilder.RenameColumn(
                name: "NombreClienteEnvia",
                table: "Factura",
                newName: "ApellidoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_SucursalId",
                table: "Factura",
                newName: "IX_Factura_Sucursal2Id");

            migrationBuilder.AddColumn<int>(
                name: "Sucursal1Id",
                table: "Factura",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Sucursal1Id",
                table: "Factura",
                column: "Sucursal1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Sucursal_Sucursal1Id",
                table: "Factura",
                column: "Sucursal1Id",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Sucursal_Sucursal2Id",
                table: "Factura",
                column: "Sucursal2Id",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
