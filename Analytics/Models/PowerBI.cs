using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Analytics
{
    public class PowerBI
    {
        public async Task<EmbedConfig> CarregarDashboard(string WorkspaceId, string ReportId)
        {
            // variáveis
            string Username = "powerbi@creditcash.com.br";
            string Password = "BICr3d!tC@s#LTD4";
            string AuthorityUrl = "https://login.microsoftonline.com/common/oauth2/authorize";
            string ResourceUrl = "https://analysis.windows.net/powerbi/api";
            string ApplicationId = "328e3482-e5a3-45da-b48a-d1f391f57c58";
            string ApiUrl = "https://api.powerbi.com";
            //string WorkspaceId = "544d9d10-0068-480c-a7f6-6bf26c2c6279";
            //string ReportId = "0baf7dd7-17fb-4545-8b8c-95c0580a7e70";
            string username = null;
            string roles = null;

            var result = new EmbedConfig();

            result = new EmbedConfig { Username = username, Roles = roles };

            // Create a user password cradentials.
            var credential = new UserPasswordCredential(Username, Password);

            // Authenticate using created credentials
            var authenticationContext = new AuthenticationContext(AuthorityUrl);
            var authenticationResult = await authenticationContext.AcquireTokenAsync(ResourceUrl, ApplicationId, credential);

            if (authenticationResult == null)
                throw new Exception("Falha na autenticação do PowerBI");

            var tokenCredentials = new TokenCredentials(authenticationResult.AccessToken, "Bearer");

            // Create a Power BI Client object. It will be used to call Power BI APIs.
            using (var client = new PowerBIClient(new Uri(ApiUrl), tokenCredentials))
            {
                // Get a list of reports.
                var reports = await client.Reports.GetReportsInGroupAsync(WorkspaceId);

                // No reports retrieved for the given workspace.
                if (reports.Value.Count() == 0)
                    throw new Exception("Não foram encontrados relatórios neste espaço de trabalho");

                Report report;
                if (string.IsNullOrWhiteSpace(ReportId))
                {
                    // Get the first report in the workspace.
                    report = reports.Value.FirstOrDefault();
                }
                else
                {
                    report = reports.Value.FirstOrDefault(r => r.Id == ReportId);
                }

                if (report == null)
                    throw new Exception("ReportID inválido");


                var datasets = await client.Datasets.GetDatasetByIdInGroupAsync(WorkspaceId, report.DatasetId);
                result.IsEffectiveIdentityRequired = datasets.IsEffectiveIdentityRequired;
                result.IsEffectiveIdentityRolesRequired = datasets.IsEffectiveIdentityRolesRequired;
                GenerateTokenRequest generateTokenRequestParameters;
                // This is how you create embed token with effective identities
                if (!string.IsNullOrWhiteSpace(username))
                {
                    var rls = new EffectiveIdentity(username, new List<string> { report.DatasetId });
                    if (!string.IsNullOrWhiteSpace(roles))
                    {
                        var rolesList = new List<string>();
                        rolesList.AddRange(roles.Split(','));
                        rls.Roles = rolesList;
                    }
                    // Generate Embed Token with effective identities.
                    generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view", identities: new List<EffectiveIdentity> { rls });
                }
                else
                {
                    // Generate Embed Token for reports without effective identities.
                    generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
                }

                var tokenResponse = await client.Reports.GenerateTokenInGroupAsync(WorkspaceId, report.Id, generateTokenRequestParameters);

                if (tokenResponse == null)
                    throw new Exception("Falha ao gerar o embed token");

                // Generate Embed Configuration.
                result.EmbedToken = tokenResponse;
                result.EmbedUrl = report.EmbedUrl;
                result.Id = report.Id;

                return result;
            }
        }
    }
}
