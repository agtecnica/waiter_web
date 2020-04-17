using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public interface IMetodos<T> where T : class
    {
        int Adicionar(T modelo);
        void Atualizar(T modelo);
        void Excluir(int id);
        T Consultar(T modelo);
        List<T> Listar(T modelo);
    }
}
