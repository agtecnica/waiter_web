using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Ferramentas
{
    public interface IMetodosCrudGui<T> where T : class
    {
        void HabilitarCampos(bool habilitar, Utils.Operacao operacao);

        bool ValidarCampos();

        void LerCampos();

        void CarregarCampos(int id = 0);

        void Salvar();

        void Excluir();

        void Cancelar();

        List<T> Localizar(T modelo);
        

    }
}
