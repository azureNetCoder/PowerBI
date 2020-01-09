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

        public async Task<string> GenerateBearerTokenByPricipalUserCredentials(string resoureUrl)
        {
            if(string.IsNullOrEmpty(resoureUrl))
            {
                return null;
            }

            try
            {
                var authContext = new AuthenticationContext(this.autorityUrl);

                var userAuth = new UserPasswordCredential(
                    ConfigurationManager.configurationSettings[ConfigurationKeys.UserKeys.UserName],
                    ConfigurationManager.configurationSettings[ConfigurationKeys.UserKeys.Password]);

                var authenticationResult = await authContext.AcquireTokenAsync(
                    resoureUrl,
                    this.clientId,
                    userAuth).ConfigureAwait(false);

                return authenticationResult.AccessToken;
            }
            catch (AdalException ex) 
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> GenerateBearerTokenUsingAADApplication(string resoureUrl)
        {
            if (string.IsNullOrEmpty(resoureUrl))
            {
                return null;
            }

            try
            {
                var authContext = new AuthenticationContext(this.autorityUrl);

                var clientCredentials = new ClientCredential(this.clientId, this.clientSecret);

                var authenticationResult = await authContext.AcquireTokenAsync(
                    resoureUrl,
                    clientCredentials).ConfigureAwait(false);

                return authenticationResult.AccessToken;
            }
            catch (AdalException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
