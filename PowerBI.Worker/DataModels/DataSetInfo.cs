using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Worker.DataModels
{
    public class DataSets
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool AddRowsAPIEnabled { get; set; }
        public string ConfiguredBy { get; set; }
        public bool IsRefreshable { get; set; }
        public bool IsEffectiveIdentityRequired { get; set; }
        public bool IsEffectiveIdentityRolesRequired { get; set; }
        public bool IsOnPremGatewayRequired { get; set; }
    }

    public class DataSetInfo
    {
        public List<DataSets> DataSet { get; set; }
    }
}
