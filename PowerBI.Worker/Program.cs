using PowerBI.Worker.Authentication;
using PowerBI.Worker.Common;
using PowerBI.Worker.DataModels;
using PowerBI.Worker.Processing;

namespace PowerBI.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var workspaceId = "Please enter the workspace Id here";

            // Brings all the configurations from App.config to the runtime at once.// 
            ConfigurationManager.InitializeConfigurationSettingsIntoDictionary();

            // Creates an authentication object which can be used to generate bearer token runtime.//
            var authenticatePowerbiService = new AuthenticateService(
                ConfigurationManager.configurationSettings[ConfigurationKeys.AzureActiveDirectoryKeys.TenantId],
                ConfigurationManager.configurationSettings[ConfigurationKeys.AzureActiveDirectoryKeys.ClientId],
                ConfigurationManager.configurationSettings[ConfigurationKeys.AzureActiveDirectoryKeys.ClientSecret]);

            // Generates the bearer token runtime by using service principal & user credentials.//
            var bearerToken = authenticatePowerbiService.GenerateBearerTokenByPricipalUserCredentials(
                ConfigurationManager.configurationSettings[ConfigurationKeys.PowerBIApiKeys.ResourceUrl]).Result;

            // Create an instance of the powerbi client object to be used to call PowerBI APIs.//
            var powerbiClient = new PowerbiClient(
                ConfigurationManager.configurationSettings[ConfigurationKeys.PowerBIApiKeys.BaseUrl]);

            // Makes a generic GET call to the powerBI API//
            var dataSets = powerbiClient.HttpGetMethodCaller<DataSetInfo>(
                string.Format(ConfigurationManager.configurationSettings[ConfigurationKeys.PowerBIApiKeys.GetDataSetsApi], workspaceId),
                bearerToken);

            // All the data is now in datasets var which can used to insert the same into any structured data model //
        }
    }
}
