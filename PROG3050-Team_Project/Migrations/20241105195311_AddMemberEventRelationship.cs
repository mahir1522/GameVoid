using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberEventRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventMember");

            migrationBuilder.CreateTable(
                name: "MemberEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEvent", x => new { x.EventId, x.MemberID });
                    table.ForeignKey(
                        name: "FK_MemberEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberEvent_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberEvent_MemberID",
                table: "MemberEvent",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_MemberId",
                table: "Registrations",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberEvent");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.CreateTable(
                name: "EventMember",
                columns: table => new
                {
                    RegisteredEventsEventId = table.Column<int>(type: "int", nullable: false),
                    RegiteredMembersMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMember", x => new { x.RegisteredEventsEventId, x.RegiteredMembersMemberID });
                    table.ForeignKey(
                        name: "FK_EventMember_Events_RegisteredEventsEventId",
                        column: x => x.RegisteredEventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMember_Members_RegiteredMembersMemberID",
                        column: x => x.RegiteredMembersMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventMember_RegiteredMembersMemberID",
                table: "EventMember",
                column: "RegiteredMembersMemberID");
        }
    }
}
