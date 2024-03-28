using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comics.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    IdEditora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.IdEditora);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.IdEquipe);
                });

            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    IdComic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEditora = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEdicao = table.Column<int>(type: "int", nullable: false),
                    AnoLancamento = table.Column<int>(type: "int", nullable: false),
                    ComicStatus = table.Column<int>(type: "int", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.IdComic);
                    table.ForeignKey(
                        name: "FK_Comics_Editoras_IdEditora",
                        column: x => x.IdEditora,
                        principalTable: "Editoras",
                        principalColumn: "IdEditora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    IdArtista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComicIdComic = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.IdArtista);
                    table.ForeignKey(
                        name: "FK_Artistas_Comics_ComicIdComic",
                        column: x => x.ComicIdComic,
                        principalTable: "Comics",
                        principalColumn: "IdComic");
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    IdPersoangem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilidades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComicIdComic = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.IdPersoangem);
                    table.ForeignKey(
                        name: "FK_Personagens_Comics_ComicIdComic",
                        column: x => x.ComicIdComic,
                        principalTable: "Comics",
                        principalColumn: "IdComic");
                });

            migrationBuilder.CreateTable(
                name: "ArtistaPersonagem",
                columns: table => new
                {
                    ArtistasIdArtista = table.Column<int>(type: "int", nullable: false),
                    PersonagensIdPersoangem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistaPersonagem", x => new { x.ArtistasIdArtista, x.PersonagensIdPersoangem });
                    table.ForeignKey(
                        name: "FK_ArtistaPersonagem_Artistas_ArtistasIdArtista",
                        column: x => x.ArtistasIdArtista,
                        principalTable: "Artistas",
                        principalColumn: "IdArtista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistaPersonagem_Personagens_PersonagensIdPersoangem",
                        column: x => x.PersonagensIdPersoangem,
                        principalTable: "Personagens",
                        principalColumn: "IdPersoangem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonagemIdPersoangem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                    table.ForeignKey(
                        name: "FK_Autores_Personagens_PersonagemIdPersoangem",
                        column: x => x.PersonagemIdPersoangem,
                        principalTable: "Personagens",
                        principalColumn: "IdPersoangem");
                });

            migrationBuilder.CreateTable(
                name: "EquipePersonagem",
                columns: table => new
                {
                    EquipesIdEquipe = table.Column<int>(type: "int", nullable: false),
                    MembrosIdPersoangem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipePersonagem", x => new { x.EquipesIdEquipe, x.MembrosIdPersoangem });
                    table.ForeignKey(
                        name: "FK_EquipePersonagem_Equipes_EquipesIdEquipe",
                        column: x => x.EquipesIdEquipe,
                        principalTable: "Equipes",
                        principalColumn: "IdEquipe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipePersonagem_Personagens_MembrosIdPersoangem",
                        column: x => x.MembrosIdPersoangem,
                        principalTable: "Personagens",
                        principalColumn: "IdPersoangem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemPersonagem",
                columns: table => new
                {
                    AliadosIdPersoangem = table.Column<int>(type: "int", nullable: false),
                    InimigosIdPersoangem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemPersonagem", x => new { x.AliadosIdPersoangem, x.InimigosIdPersoangem });
                    table.ForeignKey(
                        name: "FK_PersonagemPersonagem_Personagens_AliadosIdPersoangem",
                        column: x => x.AliadosIdPersoangem,
                        principalTable: "Personagens",
                        principalColumn: "IdPersoangem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemPersonagem_Personagens_InimigosIdPersoangem",
                        column: x => x.InimigosIdPersoangem,
                        principalTable: "Personagens",
                        principalColumn: "IdPersoangem");
                });

            migrationBuilder.CreateTable(
                name: "AutorComic",
                columns: table => new
                {
                    AutoresIdAutor = table.Column<int>(type: "int", nullable: false),
                    ComicsIdComic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorComic", x => new { x.AutoresIdAutor, x.ComicsIdComic });
                    table.ForeignKey(
                        name: "FK_AutorComic_Autores_AutoresIdAutor",
                        column: x => x.AutoresIdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorComic_Comics_ComicsIdComic",
                        column: x => x.ComicsIdComic,
                        principalTable: "Comics",
                        principalColumn: "IdComic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistaPersonagem_PersonagensIdPersoangem",
                table: "ArtistaPersonagem",
                column: "PersonagensIdPersoangem");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_ComicIdComic",
                table: "Artistas",
                column: "ComicIdComic");

            migrationBuilder.CreateIndex(
                name: "IX_AutorComic_ComicsIdComic",
                table: "AutorComic",
                column: "ComicsIdComic");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_PersonagemIdPersoangem",
                table: "Autores",
                column: "PersonagemIdPersoangem");

            migrationBuilder.CreateIndex(
                name: "IX_Comics_IdEditora",
                table: "Comics",
                column: "IdEditora");

            migrationBuilder.CreateIndex(
                name: "IX_EquipePersonagem_MembrosIdPersoangem",
                table: "EquipePersonagem",
                column: "MembrosIdPersoangem");

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemPersonagem_InimigosIdPersoangem",
                table: "PersonagemPersonagem",
                column: "InimigosIdPersoangem");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_ComicIdComic",
                table: "Personagens",
                column: "ComicIdComic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistaPersonagem");

            migrationBuilder.DropTable(
                name: "AutorComic");

            migrationBuilder.DropTable(
                name: "EquipePersonagem");

            migrationBuilder.DropTable(
                name: "PersonagemPersonagem");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Comics");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
