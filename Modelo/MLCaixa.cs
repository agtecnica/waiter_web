using System;

namespace Modelo
{
    public class MLCaixa 
    {
        public MLCaixa()
        {
            Usuario = new MLUsuario();
        }
            public Int32 CaixaId { get; set; }
        public String CaixaDescricao { get; set; }
        public bool? Status { get; set; }
        public String StatusDescricao { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoFinal { get; set; }
        public DateTime? DataHoraAbertura { get; set; }
        public DateTime? DataHoraFechamento { get; set; }
        public String FuncionarioNome { get; set; }
        public int CaixaStatusLogId { get; set; }

        public MLUsuario Usuario { get; set; }
        public int ControleMovimentoCaixaId { get; set; }
        public MLControleMovimento ControleMovimento { get; set; }

        public enum CaixaStatusLog
        {
            Aberto = 1,
            Fechado = 2,
            Login = 3
        }
    }
}
