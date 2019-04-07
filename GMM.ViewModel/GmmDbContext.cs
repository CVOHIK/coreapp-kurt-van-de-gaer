using GMM.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GMM.ViewModel
{
    public class GmmDbContext : IdentityDbContext//<ApplicationUser, ApplicationRole, string>
    {
        public GmmDbContext(DbContextOptions<GmmDbContext> options) : base(options)
        {
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Begeleiding> Begeleiders { get; set; }
        public DbSet<Boeking> Boekingen { get; set; }
        public DbSet<BoekingKleedkamer> BoekingKleedkamers { get; set; }
        public DbSet<BoekingProductieEenheid> BoekingProductieEenheden { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<Commentaar> Commentaren { get; set; }
        public DbSet<CommentaarType> CommentaarTypes { get; set; }
        public DbSet<Functie> Functies { get; set; }
        public DbSet<Kleedkamer> Kleedkamers { get; set; }
        public DbSet<KleurCode> KleurCodes { get; set; }
        public DbSet<Podium> Podia { get; set; }
        public DbSet<ProductieEenheid> ProductieEenheden { get; set; }
        public DbSet<Tent> Tenten { get; set; }
        public DbSet<Voorziening> Voorzieningen { get; set; }
    }
}
