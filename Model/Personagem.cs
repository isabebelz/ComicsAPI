using System.ComponentModel.DataAnnotations;

namespace Comics.Model
{
    public class Personagem
    {
        [Key]
        public int IdPersoangem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Identidade { get; set; } = string.Empty;
        public ICollection<Autor>? Autores { get; set; }
        public ICollection<Artista>? Artistas { get; set; }
        public ICollection<Personagem>? Aliados { get; set; } 
        public ICollection<Personagem>? Inimigos { get; set; } 
        public ICollection<Equipe>? Equipes { get; set; }
        public ICollection<Comic>? Comics { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Habilidades { get; set; } = string.Empty;

    }
}