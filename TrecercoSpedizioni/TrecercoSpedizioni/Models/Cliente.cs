using System.ComponentModel.DataAnnotations;
namespace TrecercoSpedizioni.Models
{
    public class Cliente
    {
        public enum TipoCliente
        {
            Privato,
            Azienda
        }
        [Key]
        public int id { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        [Required]
        public string Nome { get; set; }

    }
}
