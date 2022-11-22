using Microsoft.EntityFrameworkCore;
using movies.Entities;

namespace movies.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageRole> LanguageRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCompany> MovieCompanies{ get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieKeywords> MovieKeywords { get; set; }
        public DbSet<MovieLanguage> MovieLanguages{ get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProductionCountry> ProductionCountries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
