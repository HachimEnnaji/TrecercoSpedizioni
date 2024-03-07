using System.ComponentModel.DataAnnotations;
namespace TrecercoSpedizioni.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        [Required]
        public string TipoCliente { get; set; }

        public string? CodiceFiscale { get; set; }
        public string? PartitaIva { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Usertype { get; set; } = "User";

        public virtual ICollection<Spedizioni> Spedizioni { get; set; }

    }
}
