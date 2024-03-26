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
                name: "FK_UserFollower_User_FolloweeId",
                table: "UserFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollower_User_FollowerId",
                table: "UserFollower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollower",
                table: "UserFollower");

            migrationBuilder.RenameTable(
                name: "UserFollower",
                newName: "UserFollowers");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollower_FollowerId",
                table: "UserFollowers",
                newName: "IX_UserFollowers_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers",
                columns: new[] { "FolloweeId", "FollowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_User_FolloweeId",
                table: "UserFollowers",
                column: "FolloweeId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_User_FollowerId",
                table: "UserFollowers",
                column: "FollowerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_User_FolloweeId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_User_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers");

            migrationBuilder.RenameTable(
                name: "UserFollowers",
                newName: "UserFollower");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowers_FollowerId",
                table: "UserFollower",
                newName: "IX_UserFollower_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollower",
                table: "UserFollower",
                columns: new[] { "FolloweeId", "FollowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollower_User_FolloweeId",
                table: "UserFollower",
                column: "FolloweeId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollower_User_FollowerId",
                table: "UserFollower",
                column: "FollowerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
