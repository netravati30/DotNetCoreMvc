using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVC.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
