﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class addintIdforeing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagsId",
                table: "NewsArticles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "NewsArticles");
        }
    }
}
