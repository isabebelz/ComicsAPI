using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.DTOs.Request.Autor
{
    public class UpdateAutorRequestDto
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}