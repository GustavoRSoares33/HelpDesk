using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoDados.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public int Id_Chamado { get; set; }
        public string? Autor { get; set; }
        public string? Texto { get; set; }
        public DateTime DataHora { get; set; }
    }
}
