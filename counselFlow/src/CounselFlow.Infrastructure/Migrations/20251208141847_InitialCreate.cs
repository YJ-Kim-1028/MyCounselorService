using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounselFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agent",
                columns: table => new
                {
                    agentId = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    ActiveYn = table.Column<string>(type: "text", nullable: false),
                    CrdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent", x => x.agentId);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    CrdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    tagId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CrdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.tagId);
                });

            migrationBuilder.CreateTable(
                name: "consult",
                columns: table => new
                {
                    consultId = table.Column<string>(type: "text", nullable: false),
                    AgentId = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Channel = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    StdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CrdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consult", x => x.consultId);
                    table.ForeignKey(
                        name: "FK_consult_agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "agent",
                        principalColumn: "agentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consult_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "consultTag",
                columns: table => new
                {
                    consultId = table.Column<string>(type: "text", nullable: false),
                    tagId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultTag", x => new { x.consultId, x.tagId });
                    table.ForeignKey(
                        name: "FK_consultTag_consult_consultId",
                        column: x => x.consultId,
                        principalTable: "consult",
                        principalColumn: "consultId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultTag_tag_tagId",
                        column: x => x.tagId,
                        principalTable: "tag",
                        principalColumn: "tagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consult_AgentId",
                table: "consult",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_consult_CustomerId",
                table: "consult",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_consultTag_tagId",
                table: "consultTag",
                column: "tagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultTag");

            migrationBuilder.DropTable(
                name: "consult");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropTable(
                name: "agent");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
