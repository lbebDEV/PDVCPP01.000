using PDVCPP01._000.Config;
using PDVCPP01._000.Guardian;
using PDVCPP01._000.Model;
using PDVCPP01._000.ServiceLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.DAO
{
    class PedidoItemDAO
    {
        Guardian_Util guardian_Util = new Guardian_Util();

        public void Inserir(List<Item> pedidoItem, string nomeRotina, SqlConnection connection, SqlTransaction transaction, int recno)
        {
            string query = "";

            try
            {
                foreach (var item in pedidoItem)
                {
                    byte[] qrCode = Encoding.UTF8.GetBytes(guardian_Util.FormatarCaracter(item.codigo_qrcode));

                    query =
                        "INSERT INTO " + Tabelas_Guardian.ZA6 + " " +
                        "(ZA6_FILIAL, ZA6_IDITEM, ZA6_IDPED, ZA6_IDCOMB, " +
                        "ZA6_IDPROD, ZA6_NOME, ZA6_QUANT, ZA6_VUNIT, " +
                        "ZA6_EAN, ZA6_UNIDAD, ZA6_VDESCO, ZA6_VACRES, " +
                        "ZA6_IMPOST, ZA6_ICMSCS, ZA6_ICMSAL, ZA6_ICMSBA, " +
                        "ZA6_PISCST, ZA6_PISALI, ZA6_PISBAS, ZA6_COFCST, " +
                        "ZA6_COFALI, ZA6_COFBAS, ZA6_CFOP, ZA6_IBPTFE, " +
                        "ZA6_IBPTIM, ZA6_IBPTES, ZA6_IBPTMU, ZA6_IBTPCH, " +
                        "ZA6_CEST, ZA6_NCM, ZA6_OBS, ZA6_STATUS, " +
                        "ZA6_CANCEL, ZA6_PAGO, ZA6_MOTCAN, ZA6_GUIUNQ, " +
                        "ZA6_EX, ZA6_DTCAD, ZA6_DTALTE, ZA6_DTEXCL, " +
                        "ZA6_ACRPER, ZA6_DESPER, ZA6_PRODTA, ZA6_PIDITE, " +
                        "ZA6_TPIMP, ZA6_ISSQNN, ZA6_ISSQNA, ZA6_ISSQNB, " +
                        "ZA6_ISSQNI, ZA6_ISSQNC, ZA6_ISSQNL, ZA6_PRECO, " +
                        "ZA6_IDCAT, ZA6_NOMCAT, ZA6_VALCAT, ZA6_FTCAT, " +
                        "ZA6_IDFORN, ZA6_NMFORN, ZA6_MUNFOR, ZA6_EANTRI, " +
                        "ZA6_CUPOM, ZA6_IMPRES, ZA6_CODINT, ZA6_TPVEND, " +
                        "ZA6_GRATIS, ZA6_CONSUM, ZA6_IDCONS, ZA6_REDBCE, " +
                        "ZA6_BCEFE, ZA6_PICMSE, ZA6_VICMSE, ZA6_PIDUSU, " +
                        "ZA6_IDCLI, ZA6_QTDEST, ZA6_QRCODE, ZA6_FORN, " +
                        "D_E_L_E_T_, R_E_C_N_O_, R_E_C_D_E_L_, ZA6_LOGINC, ZA6_LOGINT) " +
                        "VALUES " +
                        "(" +
                        "'', " +
                        "'" + item.id_tbl_pedido_item + "', " +
                        "'" + item.fk_tbl_pedido_item_id_pedido + "', " +
                        "'" + item.fk_tbl_pedido_item_id_combo + "', " +
                        "'" + item.fk_tbl_pedido_item_id_produto + "', " +
                        "'" + item.nome + "', " +
                        "'" + item.quantidade + "', " +
                        "'" + item.valor_unitario + "', " +
                        "'" + item.ean + "', " +
                        "'" + item.unidade + "', " +
                        "'" + item.desconto + "', " +
                        "'" + item.acrescimo + "', " +
                        "'" + item.imposto + "', " +
                        "'" + item.icms_cst_saida + "', " +
                        "'" + item.icms_aliquota_saida + "', " +
                        "'" + item.icms_base_saida + "', " +
                        "'" + item.pis_cst_saida + "', " +
                        "'" + item.pis_aliquota_saida + "', " +
                        "'" + item.pis_base_saida + "', " +
                        "'" + item.cofins_cst_saida + "', " +
                        "'" + item.cofins_aliquota_saida + "', " +
                        "'" + item.cofins_base_saida + "', " +
                        "'" + item.cfop_saida + "', " +
                        "'" + item.ibpt_federal + "', " +
                        "'" + item.ibpt_importa + "', " +
                        "'" + item.ibpt_estadual + "', " +
                        "'" + item.ibpt_municipal + "', " +
                        "'" + item.ibpt_chave + "', " +
                        "'" + item.cest + "', " +
                        "'" + item.ncm + "', " +
                        "'" + item.observacao + "', " +
                        "'" + item.status + "', " +
                        "'" + item.cancelado + "', " +
                        "'" + item.pago + "', " +
                        "'" + item.cancelado_motivo + "', " +
                        "'" + item.guid_unique + "', " +
                        "'" + item.ex + "', " +
                        "'" + item.dt_cadastro + "', " +
                        "'" + item.dt_alteracao + "', " +
                        "'" + item.dt_exclusao + "', " +
                        "'" + item.acrescimo_percentual + "', " +
                        "'" + item.desconto_percentual + "', " +
                        "'" + item.fk_tbl_pedido_item_id_produto_tamanho + "', " +
                        "'" + item.fk_tbl_pedido_item_id_pedido_item + "', " +
                        "'" + item.tipo_imposto + "', " +
                        "'" + item.issqn_natop + "', " +
                        "'" + item.issqn_aliquota + "', " +
                        "'" + item.issqn_base + "', " +
                        "'" + item.issqn_indincfisc + "', " +
                        "'" + item.issqn_codtributacao + "', " +
                        "'" + item.issqn_listserv + "', " +
                        "'" + item.preco_dependente + "', " +
                        "'" + item.fk_tbl_pedido_item_id_categoria + "', " +
                        "'" + item.nome_categoria + "', " +
                        "'" + item.dt_validade_categoria + "', " +
                        "'" + item.foto_categoria + "', " +
                        "'" + item.fk_tbl_pedido_item_id_fornecedor + "', " +
                        "'" + item.nome_fantasia_sobrenome_fornecedor + "', " +
                        "'" + item.cidade_fornecedor + "', " +
                        "'" + item.ean_trib + "', " +
                        "'" + item.id_cupom + "', " +
                        "'" + item.impressao + "', " +
                        "'" + item.codigo_interno + "', " +
                        "'" + item.venda_tipo + "', " +
                        "'" + item.gratis + "', " +
                        "'" + item.consumir + "', " +
                        "'" + item.dt_consumido + "', " +
                        "'" + item.pRedBCEfet + "', " +
                        "'" + item.vBCEfet + "', " +
                        "'" + item.pICMSEfet + "', " +
                        "'" + item.vICMSEfet + "', " +
                        "'" + item.fk_tbl_pedido_item_id_usuario + "', " +
                        "'" + item.identificador_cliente + "', " +
                        "'" + item.qtde_estoque + "', " +
                        "@qrcode, " +
                        "'', " + //Tag fornecedor - Rodrigo solicitou que o campo fique vazio
                        "'', " +
                        "" + recno + "," +
                        "'', " +
                        "'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "', " +
                        "'')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Transaction = transaction;
                        command.Parameters.AddWithValue("@qrcode", qrCode);
                        command.ExecuteNonQuery();
                        recno++;
                    }
                }
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de item do Pedido. Query:" + query + "/ EX: " + ex.ToString());
                Guardian_LogTxt.LogAplicacao(Service_Config.NomeServico, query + " | " + ex.ToString());
                throw ex;
            }
        }
    }
}
