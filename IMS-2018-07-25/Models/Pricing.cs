using System.Collections.Generic;

namespace IMS_2018_07_25.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Markup> Markups { get; set; }

    }
}