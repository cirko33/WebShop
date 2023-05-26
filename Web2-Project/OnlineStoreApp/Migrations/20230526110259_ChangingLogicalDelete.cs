using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangingLogicalDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Item");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Products",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 26, 13, 2, 58, 214, DateTimeKind.Local).AddTicks(1766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 21, 15, 11, 28, 880, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryTime", "OrderTime" },
                values: new object[] { new DateTime(2023, 5, 26, 14, 20, 58, 214, DateTimeKind.Local).AddTicks(5900), new DateTime(2023, 5, 26, 13, 2, 58, 214, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$rGOQOUdMkVesLansni9g/O.Uv8zlBQvUWZ5OsREUl.a4tcdn8j7I2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$5HCTHT6M.B5w/VR8jIH4VOE0pNN5jYaKRnKlvR6IjnDA2MUtD7rCu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$7MZXdOWlLRQs6vtvHbsckul6tSZLJVz3Cvd2LuWyCBErVrnQnZOGW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 21, 15, 11, 28, 880, DateTimeKind.Local).AddTicks(7749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 26, 13, 2, 58, 214, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryTime", "OrderTime" },
                values: new object[] { new DateTime(2023, 5, 21, 16, 29, 28, 881, DateTimeKind.Local).AddTicks(1554), new DateTime(2023, 5, 21, 15, 11, 28, 880, DateTimeKind.Local).AddTicks(7749) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: new byte[] { 84, 101, 115, 116 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Z4cM/mNaek.s99C62m4eE.5ZpzdfRXMC6mtfRihank6EYEH2FDb..");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$KR5w0bO3h6Ea1gify/lmlOKw1au/enlJ0jFO58XZ5Q0VptKKmscY6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$zuykXoZ3soFEBkcGPTbHheLCAmcPRkPsSRsR5ePm6.42ulV0D.AP6");
        }
    }
}
