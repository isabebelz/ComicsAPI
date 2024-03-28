using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comics.Enum;

namespace Comics.Model
{
    public class Comic 
    {
        [Key]
        public int IdComic { get; set; }
        [ForeignKey("Editora")]
        public int IdEditora { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int NumeroEdicao { get; set; }
        public int AnoLancamento { get; set; }
        public ICollection<Autor>? Autores { get; set; } 
        public ICollection<Personagem>? Personagens { get; set; } 
        public ICollection<Artista>? Artistas { get; set; }
        public Editora? Editora { get; set; }
        public ComicStatus ComicStatus  { get; set; }
        public string Sinopse { get; set; } = string.Empty;
    }
}