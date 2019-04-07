using Microsoft.AspNetCore.Identity;

namespace GMM.ViewModel
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() {}

        public string UserName { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }    
        public string Land { get; set; }
        public string Telefoon { get; set; }
        public string Email { get; set; }
    }
}
