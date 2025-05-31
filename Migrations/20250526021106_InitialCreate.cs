using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScriptureNotesBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scriptures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ref = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scriptures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Joined_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMembers_StudyGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "StudyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteScriptures",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "integer", nullable: false),
                    ScriptureId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteScriptures", x => new { x.NoteId, x.ScriptureId });
                    table.ForeignKey(
                        name: "FK_NoteScriptures_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteScriptures_Scriptures_ScriptureId",
                        column: x => x.ScriptureId,
                        principalTable: "Scriptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    NoteId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteTags_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTags_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Scriptures",
                columns: new[] { "Id", "Ref", "Text" },
                values: new object[,]
                {
                    { 1, "3 John 1", "The elder to the beloved Gaius, whom I love in truth." },
                    { 2, "3 John 2", "Beloved, I pray that all may go well with you and that you may be in good health, as it goes well with your soul." },
                    { 3, "3 John 3", "For I rejoiced greatly when the brothers came and testified to your truth, as indeed you are walking in the truth." },
                    { 4, "3 John 4", "I have no greater joy than to hear that my children are walking in the truth." },
                    { 5, "3 John 5", "Beloved, it is a faithful thing you do in all your efforts for these brothers, strangers as they are, " },
                    { 6, "3 John 6", "who testified to your love before the church. You will do well to send them on their journey in a manner worthy of God." },
                    { 7, "3 John 7", "For they have gone out for the sake of the name, accepting nothing from the Gentiles." },
                    { 8, "3 John 8", "Therefore we ought to support people like these, that we may be fellow workers for the truth." },
                    { 9, "3 John 9", "I have written something to the church, but Diotrephes, who likes to put himself first, does not acknowledge our authority. " },
                    { 10, "3 John 10", "So if I come, I will bring up what he is doing, talking wicked nonsense against us. And not content with that, he refuses to welcome the brothers, and also stops those who want to and puts them out of the church." },
                    { 11, "3 John 11", "Beloved, do not imitate evil but imitate good. Whoever does good is from God; whoever does evil has not seen God." },
                    { 12, "3 John 12", "Demetrius has received a good testimony from everyone, and from the truth itself. We also add our testimony, and you know that our testimony is true." },
                    { 13, "3 John 13", "I had much to write to you, but I would rather not write with pen and ink." },
                    { 14, "3 John 14", "I hope to see you soon, and we will talk face to face." },
                    { 15, "3 John 15", "Peace be to you. The friends greet you. Greet the friends, each by name." }
                });

            migrationBuilder.InsertData(
                table: "StudyGroups",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Uid" },
                values: new object[,]
                {
                    { 11, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(7928), "This is group 1", "Group 1", null },
                    { 12, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(8165), "This is group 2", "Group 2", null },
                    { 13, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(8166), "This is group 3", "Group 3", null },
                    { 14, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(8167), "This is group 4", "Group 4", null },
                    { 15, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(8168), "This is group 5", "Group 5", null }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "Uid" },
                values: new object[,]
                {
                    { 100, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(4441), "Faith", null },
                    { 200, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(4748), "Doctrine", null },
                    { 300, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(4749), "Love", null },
                    { 400, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(4750), "Repentence", null },
                    { 500, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(4751), "Peace", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Uid", "UserName" },
                values: new object[,]
                {
                    { 1111, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(1408), "user1@gmail.com", "one", "user1" },
                    { 2222, new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(1680), "user2@gmail.com", "two", "user2" }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Joined_At", "Uid", "UserId" },
                values: new object[,]
                {
                    { 10, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1362), 11, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1584), "one", 1111 },
                    { 20, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1801), 12, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1801), "two", 2222 },
                    { 30, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1803), 13, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1803), "two", 1111 },
                    { 40, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1804), 14, new DateTime(2025, 5, 26, 2, 11, 3, 511, DateTimeKind.Utc).AddTicks(1804), "one", 2222 }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedAt", "Title", "Uid", "UserId" },
                values: new object[,]
                {
                    { 111, "This is the first note.", new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(4720), "Note 1", "one", 1111 },
                    { 222, "This is the second note.", new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(4951), "Note 2", "two", 2222 },
                    { 333, "This is the third note.", new DateTime(2025, 5, 26, 2, 11, 3, 510, DateTimeKind.Utc).AddTicks(4952), "Note 3", "one", 1111 }
                });

            migrationBuilder.InsertData(
                table: "NoteScriptures",
                columns: new[] { "NoteId", "ScriptureId", "CreatedAt", "Id", "Uid" },
                values: new object[,]
                {
                    { 111, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 222, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 333, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null }
                });

            migrationBuilder.InsertData(
                table: "NoteTags",
                columns: new[] { "Id", "NoteId", "TagId", "Uid", "UserId" },
                values: new object[,]
                {
                    { 101, 111, 100, null, null },
                    { 202, 111, 200, null, null },
                    { 303, 222, 300, null, null },
                    { 404, 222, 400, null, null },
                    { 505, 333, 500, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteScriptures_ScriptureId",
                table: "NoteScriptures",
                column: "ScriptureId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteTags_NoteId",
                table: "NoteTags",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteTags_TagId",
                table: "NoteTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteTags_UserId",
                table: "NoteTags",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "NoteScriptures");

            migrationBuilder.DropTable(
                name: "NoteTags");

            migrationBuilder.DropTable(
                name: "StudyGroups");

            migrationBuilder.DropTable(
                name: "Scriptures");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
