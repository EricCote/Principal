using System.ComponentModel.DataAnnotations;

namespace Principal.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }

        [Required]
        public string Prenom { get; set; } = "";

        [Required(ErrorMessage = "NomObligatoire")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Nom doit contenir entre 2 et 15 caractères")]
        public string Nom { get; set; } = "";

        [Required]
        public string Province { get; set; } = "Qc";

        [Required]
        public string Courriel { get; set; } = "";

        [Required]
        public string? Telephone { get; set; }



    }
}
