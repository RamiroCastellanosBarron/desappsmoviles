namespace movies.Entities
{
    public class MovieCompany
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
