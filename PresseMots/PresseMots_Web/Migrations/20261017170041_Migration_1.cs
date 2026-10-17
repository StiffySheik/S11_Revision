using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresseMots.Migrations
{
    /// <inheritdoc />
    public partial class Migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryTag");

            migrationBuilder.CreateTable(
                name: "StoryTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryTags_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoryTags_StoryId",
                table: "StoryTags",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryTags_TagId",
                table: "StoryTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryTags");

            migrationBuilder.CreateTable(
                name: "StoryTag",
                columns: table => new
                {
                    StoryIdId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryTag", x => new { x.StoryIdId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_StoryTag_Stories_StoryIdId",
                        column: x => x.StoryIdId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoryTag_TagsId",
                table: "StoryTag",
                column: "TagsId");
        }
    }
}
