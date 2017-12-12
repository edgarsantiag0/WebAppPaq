using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPaq.Data.Migrations
{
    public partial class ChangeTypeIsAdminString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Sucursal_SucursalId",
                table: "DetalleFactura");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "DetalleFactura",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsAdmin",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Sucursal_SucursalId",
                table: "DetalleFactura",
                column: "SucursalId",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Sucursal_SucursalId",
                table: "DetalleFactura");

            migrationBuilder.AlterColumn<int>(
                name: "SucursalId",
                table: "DetalleFactura",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Sucursal_SucursalId",
                table: "DetalleFactura",
                column: "SucursalId",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
