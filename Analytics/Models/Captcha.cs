using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Analytics
{
    public class Captcha
    {
        /// <summary>
        /// código para verificar se a validação do captcha foi feito com sucesso
        /// </summary>
        /// <param name="encodedResponse">codigo gerado pelo google no clientside</param>
        /// <returns>valido ou inválido</returns>
        public bool ValidarCaptcha(string encodedResponse)
        {
            try
            {
                if (string.IsNullOrEmpty(encodedResponse)) return false;

                var secret = "6LdmFjYUAAAAALBVVP4mgi7Jvfj8hSP14XgKXUQw";
                if (string.IsNullOrEmpty(secret)) return false;

                WebClient client = new WebClient();
                WebProxy proxy = new WebProxy("proxy.credit.local", 8088);
                proxy.Credentials = new NetworkCredential("automatizacaobi", "th7WruR!", "creditcash.com.br");
                client.Proxy = proxy;

                var googleReply = client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={encodedResponse}");

                return JsonConvert.DeserializeObject<RecaptchaResponse>(googleReply).Success;
            }
            catch (Exception e)
            {
                throw new Exception("Erro na validação do capcha: " + e.Message);
            }

        }
    }

    internal class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public IEnumerable<string> ErrorCodes { get; set; }

        [JsonProperty("challenge_ts")]
        public DateTime ChallengeTs { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }
    }

}