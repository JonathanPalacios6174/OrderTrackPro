namespace OrderTrackPro.Domain.Entities
{
    public class Territories
    {
        public string TerritoryId { get; set; }

        public string TerritoryDescription { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();
    }
}
