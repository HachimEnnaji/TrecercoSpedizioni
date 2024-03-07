using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrecercoSpedizioni.Models
{
    public class Spedizioni
    {
        [Key]
        [Display(Name = "Codice Spedizione")]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }


        [Display(Name = "Data Spedizione")]
        public DateTime DataSpedizione { get; set; } = DateTime.Now;

        [Required]
        public double Peso { get; set; }
        [Required]
        [Display(Name = "Citta di Destinazione")]
        public string CittaDestinazione { get; set; }
        [Required]
        [Display(Name = "Indirizzo Destinatario")]
        public string IndirizzoDestinatario { get; set; }
        [Required]
        [Display(Name = "Nominativo Destinatario")]
        public string NominativoDestinatario { get; set; }
        [Required]
        [Display(Name = "Costo Spedizione")]
        public double CostoSpedizione { get; set; }

        [Display(Name = "Data Consegna Prevista")]
        public DateTime DataConsegnaPrevista => DataSpedizione.AddDays(3);
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DettagliSpedizioni> DettagliSpedizioni { get; set; }
    }
}
