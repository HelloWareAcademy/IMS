namespace IMS_2018_07_25.Models
{
    public class Markup
    {
        public int ItemId { get; set; }
        public int PricingId { get; set; }
        
        public double MarkupPercentage { get; set; }

        //navigation properties. but optional here. 
        public Pricing Price { get; set; }
        public Item Item { get; set; }
    }
}