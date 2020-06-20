//using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Identity.Client;
using System.Security;

namespace Analytics
{
    public class PowerBI
    {
        private static Guid GetParamGuid(string param)
        {
            Guid paramGuid = Guid.Empty;
            Guid.TryParse(param, out paramGuid);
            return paramGuid;
        }

        public async Task<EmbedConfig> CarregarDashboard(string WorkspaceId_, string ReportId_)
        {
            Guid WorkspaceId = GetParamGuid(WorkspaceId_);
            Guid ReportId = GetParamGuid(ReportId_);

            // variáveis
            string Username = "powerbi@creditcash.com.br";
            string Password = "BICr3d!tC@s#LTD4";
            string AuthorityUrl = "https://login.microsoftonline.com/organizations/";
            string ApplicationId = "53505ee5-4b38-4381-a6c4-847ff6373fae";
            string ApiUrl = "https://api.powerbi.com/";
            string username = null;
            string roles = null;
            string[] Scope = new string[] { "https://analysis.windows.net/powerbi/api/.default" };


            var m_embedConfig = new EmbedConfig();
            m_embedConfig = new EmbedConfig { Username = username, Roles = roles };

            AuthenticationResult authenticationResult = null;
            IPublicClientApplication clientApp = PublicClientApplicationBuilder.Create(ApplicationId).WithAuthority(AuthorityUrl).Build();
            var userAccounts = await clientApp.GetAccountsAsync();
            try
            {
                
                   authenticationResult = await clientApp.AcquireTokenSilent(Scope, userAccounts.FirstOrDefault()).ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                try
                {
                    SecureString password = new SecureString();
                    foreach (var key in Password)
                    {
                        password.AppendChar(key);
                    }
                    authenticationResult = await clientApp.AcquireTokenByUsernamePassword(Scope, Username, password).ExecuteAsync();
                }
                catch (MsalException e)
                {
                    throw;
                }
            }

            var tokenCredentials = new TokenCredentials(authenticationResult.AccessToken, "Bearer");

            // Create a Power BI Client object. It will be used to call Power BI APIs.
            using (var client = new PowerBIClient(new Uri(ApiUrl), tokenCredentials))
            {
                // Get a list of reports.
                var reports = await client.Reports.GetReportsInGroupAsync(WorkspaceId);

                // No reports retrieved for the given workspace.
                if (reports.Value.Count() == 0)
                {
                    m_embedConfig.ErrorMessage = "No reports were found in the workspace";
                }

                Report report = null;
                if (ReportId == Guid.Empty)
                {
                    m_embedConfig.ErrorMessage = "Please provide a report ID for the selected workspace. Make sure that the report ID is valid.";
                }
                else
                {
                    report = reports.Value.FirstOrDefault(r => r.Id == ReportId);
                }

                if (report == null)
                {
                    m_embedConfig.ErrorMessage = "No report with the given ID was found in the workspace. Make sure that the report ID is valid.";
                }

                var datasets = await client.Datasets.GetDatasetInGroupAsync(WorkspaceId, report.DatasetId);
                m_embedConfig.IsEffectiveIdentityRequired = datasets.IsEffectiveIdentityRequired;
                m_embedConfig.IsEffectiveIdentityRolesRequired = datasets.IsEffectiveIdentityRolesRequired;
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
                {
                    m_embedConfig.ErrorMessage = "Failed to generate embed token.";
                }

                // Generate Embed Configuration.
                m_embedConfig.EmbedToken = tokenResponse;
                m_embedConfig.EmbedUrl = report.EmbedUrl;
                m_embedConfig.Id = report.Id.ToString();


                return m_embedConfig;
            }
        }
    }
}
