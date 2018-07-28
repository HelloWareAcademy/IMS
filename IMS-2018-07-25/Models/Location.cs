using System.Collections.Generic;

namespace IMS_2018_07_25.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}