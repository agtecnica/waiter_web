using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLServico : IMetodos<MLServico>
    {
        public int Adicionar(MLServico servico)
        {
            DlConexao con = new DlConexao();
            con.limparParametros();
            int id = 0;

            con.AdicionarParametros("@Descricao", servico.Descricao);
            con.AdicionarParametros("@Ativo", servico.Ativo);
            con.AdicionarParametros("@PrevisaoDias", servico.PrevisaoDias);
            con.AdicionarParametros("@Valor", servico.Valor);
            con.AdicionarParametros("@Observacao", servico.Observacao);

            id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirServico"));

            return id;
        }

        public void Atualizar(MLServico servico)
        {
            DlConexao con = new DlConexao();
            con.limparParametros();
            int id = 0;

            con.AdicionarParametros("@ServicoId", servico.ServicoId);
            con.AdicionarParametros("@Descricao", servico.Descricao);
            con.AdicionarParametros("@Ativo", servico.Ativo);
            con.AdicionarParametros("@PrevisaoDias", servico.PrevisaoDias);
            con.AdicionarParametros("@Valor", servico.Valor);
            con.AdicionarParametros("@Observacao", servico.Observacao);

            id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarServico"));

        }

        public void Excluir(int id)
        {
            DlConexao con = new DlConexao();

            con.limparParametros();
            con.AdicionarParametros("@ServicoId", id);

            con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_ExcluirServico");
        }

        public MLServico Consultar(MLServico servico)
        {
            DlConexao con = new DlConexao();
            List<MLServico> lstServico = new List<MLServico>();

            con.limparParametros();
            con.AdicionarParametros("@ServicoId", servico.ServicoId);

            var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarServico");// "Cliente cadastrado com sucesso!"


            if (dt.Rows.Count > 0)
            {
                servico = new MLServico();
                servico = Genericos.Popular<MLServico>(dt, 0);
            }
            return servico;
        }

        public List<MLServico> Listar(MLServico servico)
        {
            DlConexao con = new DlConexao();
            List<MLServico> lstServico = new List<MLServico>();

            con.limparParametros();

            if (servico.ServicoId > 0)
                con.AdicionarParametros("@ServicoId", servico.ServicoId);
            if (servico.Descricao != null)
                con.AdicionarParametros("@Descricao", servico.Descricao);
            con.AdicionarParametros("@Ativo", servico.Ativo);
            if (servico.PrevisaoDias > 0)
                con.AdicionarParametros("@PrevisaoDias", servico.PrevisaoDias);
            if (servico.Valor > 0)
                con.AdicionarParametros("@Valor", servico.Valor);
            if (!string.IsNullOrEmpty(servico.Observacao))
                con.AdicionarParametros("@Observacao", servico.Observacao);

            var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarServico");// "Cliente cadastrado com sucesso!"

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                servico = new MLServico();
                servico = Genericos.Popular<MLServico>(dt, i);

                lstServico.Add(servico);
            }
            return lstServico;
        }
    }
}
