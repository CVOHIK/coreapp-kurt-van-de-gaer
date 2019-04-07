using System;
using System.Collections.Generic;
using System.Text;

namespace GMM.Data
{
    public class Boeking
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? BeginUur { get; set; }
        public DateTime? EindUur { get; set; }
        public DateTime? KleedkamerBeginUur { get; set; }
        public DateTime? KleedkamerEindUur { get; set; }
        public int PodiumId { get; set; }
        public int? TentId { get; set; }

        public Band Band { get; set; }
        public Podium Podium { get; set; }
        public Tent Tent { get; set; }

        public ICollection<BoekingKleedkamer> BoekingKleedkamers { get; set; }
        public ICollection<BoekingProductieEenheid> BoekingProductieEenheden { get; set; }
        public ICollection<Begeleiding> Begeleiders { get; set; }
        public ICollection<Catering> Caterings { get; set; }
        public ICollection<Commentaar> Commentaren { get; set; }
        public ICollection<Voorziening> VoorzieningenItems { get; set; }
    }
}
