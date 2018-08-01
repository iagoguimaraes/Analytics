using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;



namespace Analytics.Controllers
{
    [RoutePrefix("api/monitoria")]
    public class MonitoriaController : ApiController
    {

        [Route("consultar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage ConsultarDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string grupos = form["grupos"];
                string empresas = form["empresas"];
                string carteiras = form["carteiras"];
                string ocorrencias = form["ocorrencias"];
                string usuarios = form["usuarios"];
                string problemas = form["problemas"];

                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(string.Concat(dtfim, " 23:59:59"));

                DataTable _grupos = JsonConvert.DeserializeObject<DataTable>(grupos);
                DataTable _empresas = JsonConvert.DeserializeObject<DataTable>(empresas);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);
                DataTable _ocorrencias = JsonConvert.DeserializeObject<DataTable>(ocorrencias);
                DataTable _usuarios = JsonConvert.DeserializeObject<DataTable>(usuarios);
                DataTable _problemas = JsonConvert.DeserializeObject<DataTable>(problemas);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("dtini", _dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", _dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("grupos", _grupos);
                    parametros.Add("empresas", _empresas);
                    parametros.Add("carteiras", _carteiras);
                    parametros.Add("ocorrencias", _ocorrencias);
                    parametros.Add("usuarios", _usuarios);
                    parametros.Add("problemas", _problemas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("opcoes")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage OpcoesDiarioBordo()
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_opcoes_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("inserir")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage InserirDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                int id_empresa = Convert.ToInt32(form["empresa"]);

                string nomeCredor = CredorName(id_empresa);

                string teste = historico(nomeCredor);

                string data = form["data"];
                string hora = form["hora"];
                int id_grupo = Convert.ToInt32(form["grupo"]);
                //int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                int id_campanha = Convert.ToInt32(form["campanha"]);
                string descricao = form["descricao"];
                string cpf = form["cpf"];
                string tel = form["tel"];
                string persona = form["persona"];
                string link = form["link"];
                int id_problema = Convert.ToInt32(form["problemas"]);
                int id_fornecedor = Convert.ToInt32(form["fornecedores"]);
                int nivel = Convert.ToInt32(form["nvproblema"]);

                link = link.Substring(link.IndexOf(',') + 1);

                byte[] Arquivo = Convert.FromBase64String(link);
                string arquivo2 = System.Text.Encoding.Default.GetString(Arquivo);
                string teltratado = tel.Replace(")", "").Replace("(", "").Replace("-", "");
                string nameFile = teste + '\\' + nomeCredor + '_' + id_campanha + '_' + teltratado;
                nameFile = nameFile + ".wav";



                File.WriteAllBytes(nameFile, Convert.FromBase64String(link));



                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", _data);
                    parametros.Add("id_grupo", id_grupo);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_campanha", id_campanha);
                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("descricao", descricao);
                    parametros.Add("cpf", cpf);
                    parametros.Add("tel", tel);
                    parametros.Add("persona", persona);
                    parametros.Add("link", nameFile);
                    parametros.Add("problema", id_problema);
                    parametros.Add("fornecedor", id_fornecedor);
                    parametros.Add("nivel", nivel);


                    sql.ExecuteProcedureDataSet("sp_ins_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("editar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage EditarDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                int id_monitoria = Convert.ToInt32(form["id"]);
                string data = form["data"];
                string hora = form["hora"];
                int id_grupo = Convert.ToInt32(form["grupo"]);
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                int id_campanha = Convert.ToInt32(form["campanha"]);
                string cpf = (form["cpf"]);
                string tel = (form["tel"]);
                string persona = (form["persona"]);
                string descricao = form["descricao"];
                string link = form["link"];
                int id_problema = Convert.ToInt32(form["problemas"]);
                int id_fornecedor = Convert.ToInt32(form["fornecedores"]);
                int nivel = Convert.ToInt32(form["nvproblema"]);

                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_monitoria", id_monitoria);
                    parametros.Add("data", _data);
                    parametros.Add("id_grupo", id_grupo);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("id_campanha", id_campanha);
                    parametros.Add("cpf", cpf);
                    parametros.Add("tel", tel);
                    parametros.Add("persona", persona);
                    parametros.Add("descricao", descricao);
                    parametros.Add("link", link);
                    parametros.Add("problema", id_problema);
                    parametros.Add("fornecedor", id_fornecedor);
                    parametros.Add("nivel", nivel);

                    sql.ExecuteProcedureDataSet("sp_upd_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("remover")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage RemoverDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                int id_diario_bordo = Convert.ToInt32(form["id"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("id_monitoria", id_diario_bordo);

                    sql.ExecuteProcedureDataSet("sp_del_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("download")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage gerarFile(FormDataCollection form)
        {

            string caminho = (form["caminho"]);

            using (MemoryStream ms = new MemoryStream())
            using (FileStream file = new FileStream(caminho, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                string arquivo2 = System.Text.Encoding.Default.GetString(bytes);
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);


                // processing the stream.
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.ToArray())
                };
                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "Som.wav"
                    };

                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                return result;
            }

        }


        [Route("pesquisa")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage InserirPesquisa(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];



                int id_usuario = sessao.id_usuario;
                string resposta1 = (form["questao1[resposta1]"]) + form["questao1[resposta2]"] + form["questao1[resposta3]"] + form["questao1[resposta4]"] + form["questao1[resposta5]"] + form["questao1[resposta6]"] + form["questao1[resposta7]"];
                string complemento1 = form["questao1[complemento]"];
                string resposta2 = (form["questao2[resposta1]"]) + form["questao2[resposta2]"] + form["questao2[resposta3]"] + form["questao2[resposta4]"] + form["questao2[resposta5]"] + form["questao2[resposta6]"] + form["questao2[resposta7]"];
                string complemento2 = form["questao2[complemento]"]; 
                string resposta3 = (form["questao3[resposta1]"]) + form["questao3[resposta2]"] + form["questao3[resposta3]"] + form["questao3[resposta4]"] + form["questao3[resposta5]"] + form["questao3[resposta6]"];
                string resposta4 = (form["questao4[resposta1]"]) + form["questao4[resposta2]"] + form["questao4[resposta3]"] + form["questao4[resposta4]"] + form["questao4[resposta5]"];
                string complemento4 = form["questao4[complemento]"]; 
                string resposta5 = (form["questao5[resposta1]"]) + form["questao5[resposta2]"] + form["questao5[resposta3]"] + form["questao5[resposta4]"] + form["questao5[resposta5]"]; ;
                string complemento5 = form["questao5[complemento]"];
                string resposta6 = form["questao6[complemento]"];
                string resposta7 = (form["questao7[resposta1]"]) + form["questao7[resposta2]"] + form["questao7[resposta3]"] + form["questao7[resposta4]"] + form["questao7[resposta5]"] + form["questao7[resposta6]"] + form["questao7[resposta7]"] + form["questao7[resposta8]"] + form["questao7[resposta9]"] + form["questao7[resposta10]"];



                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("iduser", id_usuario);
                    parametros.Add("resposta1", resposta1);
                    parametros.Add("complemento1", complemento1);
                    parametros.Add("resposta2", resposta2);
                    parametros.Add("complemento2", complemento2);
                    parametros.Add("resposta3", resposta3);
                    parametros.Add("resposta4", resposta4);
                    parametros.Add("complemento4", complemento4);
                    parametros.Add("resposta5", resposta5);
                    parametros.Add("complemento5", complemento5);
                    parametros.Add("resposta6", resposta6);
                    parametros.Add("resposta7", resposta7);

                    sql.ExecuteProcedureDataSet("sp_ins_pesquisa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public static string CredorName(int id_credor)
        {
            try
            {


                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    string nomeCredor = null;
                    parametros.Add("id_credor", id_credor);
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_credor_nome", parametros);

                    nomeCredor = resultado.Tables[0].Rows[0]["empresa"].ToString();

                    return nomeCredor;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static string historico(string credor)
        {
            //Tratativas para envio ao historico.
            string data = System.DateTime.Now.ToString("yyyyMMdd");
            string ano = data.Substring(0, 4);
            string mesInt = data.Substring(4, 2);
            string dia = data.Substring(6, 2);
            string mesTxt = null;
            bool validador = false;

            switch (mesInt)
            {
                case "01":
                    mesTxt = "01 Jan";
                    break;
                case "02":
                    mesTxt = "02 Fev";
                    break;
                case "03":
                    mesTxt = "03 Mar";
                    break;
                case "04":
                    mesTxt = "04 Abr";
                    break;
                case "05":
                    mesTxt = "05 Mai";
                    break;
                case "06":
                    mesTxt = "06 Jun";
                    break;
                case "07":
                    mesTxt = "07 Jul";
                    break;
                case "08":
                    mesTxt = "08 Ago";
                    break;
                case "09":
                    mesTxt = "09 Set";
                    break;
                case "10":
                    mesTxt = "10 Out";
                    break;
                case "11":
                    mesTxt = "11 Nov";
                    break;
                case "12":
                    mesTxt = "12 Dez";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            bool validadorDia = true;
            string pathDestDay = @"\\venezuela\GravacoesDigital\" + ano + "\\" + mesTxt + "\\" + dia + "";
            string pathDest = @"\\venezuela\GravacoesDigital\" + ano + "\\" + mesTxt;
            string path = @"\\venezuela\GravacoesDigital\" + ano;
            string pathDestCredor = @"\\venezuela\GravacoesDigital\" + ano + "\\" + mesTxt + "\\" + dia + "\\" + credor;
            string newPath2 = newPath2 = System.IO.Path.Combine(pathDestDay, credor);
            string[] entries = Directory.GetFileSystemEntries(path, "*"); /*Verifxa pasta do dia*/
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].Equals(pathDest))
                {
                    Console.WriteLine("Pasta do dia ja existe.");
                    validadorDia = false;

                    string[] files2 = Directory.GetFileSystemEntries(pathDestDay, "*");
                    for (int j = 1; j <= files2.Length; j++) /*Verifxa pasta do credor*/
                    {

                        if (files2[(j - 1)].Equals(pathDestCredor))
                        {
                            Console.WriteLine("Pasta do credor ja existe.");
                            validador = true;
                            break;
                        }

                    }

                    if (validador == false)
                    {
                        newPath2 = System.IO.Path.Combine(pathDestDay, credor);
                        System.IO.Directory.CreateDirectory(newPath2);
                        Console.WriteLine("Criou pasta " + credor);
                    }

                }
            }

            if (validadorDia == true)
            {
                System.IO.Directory.CreateDirectory(pathDest);
                Console.WriteLine("Pasta do mes.");
            }



            if (validadorDia == true)
            {
                Console.WriteLine("Pasta do dia não existe.");
                string newPath = System.IO.Path.Combine(pathDest, dia);
                System.IO.Directory.CreateDirectory(newPath);
                Console.WriteLine("Pasta do dia criada.");

                newPath2 = System.IO.Path.Combine(pathDestDay, credor);
                System.IO.Directory.CreateDirectory(newPath2);
                Console.WriteLine("Criou pasta " + credor);

            }
            return newPath2;
        }


    }
}
