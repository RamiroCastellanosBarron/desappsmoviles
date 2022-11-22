using Microsoft.EntityFrameworkCore;
using movies.Entities;

namespace movies.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var genders = new List<Gender>()
            {
                new Gender{Name="Male"},
                new Gender{Name="Female"},
            };

            var persons = new List<Person>()
            {
                new Person{Name="Marlon Brando" },
                new Person{Name="Al Pacino" },
                new Person{Name="James Caan" },
                new Person{Name="Diane Keaton" },
                new Person{Name="Robert Duvall" },
                new Person{Name="Francis Ford Coppola" },
                new Person{Name="Mario Puzo" },
                new Person{Name="Gordon Willis" },
                new Person{Name="Aram Avakian" },
            };

            var departments = new List<Department>()
            {
                new Department{Name="Cinematography" },
                new Department{Name="Edition" },
                new Department{Name="Direction" },
                new Department{Name="Writing" },
                new Department{Name="Acting" },
            };

            var companies = new List<Company>()
            {
                new Company{Name="Paramount"},
                new Company{Name="Universal"},
                new Company{Name="Warner Bros."},
                new Company{Name="Walt Disney Pictures"},
                new Company{Name="Columbia"},
            };

            var countries = new List<Country>()
            {
                new Country {IsoCode="3166", Name="Mexico"},
                new Country {IsoCode="840", Name="United States of America"},
            };

            var languages = new List<Language>()
            {
                new Language{Code="en-us",Name="English (United States)"},
                new Language{Code="es-MX",Name="Spanish (Mexico)"},
            };

            var languageRoles = new List<LanguageRole>()
            {
                new LanguageRole{Name="Main" },
                new LanguageRole{Name="Secondary" },
            };

            var genres = new List<Genre>()
            {
                new Genre{Name="Adventure"},
                new Genre{Name="Action"},
                new Genre{Name="Drama"},
                new Genre{Name="Comedy"},
            };

            var movies = new List<Movie>()
            {
                new Movie{Title="The Godfather",Budget=6000000,Homepage="Cinematographer Gordon Willis earned himself the nickname \"The Prince of Darkness,\" since his sets were so underlit. \"Paramount Pictures\" executives initially",Overview="The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.", Popularity=58,ReleaseDate="24/03/1972",Revenue=520341816,Runtime=175,Status="Released",Tagline="The Godfather \"Don\" Vito Corleone is the head of the Corleone mafia family in New York. He is at the event of his daughters wedding.",VoteAverage=9.2,VoteCount=180000000},
            };

            var movieCast = new List<MovieCast>()
            { 
                new MovieCast{MovieId=1,GenderId=1,PersonId=1,CharacterName="Don Vito Corleone",CastOrder=1 },
                new MovieCast{MovieId=1,GenderId=1,PersonId=2,CharacterName="Michael Corleone",CastOrder=2 },
                new MovieCast{MovieId=1,GenderId=1,PersonId=3,CharacterName="Sonny Corleone",CastOrder=3 },
                new MovieCast{MovieId=1,GenderId=2,PersonId=4,CharacterName="Diane Keaton",CastOrder=4 },
                new MovieCast{MovieId=1,GenderId=1,PersonId=5,CharacterName="Robert Duvall",CastOrder=5 },
            };

            var crews = new List<Crew>()
            {
                new Crew{PersonId=6,MovieId=1,DepartmentId=3,Job="Director" },
                new Crew{PersonId=8,MovieId=1,DepartmentId=1,Job="Cinematographer" },
                new Crew{PersonId=7,MovieId=1,DepartmentId=4,Job="Writer" },
                new Crew{PersonId=9,MovieId=1,DepartmentId=2,Job="Editor" },
            };

            var movieCompanies = new List<MovieCompany>()
            {
                new MovieCompany{MovieId=1,CompanyId=1},
            };

            var productionCountries = new List<ProductionCountry>()
            {
                new ProductionCountry{MovieId=1,CountryId=2}
            };

            var movieLanguages = new List<MovieLanguage>()
            {
                new MovieLanguage{MovieId=1,LanguageId=1,LanguageRoleId=1 },
                new MovieLanguage{MovieId=1,LanguageId=2,LanguageRoleId=2 },
            };

            var keywords = new List<Keyword>()
            {
                new Keyword{Name="The Godfather"},
                new Keyword{Name="Godfather"},
                new Keyword{Name="Michael Corleone"},
                new Keyword{Name="Corleone"},
                new Keyword{Name="Coppola"},
                new Keyword{Name="Mario Puzo"},
            };

            var movieGenres = new List<MovieGenre>()
            {
                new MovieGenre{MovieId=1,GenreId=3},
            };

            var movieKeywords = new List<MovieKeywords>()
            {
                new MovieKeywords{MovieId=1,KeywordId=1},
                new MovieKeywords{MovieId=1,KeywordId=2},
                new MovieKeywords{MovieId=1,KeywordId=3},
                new MovieKeywords{MovieId=1,KeywordId=4},
                new MovieKeywords{MovieId=1,KeywordId=5},
                new MovieKeywords{MovieId=1,KeywordId=6},
            };

            if(await context.Movies.AnyAsync() == false)
            {
                foreach (var gender in genders) { await context.Genders.AddAsync(gender); }
                foreach (var person in persons) { await context.Persons.AddAsync(person); }
                foreach (var department in departments) { await context.Departments.AddAsync(department); }
                foreach (var company in companies) { await context.Companies.AddAsync(company); }
                foreach (var country in countries) { await context.Countries.AddAsync(country); }
                foreach (var language in languages) { await context.Languages.AddAsync(language); }
                foreach (var languageRole in languageRoles) { await context.LanguageRoles.AddAsync(languageRole); }
                foreach (var genre in genres) { await context.Genres.AddAsync(genre); }
                foreach (var movie in movies) { await context.Movies.AddAsync(movie); }
                foreach (var keyword in keywords) { await context.Keywords.AddAsync(keyword); }
                await context.SaveChangesAsync();
                foreach (var cast in movieCast) { await context.MovieCasts.AddAsync(cast); }
                foreach (var crew in crews) { await context.Crews.AddAsync(crew); }
                foreach (var company in movieCompanies) { await context.MovieCompanies.AddAsync(company); }
                foreach (var country in productionCountries) { await context.ProductionCountries.AddAsync(country); }
                foreach (var movieLanguage in movieLanguages) { await context.MovieLanguages.AddAsync(movieLanguage); }
                foreach (var genre in movieGenres) { await context.MovieGenres.AddAsync(genre); }
                foreach (var keyword in movieKeywords) { await context.MovieKeywords.AddAsync(keyword); }

                await context.SaveChangesAsync();
            }
        }
    }
}
