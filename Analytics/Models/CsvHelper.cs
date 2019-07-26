using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Analytics.Models
{
    public class CsvHelper
    {
        private void ValidarTelefone(string numero)
        {
            long n;
            long.TryParse(numero, out n);

            if (n == 0)
            {
                throw new Exception("Coluna TELEFONE não pode conter textos ou carácter especial");
            }
        }

        public DataTable CarregarArquivoSimples(string arquivo, int id_lote)
        {
            try
            {
                string[] str = new string[] { "\r\n" };
                string[] linhas = arquivo.Split(str, StringSplitOptions.None);

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("telefone");
                dataTable.Columns.Add("mensagem");
                dataTable.Columns.Add("cpf");
                dataTable.Columns.Add("id_lote", typeof(int)).DefaultValue = id_lote;

                try
                {
                    for (int i = 1; i < linhas.Length - 1; i++)
                    {
                        DataRow row = dataTable.NewRow();
                        row.ItemArray = linhas[i].Split(';');
                        ValidarTelefone(row.ItemArray[0].ToString());
                        dataTable.Rows.Add(row);
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw new Exception("Arquivo não possui a quantidade correta de colunas para este layout");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DataTable CarregarArquivoClaroTv(string arquivo, int id_lote)
        {
            try
            {
                string[] str = new string[] { "\r\n" };
                string[] linhas = arquivo.Split(str, StringSplitOptions.None);

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("CLI_NOME_USUAL");
                dataTable.Columns.Add("PRODUTO");
                dataTable.Columns.Add("CAR_DESCRICAO");
                dataTable.Columns.Add("NOME");
                dataTable.Columns.Add("DEV_ID");
                dataTable.Columns.Add("DEV_NOME");
                dataTable.Columns.Add("DEV_CPF");
                dataTable.Columns.Add("AGN_NOME");
                dataTable.Columns.Add("LINHA_DIGITAVEL");
                dataTable.Columns.Add("AGENCIA_ATUAL");
                dataTable.Columns.Add("ACORDO");
                dataTable.Columns.Add("ID_ACORDO");
                dataTable.Columns.Add("TIPO_ACORDO");
                dataTable.Columns.Add("PARCELA");
                dataTable.Columns.Add("ACO_DATA");
                dataTable.Columns.Add("ACO_DATA_REGISTRO");
                dataTable.Columns.Add("VECTO_PARCELA");
                dataTable.Columns.Add("ACP_VALOR_PARCELA");
                dataTable.Columns.Add("VALOR_TOTAL_ACORDO");
                dataTable.Columns.Add("STATUS_PARCELA");
                dataTable.Columns.Add("EMAIL");
                dataTable.Columns.Add("EMAIL2");
                dataTable.Columns.Add("TELEFONE_CONTATO_FIXO");
                dataTable.Columns.Add("TELEFONE_CONTATO_CELULAR");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_FIXO");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_CELULAR");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_2_FIXO");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_2_CELULAR");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_3_FIXO");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_3_CELULAR");
                dataTable.Columns.Add("TELEFONE_ATUALIZADO_FIXO");
                dataTable.Columns.Add("TELEFONE_ATUALIZADO_CELULAR");
                dataTable.Columns.Add("OUTROS_FIXO");
                dataTable.Columns.Add("OUTROS_CELULAR");
                dataTable.Columns.Add("Contrato");
                dataTable.Columns.Add("AGING_ACORDO");
                dataTable.Columns.Add("STATUS_CONTRATO_NET");
                dataTable.Columns.Add("id_lote", typeof(int)).DefaultValue = id_lote;

                try
                {
                    for (int i = 1; i < linhas.Length - 1; i++)
                    {
                        DataRow row = dataTable.NewRow();
                        row.ItemArray = linhas[i].Split(';');
                        dataTable.Rows.Add(row);
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw new Exception("Arquivo não possui a quantidade correta de colunas para este layout");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DataTable CarregarArquivoClaroMovel(string arquivo, int id_lote)
        {
            try
            {
                string[] str = new string[] { "\r\n" };
                string[] linhas = arquivo.Split(str, StringSplitOptions.None);

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("CLI_NOME_USUAL");
                dataTable.Columns.Add("PRODUTO");
                dataTable.Columns.Add("CAR_DESCRICAO");
                dataTable.Columns.Add("NOME");
                dataTable.Columns.Add("DEV_ID");
                dataTable.Columns.Add("DEV_NOME");
                dataTable.Columns.Add("DEV_CPF");
                dataTable.Columns.Add("AGN_NOME");
                dataTable.Columns.Add("LINHA_DIGITAVEL");
                dataTable.Columns.Add("AGENCIA_ATUAL");
                dataTable.Columns.Add("ACORDO");
                dataTable.Columns.Add("ID_ACORDO");
                dataTable.Columns.Add("TIPO_ACORDO");
                dataTable.Columns.Add("PARCELA");
                dataTable.Columns.Add("ACO_DATA");
                dataTable.Columns.Add("ACO_DATA_REGISTRO");
                dataTable.Columns.Add("VECTO_PARCELA");
                dataTable.Columns.Add("ACP_VALOR_PARCELA");
                dataTable.Columns.Add("VALOR_TOTAL_ACORDO");
                dataTable.Columns.Add("STATUS_PARCELA");
                dataTable.Columns.Add("EMAIL");
                dataTable.Columns.Add("EMAIL2");
                dataTable.Columns.Add("TELEFONE_CONTATO_FIXO");
                dataTable.Columns.Add("TELEFONE_CONTATO_CELULAR");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_FIXO");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_CELULAR");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_2_FIXO");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_2_CELULAR");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_3_FIXO");
                dataTable.Columns.Add("TELEFONE_CONFIRMADO_3_CELULAR");
                dataTable.Columns.Add("TELEFONE_ATUALIZADO_FIXO");
                dataTable.Columns.Add("TELEFONE_ATUALIZADO_CELULAR");
                dataTable.Columns.Add("OUTROS_FIXO");
                dataTable.Columns.Add("OUTROS_CELULAR");
                dataTable.Columns.Add("Contrato");
                dataTable.Columns.Add("AGING_ACORDO");
                dataTable.Columns.Add("STATUS_CONTRATO_NET");
                dataTable.Columns.Add("id_lote", typeof(int)).DefaultValue = id_lote;

                try
                {
                    for (int i = 1; i < linhas.Length - 1; i++)
                    {
                        DataRow row = dataTable.NewRow();
                        row.ItemArray = linhas[i].Split(';');
                        dataTable.Rows.Add(row);
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw new Exception("Arquivo não possui a quantidade correta de colunas para este layout");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DataTable CarregarArquivoNet(string arquivo, int id_lote)
        {
            try
            {
                string[] str = new string[] { "\r\n" };
                string[] linhas = arquivo.Split(str, StringSplitOptions.None);

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Credor");
                dataTable.Columns.Add("Carteira");
                dataTable.Columns.Add("Negociador");
                dataTable.Columns.Add("Senha");
                dataTable.Columns.Add("Devedor");
                dataTable.Columns.Add("CPF");
                dataTable.Columns.Add("Cobradora_atual");
                dataTable.Columns.Add("Cobradora_acordo");
                dataTable.Columns.Add("ACORDO");
                dataTable.Columns.Add("Tipo_Acordo");
                dataTable.Columns.Add("Plano");
                dataTable.Columns.Add("Data_acordo");
                dataTable.Columns.Add("Data_Registro");
                dataTable.Columns.Add("Vencimento_parcela");
                dataTable.Columns.Add("Valor_parcela");
                dataTable.Columns.Add("Valor_acordo");
                dataTable.Columns.Add("Status_acordo");
                dataTable.Columns.Add("Linha_Digitavel");
                dataTable.Columns.Add("Email");
                dataTable.Columns.Add("Email2");
                dataTable.Columns.Add("Telefone_contato_Fixo");
                dataTable.Columns.Add("Telefone_contato_Celular");
                dataTable.Columns.Add("Telefone_Confirmado_Fixo");
                dataTable.Columns.Add("Telefone_Confirmado_Celular");
                dataTable.Columns.Add("Telefone_Confirmado_2_Fixo");
                dataTable.Columns.Add("Telefone_Confirmado_2_Celular");
                dataTable.Columns.Add("Telefone_Confirmado_3_Fixo");
                dataTable.Columns.Add("Telefone_Confirmado_3_Celular");
                dataTable.Columns.Add("Telefone_Atualizado_Fixo");
                dataTable.Columns.Add("Telefone_Atualizado_Celular");
                dataTable.Columns.Add("Outro_Fixo");
                dataTable.Columns.Add("Outro_Celular");
                dataTable.Columns.Add("Contrato");
                dataTable.Columns.Add("Aging_Acordo");
                dataTable.Columns.Add("Status_Contrato_Net");
                dataTable.Columns.Add("id_lote", typeof(int)).DefaultValue = id_lote;

                try
                {
                    for (int i = 1; i < linhas.Length - 1; i++)
                    {
                        DataRow row = dataTable.NewRow();
                        row.ItemArray = linhas[i].Split(';');
                        dataTable.Rows.Add(row);
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw new Exception("Arquivo não possui a quantidade correta de colunas para este layout");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}