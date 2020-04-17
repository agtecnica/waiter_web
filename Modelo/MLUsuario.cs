using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MLUsuario
    {
        public MLUsuario()
        {
        }

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool? Ativo { get; set; }
        public Nullable<short> Tentativas { get; set; }
        public string Observacao { get; set; }
        public Nullable<System.DateTime> DataExpiraSenha { get; set; }
        public int PermissaoId { get; set; }
        public bool? isGerente { get; set; }

        public virtual ICollection<MLPedido> Pedido { get; set; }
    }
}
