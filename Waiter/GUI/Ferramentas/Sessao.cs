using Modelo;

namespace GUI.Ferramentas
{
    public class Sessao
    {
        public MLCaixa Caixa { get; set; }
        public MLUsuario Usuario { get; set; }
        public MLEmpresa Empresa { get; set; }
        public MLCliente Cliente { get; set; }
        public MLConfiguracaoGeral Configuracao { get; set; }
        public EnumTeste enunIsTeste { get; set; }
        public enum EnumTeste
        {
            SIM,
            NAO
        }

        private Sessao() 
        {
            if (Empresa == null)
                Empresa = new MLEmpresa();

            if (Usuario == null)
                Usuario = new MLUsuario();

            if (Caixa == null)
                Caixa = new MLCaixa();

            if (Cliente == null)
                Cliente = new MLCliente();

            if (Configuracao == null)
                Configuracao = new MLConfiguracaoGeral();
        }

        private static Sessao instance;

        public static Sessao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sessao();
                }
                return instance;
            }
        }
    }
}
