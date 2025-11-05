using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoDados.Models
{
    public class Chamado
    {
        public int? IdChamado { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTecnico { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdProblema { get; set; }
        public int? IdSolucao { get; set; }
        public string? Descricao { get; set; }
        public string? Prioridade { get; set; }
        public string? Status { get; set; }
        public string? NomeUsuario { get; set; }
        public string? NomeTecnico { get; set; }
        public string? NomeCategoria { get; set; }
        public int? Feedback { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
    }
}
