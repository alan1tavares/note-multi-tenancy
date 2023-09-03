using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupsId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_User_UsersId",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "GroupUser",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "GroupUser",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                newName: "IX_GroupUser_UserId1");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "GroupUser",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GroupUser",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser",
                columns: new[] { "GroupId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_GroupId1",
                table: "GroupUser",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserId",
                table: "GroupUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupId",
                table: "GroupUser",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupId1",
                table: "GroupUser",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_User_UserId",
                table: "GroupUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_User_UserId1",
                table: "GroupUser",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupId1",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_User_UserId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_User_UserId1",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupUser_GroupId1",
                table: "GroupUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupUser_UserId",
                table: "GroupUser");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "GroupUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupUser");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "GroupUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "GroupUser",
                newName: "GroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUser_UserId1",
                table: "GroupUser",
                newName: "IX_GroupUser_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupsId",
                table: "GroupUser",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_User_UsersId",
                table: "GroupUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
