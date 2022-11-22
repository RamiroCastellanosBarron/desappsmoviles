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
                // The Godfather
                new Person{Name="Marlon Brando",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Al Pacino",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="James Caan",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Diane Keaton",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Robert Duvall",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Francis Ford Coppola",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Mario Puzo",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Gordon Willis",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },
                new Person{Name="Aram Avakian",PhotoUrl="https://media.gq.com.mx/photos/6245b67deaa378c48316e90d/1:1/w_1693,h_1693,c_limit/michael%20corleone%20traje%20rayas.jpg" },

                // Iron Man
                new Person{Name="Robert Downey Jr.", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Gwyneth Paltrow", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Terrence Howard", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Jeff Bridges", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Leslie Bibb", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Shaun Toub", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Jon Favreau", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
                new Person{Name="Mark Fergus", PhotoUrl="https://legendary-digital-network-assets.s3.amazonaws.com/wp-content/uploads/2020/05/13041706/maxresdefault-1-1.jpg" },
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
                new Company{Name="Marvel Studios"},
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
                new Movie{Title="The Godfather",Budget=6000000,Homepage="Cinematographer Gordon Willis earned himself the nickname The Prince of Darkness, since his sets were so underlit. Paramount Pictures executives initially",Overview="The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.", Popularity=58,ReleaseDate="24/03/1972",Revenue=520341816,Runtime=175,Status="Released",Tagline="The Godfather Don Vito Corleone is the head of the Corleone mafia family in New York. He is at the event of his daughters wedding.",VoteAverage=9.2,VoteCount=180000000, PhotoUrl="https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"},

                new Movie{Title="Iron Man",Budget=140000000,Homepage="After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",Overview="After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", Popularity=371,ReleaseDate="02/05/2008",Revenue=585796247,Runtime=126,Status="Released",Tagline="After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",VoteAverage=7.9,VoteCount=1100000000, PhotoUrl="https://practicaltyping.com/wp-content/uploads/2021/03/ironman.jpg"},


            };

            var movieCast = new List<MovieCast>()
            { 
                // The Godfather
                new MovieCast{MovieId=1,GenderId=1,PersonId=1,CharacterName="Don Vito Corleone",CastOrder=1 },
                new MovieCast{MovieId=1,GenderId=1,PersonId=2,CharacterName="Michael Corleone",CastOrder=2 },
                new MovieCast{MovieId=1,GenderId=1,PersonId=3,CharacterName="Sonny Corleone",CastOrder=3 },
                new MovieCast{MovieId=1,GenderId=2,PersonId=4,CharacterName="Diane Keaton",CastOrder=4 },
                new MovieCast{MovieId=1,GenderId=1,PersonId=5,CharacterName="Robert Duvall",CastOrder=5 },

                // Iron Man
                new MovieCast{MovieId=2,GenderId=1,PersonId=10,CharacterName="Tony Stark",CastOrder=1 },
                new MovieCast{MovieId=2,GenderId=2,PersonId=11,CharacterName="Pepper Potts",CastOrder=2 },
                new MovieCast{MovieId=2,GenderId=1,PersonId=12,CharacterName="Rhodey",CastOrder=3 },
                new MovieCast{MovieId=2,GenderId=1,PersonId=13,CharacterName="Obadiah Stane",CastOrder=4 },
                new MovieCast{MovieId=2,GenderId=2,PersonId=14,CharacterName="Christine Everhart",CastOrder=5 },
                new MovieCast{MovieId=2,GenderId=1,PersonId=15,CharacterName="Yinsen",CastOrder=6 },

            };

            var crews = new List<Crew>()
            {
                // The Godfather
                new Crew{PersonId=6,MovieId=1,DepartmentId=3,Job="Director" },
                new Crew{PersonId=8,MovieId=1,DepartmentId=1,Job="Cinematographer" },
                new Crew{PersonId=7,MovieId=1,DepartmentId=4,Job="Writer" },
                new Crew{PersonId=9,MovieId=1,DepartmentId=2,Job="Editor" },

                // Iron Man
                new Crew{PersonId=16,MovieId=2,DepartmentId=3,Job="Director" },
                new Crew{PersonId=17,MovieId=2,DepartmentId=4,Job="Writer" },


            };

            var movieCompanies = new List<MovieCompany>()
            {
                // The Godfather
                new MovieCompany{MovieId=1,CompanyId=1},

                // Iron Man
                new MovieCompany{MovieId=2,CompanyId=6},
            };

            var productionCountries = new List<ProductionCountry>()
            {
                // The Godfather
                new ProductionCountry{MovieId=1,CountryId=2},

                // Iron Man
                new ProductionCountry{MovieId=2,CountryId=2},
            };

            var movieLanguages = new List<MovieLanguage>()
            {
                // The Godfather
                new MovieLanguage{MovieId=1,LanguageId=1,LanguageRoleId=1 },
                new MovieLanguage{MovieId=1,LanguageId=2,LanguageRoleId=2 },

                // Iron Man
                new MovieLanguage{MovieId=2,LanguageId=1,LanguageRoleId=1 },
                new MovieLanguage{MovieId=2,LanguageId=2,LanguageRoleId=2 },

            };

            var keywords = new List<Keyword>()
            {
                // The Godfather
                new Keyword{Name="The Godfather"},
                new Keyword{Name="Godfather"},
                new Keyword{Name="Michael Corleone"},
                new Keyword{Name="Corleone"},
                new Keyword{Name="Coppola"},
                new Keyword{Name="Mario Puzo"},

                // Iron Man
                new Keyword{Name="Tony Stark"},
                new Keyword{Name="Iron Man"},
                new Keyword{Name="Malibu"},
                new Keyword{Name="Pepper Pots"},
                new Keyword{Name="War Machine"},
                new Keyword{Name="Tony"},

            };

            var movieGenres = new List<MovieGenre>()
            {
                // The Godfather
                new MovieGenre{MovieId=1,GenreId=3},

                // Iron Man
                new MovieGenre{MovieId=2,GenreId=2},

            };

            var movieKeywords = new List<MovieKeywords>()
            {
                // The Godfather
                new MovieKeywords{MovieId=1,KeywordId=1},
                new MovieKeywords{MovieId=1,KeywordId=2},
                new MovieKeywords{MovieId=1,KeywordId=3},
                new MovieKeywords{MovieId=1,KeywordId=4},
                new MovieKeywords{MovieId=1,KeywordId=5},
                new MovieKeywords{MovieId=1,KeywordId=6},

                // Iron Man
                new MovieKeywords{MovieId=2,KeywordId=7},
                new MovieKeywords{MovieId=2,KeywordId=8},
                new MovieKeywords{MovieId=2,KeywordId=9},
                new MovieKeywords{MovieId=2,KeywordId=10},
                new MovieKeywords{MovieId=2,KeywordId=11},
                new MovieKeywords{MovieId=2,KeywordId=12},
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
