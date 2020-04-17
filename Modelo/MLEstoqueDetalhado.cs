using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLEstoqueDetalhado
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorVenda { get; set; }
        public int QtdeMinEstoque { get; set; }
        public int QtdeMaxEstoque { get; set; }
        public decimal EstoqueReal { get; set; }
        public DateTime? DataUltEntrada { get; set; }
        public DateTime? DataUltSaida { get; set; }
    }
}
