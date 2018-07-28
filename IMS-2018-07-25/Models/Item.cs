using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS_2018_07_25.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }

        public ICollection<Markup> Markups{ get; set; }
        public ICollection<Inventory> Inventories{ get; set; }
    }
}