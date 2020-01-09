using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Worker.Common
{
    public static class ConfigurationKeys
    {
        public static class UserKeys
        {
            public const string UserName = "user.username";

            public const string Password = "user.password";
        }

        public static class AzureActiveDirectoryKeys
        {
            public const string TenantId = "aad.tenantId";

            public const string ClientId = "aad.clientId";

            public const string ClientSecret = "aad.clientSecret";

            public const string LoginUrl = "aad.loginUrl";
        }

        public static class PowerBIApiKeys
        {
            public const string BaseUrl = "powerbi.baseUrl";

            public const string ResourceUrl = "powerbi.resourceUrl";

            public const string GetDataSetsApi = "powerbi.api.datasets.list";

            public const string GetSpecificDataSetApi = "powerbi.api.datasets.get";

            public const string GetGroupsAsAdmin = "powerbi.api.admin.groups";
        }
    }
}
