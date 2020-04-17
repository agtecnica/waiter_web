using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLControleMovimento
    {
        public int COntroleMovimentoId { get; set; }
        public int CaixaId { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime? HoraFechamento { get; set; }
        public decimal Saldo { get; set; }
        public string MotivoDivergencia { get; set; }
        public decimal Suprimento { get; set; }
        public decimal Sangria { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal ValorDivergencia { get; set; }
        public int UsuarioFechamentoId { get; set; }
        public int UsuarioAberturaId { get; set; }
    }
}
