using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PutniNalogDataContext.PN.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mjesto_putovanja",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv_mjesta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mjesto_putovanja", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "putni_nalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datum_pocetka = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    datum_kraja = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    zaposlenik_id = table.Column<int>(type: "integer", nullable: false),
                    mjesto_putovanja_id = table.Column<int>(type: "integer", nullable: false),
                    vozilo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_putni_nalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "putni_troskovi",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iznos_troska = table.Column<double>(type: "double precision", nullable: true),
                    vrsta_troska_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_putni_troskovi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radno_mjesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radno_mjesto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vozilo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    marka = table.Column<string>(type: "text", nullable: true),
                    registracija = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vozilo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vrsta_troska",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vrsta_troska", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zaposlenik",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ime = table.Column<string>(type: "text", nullable: true),
                    prezime = table.Column<string>(type: "text", nullable: true),
                    ukupni_iznos_troska = table.Column<double>(type: "double precision", nullable: true),
                    radno_mjesto_id = table.Column<int>(type: "integer", nullable: false),
                    putni_troskovi_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zaposlenik", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mjesto_putovanja");

            migrationBuilder.DropTable(
                name: "putni_nalog");

            migrationBuilder.DropTable(
                name: "putni_troskovi");

            migrationBuilder.DropTable(
                name: "radno_mjesto");

            migrationBuilder.DropTable(
                name: "vozilo");

            migrationBuilder.DropTable(
                name: "vrsta_troska");

            migrationBuilder.DropTable(
                name: "zaposlenik");
        }
    }
}
