namespace movies.Entities
{
    public class Crew
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Job { get; set; }
    }
}
