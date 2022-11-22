namespace movies.Entities
{
    public class ProductionCountry
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
