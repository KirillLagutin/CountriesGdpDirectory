namespace CountriesGdpDirectory.Models.Entities
{
    public class GDP
    {
        public Guid Id { get; init; }

        // ВВП (номинал)
        public decimal Gdp { get; set; }

        // ВВП (ППС)
        public decimal GdpPPP { get; set; }

        // ВВП на душу населения (номинал)
        public decimal GdpPerCapita { get; set; }

        // ВВП на душу населения (ППС)
        public decimal GdpPerCapitaPPP { get; set; }

        public List<Country>? Countries { get; set; }
    }
}
