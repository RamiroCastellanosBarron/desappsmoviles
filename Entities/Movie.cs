namespace movies.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Budget { get; set; }
        public string Homepage { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string ReleaseDate { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public string PhotoUrl { get; set; }
    }
}
