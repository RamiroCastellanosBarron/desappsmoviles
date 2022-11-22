namespace movies.Entities
{
    public class MovieLanguage
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int LanguageRoleId { get; set; }
        public LanguageRole LanguageRole { get; set; }
    }
}
