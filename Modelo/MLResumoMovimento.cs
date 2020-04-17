using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLResumoMovimento
    {
        public int ControleMovimentoCaixaId { get; set; }
        public int CaixaId { get; set; }
        public string Guiche { get; set; }
        public decimal Faturamento { get; set; }
        public decimal TrocoInicial { get; set; }
        public decimal Suprimento { get; set; }
        public decimal Sangria { get; set; }
        public decimal Total { get; set; }
        public decimal Boleto { get; set; }
        public decimal Cheque { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Dinheiro { get; set; }
        public string MotivoDivergencia { get; set; }
        public decimal ValorDivergencia { get; set; }
        public int QtdePedidos { get; set; }
        public decimal TotalPedidos { get; set; }
    }
}
