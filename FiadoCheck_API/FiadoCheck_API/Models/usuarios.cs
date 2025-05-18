using System.ComponentModel.DataAnnotations;

namespace FiadoCheck_API.Models
{
    public class usuarios
    {
        [Key]
        public int idUsuario { get; set; }
        public required string nombreUsuario { get; set; }
        public required string password {  get; set; }
        public required int rol {  get; set; }
        public required int idCliente {  get; set; }


    }
}
