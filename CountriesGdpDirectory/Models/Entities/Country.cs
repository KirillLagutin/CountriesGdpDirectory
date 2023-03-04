namespace CountriesGdpDirectory.Models.Entities
{
    public class Country
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public Guid GDPId { get; set; }

        public GDP? GDP { get; set; }
    }
}
