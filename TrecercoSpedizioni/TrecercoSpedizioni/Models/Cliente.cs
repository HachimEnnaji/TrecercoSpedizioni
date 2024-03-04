using System.ComponentModel.DataAnnotations;
namespace TrecercoSpedizioni.Models
{
    public class Cliente
    {
        [Required]
        public string TipoCliente { get; set; }

        [Key]
        public int id { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        [Required]
        public string Nome { get; set; }

    }
}
