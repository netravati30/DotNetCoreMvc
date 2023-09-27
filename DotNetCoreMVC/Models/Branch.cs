using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVC.Models
{
    public class Branch
    {
        public int Id { get; set; }
         public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string Cluster { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string CollectionBranch { get; set; }
        public int Tier { get; set; }
        public string Region { get; set; }
        public string Zone { get; set; }
    }
}
