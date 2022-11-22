using Microsoft.EntityFrameworkCore;

namespace movies.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var movies = new List<Movie>()
            {
                new Movie{ Name="The Godfather", Year=1972},
                new Movie{ Name="Iron Man", Year=2008},
                new Movie{ Name="Taxi Driver", Year=1975},
            };

            if(await context.Movies.AnyAsync() == false)
            {
                foreach (var movie in movies)
                {
                    await context.AddAsync(movie);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
