using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLParcelaPedido
    {
        public int Adicionar(MLParcelaPedido parcelaPedido)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                #region Paramentros da ParcelaPedido
                con.AdicionarParametros("@PedidoId", parcelaPedido.PedidoId);
                con.AdicionarParametros("@ParcelaNr", parcelaPedido.ParcelaNr);
                con.AdicionarParametros("@TotalParcelas", parcelaPedido.TotalParcelas);
                con.AdicionarParametros("@DataVencimento", parcelaPedido.DataVencimento);
                con.AdicionarParametros("@IntervaloId", parcelaPedido.IntervaloId);
                con.AdicionarParametros("@FormaPagtoId", parcelaPedido.FormaPagtoId);
                con.AdicionarParametros("@Cancelado", parcelaPedido.Cancelado);
                con.AdicionarParametros("@CondicaoPgtoId", parcelaPedido.CondicaoPgtoId);
                con.AdicionarParametros("@Valor", parcelaPedido.Valor);
                con.AdicionarParametros("@DataPagto", parcelaPedido.DataPagto);

                #endregion

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_InserirParcelaPedido"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLParcelaPedido parcelaPedido)
        {
            DlConexao con = new DlConexao();

            try
            {
                con.limparParametros();

                #region Paramentros da ParcelaPedido

                con.AdicionarParametros("@PedidoId", parcelaPedido.PedidoId);
                con.AdicionarParametros("@ParcelaNr", parcelaPedido.ParcelaNr);
                if (parcelaPedido.TotalParcelas > 0)
                    con.AdicionarParametros("@TotalParcelas", parcelaPedido.TotalParcelas);
                if (parcelaPedido.DataVencimento > DateTime.MinValue)
                    con.AdicionarParametros("@DataParcelaInicial", parcelaPedido.DataVencimento);
                if (parcelaPedido.IntervaloId > 0)
                    con.AdicionarParametros("@Intervalo", parcelaPedido.IntervaloId);
                if (parcelaPedido.FormaPagtoId > 0)
                    con.AdicionarParametros("@FormaPagtoId", parcelaPedido.FormaPagtoId);
                if (parcelaPedido.DataPagto == null || parcelaPedido.DataPagto > DateTime.MinValue)
                    con.AdicionarParametros("@DataPagto", parcelaPedido.DataPagto);
                if (parcelaPedido.Cancelado)
                    con.AdicionarParametros("@Cancelado", parcelaPedido.Cancelado);

                #endregion

                con.ExecutarManipulacao(CommandType.StoredProcedure, "P_AtualizarParcelaPedido");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MLParcelaPedido Consultar(MLParcelaPedido modelo)
        {

            return new MLParcelaPedido();
        }

        public List<MLParcelaPedido> Listar(MLParcelaPedido parcelasPedido)
        {
            DlConexao con = new DlConexao();
            var listaParcelasPedido = new List<MLParcelaPedido>();
            con.limparParametros();
            con.AdicionarParametros("@PedidoId", parcelasPedido.PedidoId);
            var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarParcelasPedido");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                parcelasPedido = Genericos.Popular<MLParcelaPedido>(dt, i);
                listaParcelasPedido.Add(parcelasPedido);
            }
            return listaParcelasPedido;
        }

        public void Excluir(int PedidoId)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@PedidoId", PedidoId);
                con.ExecutarManipulacao(CommandType.StoredProcedure, "P_Excluir_ParcelasPedido");//veirifica se existe parcelas e exclui

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con = null;
            }
        }
    }
}
