using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMM.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace GMM.Data
{
    public class DbInitializer
    {
        public static void Initialize(GmmDbContext pContext)
        {
            pContext.Database.EnsureCreated();

            // Look for any bands
            if (pContext.Bands.Any())
            {
                return;
            }

            pContext.KleurCodes.AddRange(
                new KleurCode { Omschrijving = "Geel", Code = "#ffff00" },
                new KleurCode { Omschrijving = "Rood", Code = "#FF0000" },
                new KleurCode { Omschrijving = "Wit", Code = "#FFFFFF" },
                new KleurCode { Omschrijving = "Transparant", Code = "#00FFFF00" }
                );

            pContext.SaveChanges();

            pContext.Bands.AddRange(
                new Band { Omschrijving = "A Perfect Circle", KleurCodeId = 3 },
                new Band { Omschrijving = "Accept", KleurCodeId = 3 },
                new Band { Omschrijving = "ACDC UK (cover)", KleurCodeId = 4 },
                new Band { Omschrijving = "Akercocke", KleurCodeId = 1 },
                new Band { Omschrijving = "Amaranthe", KleurCodeId = 2 },
                new Band { Omschrijving = "Amazing Snake Karaoke", KleurCodeId = 4 },
                new Band { Omschrijving = "Anti - flag", KleurCodeId = 2 },
                new Band { Omschrijving = "Arch Enemy", KleurCodeId = 1 },
                new Band { Omschrijving = "Arkona", KleurCodeId = 3 },
                new Band { Omschrijving = "Asking Alexandria", KleurCodeId = 1 },
                new Band { Omschrijving = "Asphyx", KleurCodeId = 3 },
                new Band { Omschrijving = "At The Gates", KleurCodeId = 2 },
                new Band { Omschrijving = "Avatar", KleurCodeId = 2 },
                new Band { Omschrijving = "Avenged Sevenfold", KleurCodeId = 1 },
                new Band { Omschrijving = "Ayreon", KleurCodeId = 1 },
                new Band { Omschrijving = "Backyard Babies", KleurCodeId = 2 },
                new Band { Omschrijving = "Baroness", KleurCodeId = 1 },
                new Band { Omschrijving = "Batushka", KleurCodeId = 3 },
                new Band { Omschrijving = "Billy Talent", KleurCodeId = 2 },
                new Band { Omschrijving = "Black Stone Cherry", KleurCodeId = 1 },
                new Band { Omschrijving = "Blessthefall", KleurCodeId = 3 },
                new Band { Omschrijving = "Bloodbath", KleurCodeId = 2 },
                new Band { Omschrijving = "Body Count", KleurCodeId = 1 },
                new Band { Omschrijving = "BOLZER", KleurCodeId = 3 },
                new Band { Omschrijving = "Boston Manor", KleurCodeId = 3 },
                new Band { Omschrijving = "Bullet For My Valentine", KleurCodeId = 1 },
                new Band { Omschrijving = "Bury Tomorrow", KleurCodeId = 1 },
                new Band { Omschrijving = "Cancer Bats", KleurCodeId = 1 },
                new Band { Omschrijving = "Carach Angren", KleurCodeId = 3 },
                new Band { Omschrijving = "Carnivore A.D.", KleurCodeId = 3 },
                new Band { Omschrijving = "Corrosion Of Conformity", KleurCodeId = 2 },
                new Band { Omschrijving = "Crossfaith", KleurCodeId = 3 },
                new Band { Omschrijving = "Culture Abuse", KleurCodeId = 3 },
                new Band { Omschrijving = "Dead Cross", KleurCodeId = 2 },
                new Band { Omschrijving = "Diablo Blvd", KleurCodeId = 3 },
                new Band { Omschrijving = "Dool", KleurCodeId = 1 },
                new Band { Omschrijving = "Doro - Warlock", KleurCodeId = 1 },
                new Band { Omschrijving = "Ego Kill Talent", KleurCodeId = 3 },
                new Band { Omschrijving = "Eisbrecher", KleurCodeId = 2 },
                new Band { Omschrijving = "Emmure", KleurCodeId = 3 },
                new Band { Omschrijving = "Employed to Serve", KleurCodeId = 3 },
                new Band { Omschrijving = "Eskimo Callboy", KleurCodeId = 3 },
                new Band { Omschrijving = "Eternal Run For Cover", KleurCodeId = 4 },
                new Band { Omschrijving = "Exodus", KleurCodeId = 2 },
                new Band { Omschrijving = "Fleddy Melculy", KleurCodeId = 1 },
                new Band { Omschrijving = "Follow The Cipher", KleurCodeId = 1 },
                new Band { Omschrijving = "GALACTIC EMPIRE", KleurCodeId = 3 },
                new Band { Omschrijving = "Ghost", KleurCodeId = 1 },
                new Band { Omschrijving = "Guns N' Roses", KleurCodeId = 1 },
                new Band { Omschrijving = "Hats Of To Led Zepplin", KleurCodeId = 1 },
                new Band { Omschrijving = "Heilung", KleurCodeId = 1 },
                new Band { Omschrijving = "Hollywood Undead", KleurCodeId = 1 },
                new Band { Omschrijving = "Hollywood Vampires", KleurCodeId = 1 },
                new Band { Omschrijving = "Iced Earth", KleurCodeId = 1 },
                new Band { Omschrijving = "In This Moment", KleurCodeId = 2 },
                new Band { Omschrijving = "Iron Maiden", KleurCodeId = 1 },
                new Band { Omschrijving = "Jonathan Davis", KleurCodeId = 1 },
                new Band { Omschrijving = "Judas Priest", KleurCodeId = 1 },
                new Band { Omschrijving = "Kadavar", KleurCodeId = 2 },
                new Band { Omschrijving = "Kataklysm", KleurCodeId = 1 },
                new Band { Omschrijving = "Killswitch Engage", KleurCodeId = 1 },
                new Band { Omschrijving = "Knocked Loose", KleurCodeId = 3 },
                new Band { Omschrijving = "Kreator", KleurCodeId = 1 },
                new Band { Omschrijving = "L7", KleurCodeId = 2 },
                new Band { Omschrijving = "Lacuna Coil", KleurCodeId = 2 },
                new Band { Omschrijving = "Less Than Jake", KleurCodeId = 2 },
                new Band { Omschrijving = "Limp Bizkit", KleurCodeId = 1 },
                new Band { Omschrijving = "Living Theory(cover)", KleurCodeId = 4 },
                new Band { Omschrijving = "Madball", KleurCodeId = 1 },
                new Band { Omschrijving = "Mantar", KleurCodeId = 3 },
                new Band { Omschrijving = "Marduk", KleurCodeId = 2 },
                new Band { Omschrijving = "Marilyn Manson", KleurCodeId = 1 },
                new Band { Omschrijving = "Megadeth", KleurCodeId = 1 },
                new Band { Omschrijving = "MESSHUGAH", KleurCodeId = 1 },
                new Band { Omschrijving = "Miss May I", KleurCodeId = 2 },
                new Band { Omschrijving = "Modern Life Is War", KleurCodeId = 3 },
                new Band { Omschrijving = "Moments", KleurCodeId = 1 },
                new Band { Omschrijving = "Monuments", KleurCodeId = 4 },
                new Band { Omschrijving = "Neurosis", KleurCodeId = 1 },
                new Band { Omschrijving = "Ozzy Osbourne", KleurCodeId = 1 },
                new Band { Omschrijving = "P.O.D.", KleurCodeId = 1 },
                new Band { Omschrijving = "Parkway Drive", KleurCodeId = 1 },
                new Band { Omschrijving = "Perturbator", KleurCodeId = 2 },
                new Band { Omschrijving = "Pist * On", KleurCodeId = 3 },
                new Band { Omschrijving = "Planet of Zeus", KleurCodeId = 3 },
                new Band { Omschrijving = "Powerflo", KleurCodeId = 2 },
                new Band { Omschrijving = "Powerwolf", KleurCodeId = 1 },
                new Band { Omschrijving = "Present Danger(cover)", KleurCodeId = 4 },
                new Band { Omschrijving = "PRO - PAIN", KleurCodeId = 2 },
                new Band { Omschrijving = "Purpendicular", KleurCodeId = 1 },
                new Band { Omschrijving = "Rise Against", KleurCodeId = 1 },
                new Band { Omschrijving = "Savage Messiah", KleurCodeId = 3 },
                new Band { Omschrijving = "Seether", KleurCodeId = 2 },
                new Band { Omschrijving = "Septicflesh", KleurCodeId = 3 },
                new Band { Omschrijving = "Shinedown", KleurCodeId = 1 },
                new Band { Omschrijving = "Shining", KleurCodeId = 3 },
                new Band { Omschrijving = "Signs Of Algorithm", KleurCodeId = 1 },
                new Band { Omschrijving = "Silverstein", KleurCodeId = 3 },
                new Band { Omschrijving = "Skillet", KleurCodeId = 1 },
                new Band { Omschrijving = "Skindred", KleurCodeId = 2 },
                new Band { Omschrijving = "Sons Of Apollo", KleurCodeId = 2 },
                new Band { Omschrijving = "S.T.Y.G.", KleurCodeId = 2 },
                new Band { Omschrijving = "Stone Broken", KleurCodeId = 3 },
                new Band { Omschrijving = "Stray From The Path", KleurCodeId = 3 },
                new Band { Omschrijving = "Subliminal Verses(cover)", KleurCodeId = 4 },
                new Band { Omschrijving = "System Pilot", KleurCodeId = 4 },
                new Band { Omschrijving = "Tesseract", KleurCodeId = 3 },
                new Band { Omschrijving = "The Bloody Beetroots", KleurCodeId = 1 },
                new Band { Omschrijving = "The Contortionist", KleurCodeId = 3 },
                new Band { Omschrijving = "The Darkness", KleurCodeId = 1 },
                new Band { Omschrijving = "The Pink Slips", KleurCodeId = 1 },
                new Band { Omschrijving = "The Raven Age", KleurCodeId = 3 },
                new Band { Omschrijving = "The Vintage Caravan", KleurCodeId = 3 },
                new Band { Omschrijving = "Thundermother", KleurCodeId = 3 },
                new Band { Omschrijving = "Thy Art Is Murder", KleurCodeId = 2 },
                new Band { Omschrijving = "Toxic Shock", KleurCodeId = 1 },
                new Band { Omschrijving = "Tremonti", KleurCodeId = 1 },
                new Band { Omschrijving = "TYLER BRYANT &..", KleurCodeId = 3 },
                new Band { Omschrijving = "Tyr", KleurCodeId = 3 },
                new Band { Omschrijving = "Underoath", KleurCodeId = 2 },
                new Band { Omschrijving = "Vader", KleurCodeId = 2 },
                new Band { Omschrijving = "VDB MOONKINGS", KleurCodeId = 2 },
                new Band { Omschrijving = "Vixen", KleurCodeId = 2 },
                new Band { Omschrijving = "Volbeat", KleurCodeId = 1 },
                new Band { Omschrijving = "WATAIN", KleurCodeId = 2 },
                new Band { Omschrijving = "WOLVES I.T.T.R.", KleurCodeId = 2 },
                new Band { Omschrijving = "Zeal & Ardor", KleurCodeId = 3 }
                );

            pContext.SaveChanges();

            pContext.CommentaarTypes.AddRange(
                new CommentaarType { Omschrijving = "Voorzieningen" },
                new CommentaarType { Omschrijving = "Catering" }
                );

            pContext.SaveChanges();

            pContext.Functies.AddRange(
                new Functie { Omschrijving = "Tourmanager" },
                new Functie { Omschrijving = "Production manager" },
                new Functie { Omschrijving = "Artiesten begeleider" }
                );

            pContext.SaveChanges();

            pContext.Kleedkamers.AddRange(
                new Kleedkamer { Omschrijving = "Kleedkamer 1" },
                new Kleedkamer { Omschrijving = "Kleedkamer 2" },
                new Kleedkamer { Omschrijving = "Kleedkamer 3" }
                );

            pContext.SaveChanges();

            pContext.Podia.AddRange(
                new Podium { Omschrijving = "Classic Rock" },
                new Podium { Omschrijving = "Jupiler Stage" },
                new Podium { Omschrijving = "Mainstage 1" },
                new Podium { Omschrijving = "Mainstage 2" },
                new Podium { Omschrijving = "Marquee" },
                new Podium { Omschrijving = "Metal Dome" }
                );

            pContext.SaveChanges();

            pContext.ProductieEenheden.AddRange(
                new ProductieEenheid { Omschrijving = "P1" },
                new ProductieEenheid { Omschrijving = "P2" },
                new ProductieEenheid { Omschrijving = "P3" },
                new ProductieEenheid { Omschrijving = "P4" },
                new ProductieEenheid { Omschrijving = "P5" },
                new ProductieEenheid { Omschrijving = "P6" }
                );

            pContext.SaveChanges();
        }
    }
}
