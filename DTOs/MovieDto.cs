namespace movies.DTOs
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string PhotoUrl { get; set; }
        public int Revenue { get; set; }
        public double VoteAverage { get; set; }
        public string Overview { get; set; }
    }
}
