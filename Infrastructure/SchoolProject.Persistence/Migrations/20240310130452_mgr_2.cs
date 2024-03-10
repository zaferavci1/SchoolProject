using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicProfiles_Users_UserId2",
                table: "PublicProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PublicProfiles_UserId2",
                table: "PublicProfiles");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "PublicProfiles");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "PublicProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<Guid>(
                name: "PublicProfileId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "BasketName",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Baskets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "PublicProfilePublicProfile",
                columns: table => new
                {
                    FollowersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicProfilePublicProfile", x => new { x.FollowersId, x.FollowsId });
                    table.ForeignKey(
                        name: "FK_PublicProfilePublicProfile_PublicProfiles_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "PublicProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicProfilePublicProfile_PublicProfiles_FollowsId",
                        column: x => x.FollowsId,
                        principalTable: "PublicProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PublicProfileId",
                table: "Posts",
                column: "PublicProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicProfilePublicProfile_FollowsId",
                table: "PublicProfilePublicProfile",
                column: "FollowsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PublicProfiles_PublicProfileId",
                table: "Posts",
                column: "PublicProfileId",
                principalTable: "PublicProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PublicProfiles_PublicProfileId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PublicProfilePublicProfile");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PublicProfileId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PublicProfileId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BasketName",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "PublicProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId2",
                table: "PublicProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PublicProfiles_UserId2",
                table: "PublicProfiles",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicProfiles_Users_UserId2",
                table: "PublicProfiles",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
