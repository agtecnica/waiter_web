using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLConfiguracaoGeral
    {
        public TipoImpressao tipoImpressoraPDV { get; set; }
        public TipoImpressao tipoImpressoraVendaPadrao { get; set; }
        public TipoImpressao TipoImpressoraControleMovimento { get; set; }
        public int QtdeCopiasImpressaoPDV { get; set; }
        public int QtdeCopiasImpressaoVendaPadrao { get; set; }
        public int QtdeCopiasImpressaoControleMovimento { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime DataExpiracaoLicenca { get; set; }

        public int ImpressoraPadraoId { get; set; }
        public string ImpressoraPadrao { get; set; }

        public int MiniImpressoraPadraoId { get; set; }
        public string MiniImpressoraPadrao { get; set; }

        public  enum TipoImpressao
        {
            NaoFiscal = 1,
            PadraoA4 = 2
        }
    }
}
