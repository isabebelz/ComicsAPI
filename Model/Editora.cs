using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.Model
{
    public class Editora
    {
        [Key]
        public int IdEditora { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Comic>? Comics { get; set; }
    }
}