using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Worker.DataModels
{
    public class Groups
    {
        public string Id { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsOnDedicatedCapacity { get; set; }
        public string Name { get; set; }
        public string DataflowStorageId { get; set; }
    }

    public class GroupInfo
    {
        public List<Groups> Group { get; set; }
    }
}
