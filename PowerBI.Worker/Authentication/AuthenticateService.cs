using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using PowerBI.Worker.Common;

namespace PowerBI.Worker.Authentication
{
    public class AuthenticateService
    {
        private readonly string autorityUrl;
        private readonly string clientId;
        private readonly string clientSecret;

        public AuthenticateService(string tenantId, string clientId, string clientSecret)
        {
            this.autorityUrl = string.Concat(
                ConfigurationManager.configurationSettings[ConfigurationKeys.AzureActiveDirectoryKeys.LoginUrl],
                tenantId);

            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        public async Task<string> GenerateBearerToken(string resoureUrl)
        {
            if(string.IsNullOrEmpty(resoureUrl))
            {
                return null;
            }

            try
            {
                var authContext = new AuthenticationContext(this.autorityUrl);
                var clientCreds = new ClientCredential(this.clientId, this.clientSecret);

                var authenticationResult = await authContext.AcquireTokenAsync(resoureUrl, clientCreds).ConfigureAwait(false);

                return authenticationResult.AccessToken;
            }
            catch (AdalException ex) 
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
