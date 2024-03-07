using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrecercoSpedizioni.Models
{
    public class DettagliSpedizioni
    {
        [Key]
        public int idDettagliSpedizione { get; set; }
        [Required]
        [ForeignKey("Spedizioni")]
        public int IdSpedizione { get; set; }
        [Required]
        public string? StatoSpedizione { get; set; }
        [Required]
        public string? LuogoCorrente { get; set; }
        [Required]
        public string? NoteSpedizione { get; set; }
        [Required]
        public DateTime DataAggiornamento { get; set; }

        public virtual Spedizioni Shipping { get; set; }
    }
}
