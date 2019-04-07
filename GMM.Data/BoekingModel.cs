using System;
using System.ComponentModel.DataAnnotations;

namespace GMM.Data
{
    public class BoekingModel
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public string BandNaam { get; set; }
        public string KleurCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Datum { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime BeginUur { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime EindUur { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime KleedkamerBeginUur { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime KleedkamerEindUur { get; set; }
        public int PodiumId { get; set; }
        public string PodiumNaam { get; set; }
        public int? TentId { get; set; }
        public string TentNaam { get; set; }

        public string TourmanagerNaam { get; set; }
        public string TourmanagerEmail { get; set; }
        public string TourmanagerGsm{ get; set; }
        public bool TourmanagerWalkieTalkie { get; set; }

        public string ProductieManagerNaam { get; set; }
        public string ProductieManagerEmail { get; set; }
        public string ProductieManagerGsm { get; set; }
        public bool ProductieManagerWalkieTalkie { get; set; }

        public string Begeleider1 { get; set; }
        public string Begeleider2 { get; set; }
        public string Begeleider3 { get; set; }
        public string Begeleider4 { get; set; }
        public string Begeleider5 { get; set; }
        public string Begeleider6 { get; set; }

        public int? Kleedkamer1 { get; set; }
        public int? Kleedkamer2 { get; set; }
        public int? Kleedkamer3 { get; set; }
        public int? Kleedkamer4 { get; set; }
        public int? Kleedkamer5 { get; set; }
        public int? Kleedkamer6 { get; set; }
        public string Kleedkamer1Naam { get; set; }
        public string Kleedkamer2Naam { get; set; }
        public string Kleedkamer3Naam { get; set; }
        public string Kleedkamer4Naam { get; set; }
        public string Kleedkamer5Naam { get; set; }
        public string Kleedkamer6Naam { get; set; }
        public string BoekingKleedkamersString { get; set; }

        public int? ProductieEenheid1 { get; set; }
        public int? ProductieEenheid2 { get; set; }
        public int? ProductieEenheid3 { get; set; }
        public int? ProductieEenheid4 { get; set; }
        public int? ProductieEenheid5 { get; set; }
        public int? ProductieEenheid6 { get; set; }
        public string ProductieEenheid1Naam { get; set; }
        public string ProductieEenheid2Naam { get; set; }
        public string ProductieEenheid3Naam { get; set; }
        public string ProductieEenheid4Naam { get; set; }
        public string ProductieEenheid5Naam { get; set; }
        public string ProductieEenheid6Naam { get; set; }
        public string BoekingProductieEenhedenString { get; set; }

        public bool CateringAfterShow { get; set; }
        public bool CateringSpecial { get; set; }
        public bool CateringTakeAwayFood { get; set; }
        public string CateringOptie1 { get; set; }
        public string CateringOptie1Waarde { get; set; }
        public string CateringOptie2 { get; set; }
        public string CateringOptie2Waarde { get; set; }
        public string CateringCommentaar { get; set; }

        public bool VoorzieningenWasserij { get; set; }
        public int? VoorzieningenBusStock { get; set; }
        public int? VoorzieningenRunner { get; set; }
        public string VoorzieningenArts { get; set; }
        public int? VoorzieningenZuurstof { get; set; }
        public bool VoorzieningenKinesist { get; set; }
        public int? VoorzieningenCoolersBand { get; set; }
        public int? VoorzieningenCoolersGmm { get; set; }
        public int? VoorzieningenV110 { get; set; }
        public string VoorzieningenCommentaar { get; set; }
    }
}
