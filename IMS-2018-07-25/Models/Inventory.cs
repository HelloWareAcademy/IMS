
namespace IMS_2018_07_25.Models
{
    public class Inventory
    {
        public int LocationId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public Location Location { get; set; }
        public Item Item { get; set; }
    }
}