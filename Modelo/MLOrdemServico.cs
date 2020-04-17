using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLOrdemServico
    {
        public int OrdemServicoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataExecucao { get; set; }
        public int StatusId { get; set; }
        public double ValorTotal { get; set; }
        public int NrParcelas { get; set; }
        public string Observacao { get; set; }
        public int ClienteId { get; set; }

        public MLCliente Cliente { get; set; }
        public MLServico Servico { get; set; }
        public MLFormaPgto FormaPgto { get; set; }
        public List<MLOrdemServico_Produto> ListaProdutos { get; set; }
        public List<MLOrdemServico_Servico> ListaServicos { get; set; }

        public StatusOS StatusOrdemServico { get; set; }

        public enum StatusOS
        {
            ABERTO = 1,
            EXECUTANDO = 2,
            PAUSADA = 3,
            FINALIZADA = 4,
            CANCELADA = 5
        }
    }
}
