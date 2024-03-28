using System.ComponentModel.DataAnnotations;

namespace Comics.Model
{
    public class Artista
    {
        [Key]
        public int IdArtista { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Personagem>? Personagens  { get; set; }
    }
}