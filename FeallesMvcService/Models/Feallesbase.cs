using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FeallesMvcService.Models
{
    public class Feallesbase
    {
        [Key]
        public int ID { get; set; } 
        public string? AvisTypeID { get; set; } = "Default Value";

        public DateTime? Avisdato { get; set; } 
        public string? Efternavn { get; set; } = "Default Value";
        [Required]
        public string? Fornavne { get; set; } = "Default Value";

        public DateTime? Foedt { get; set; } 
        public string? Alder { get; set; } = "Default Value";
        public string? Doebenavn { get; set; } = "Default Value";
        public string? Erhverv { get; set; } = "Default Value";
        public string? Adresser { get; set; } = "Default Value";
        public string? SognID { get; set; } = "Default Value";
        public string? TidlBopael { get; set; } = "Default Value";

        public DateTime? Doedsdato { get; set; } 

        public DateTime? Begravelsesdato { get; set; }
        public string? Begravelsessted { get; set; } = "Default Value";
        public string? Efterladte { get; set; } = "Default Value";
        public string? FlereDoedsannoncer { get; set; } = "Default Value";
        public string? AndreDataFraAnnoncen { get; set; } = "Default Value";
        public string? Oegenavne { get; set; } = "Default Value";

        public DateTime? Nekrolog { get; set; }

        public DateTime? Mindeord { get; set; }

        public DateTime? Statstidende { get; set; }
        [DisplayName("Partner Link")]
        public string? Partnerlink { get; set; } = "Default Value";
        public Feallesbase()
        {

        }

    }
}

   

