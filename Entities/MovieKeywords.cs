﻿namespace movies.Entities
{
    public class MovieKeywords
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
