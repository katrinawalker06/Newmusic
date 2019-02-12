using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newmusic.Data.Migrations
{
    public partial class severaltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Band",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BandName = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    BandSize = table.Column<int>(nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BandMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Instrument = table.Column<string>(nullable: true),
                    BandName = table.Column<string>(nullable: true),
                    BandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BandMember_Band_BandId",
                        column: x => x.BandId,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BandMemberBand",
                columns: table => new
                {
                    BandMemberBandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BandMemberId = table.Column<int>(nullable: false),
                    BandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandMemberBand", x => x.BandMemberBandId);
                    table.ForeignKey(
                        name: "FK_BandMemberBand_Band_BandId",
                        column: x => x.BandId,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandMemberBand_BandMember_BandMemberId",
                        column: x => x.BandMemberId,
                        principalTable: "BandMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandMember_BandId",
                table: "BandMember",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_BandMemberBand_BandId",
                table: "BandMemberBand",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_BandMemberBand_BandMemberId",
                table: "BandMemberBand",
                column: "BandMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandMemberBand");

            migrationBuilder.DropTable(
                name: "BandMember");

            migrationBuilder.DropTable(
                name: "Band");
        }
    }
}
