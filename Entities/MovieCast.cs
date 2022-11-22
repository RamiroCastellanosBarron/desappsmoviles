namespace movies.Entities
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string CharacterName { get; set; }
        public int CastOrder { get; set; }
    }
}
