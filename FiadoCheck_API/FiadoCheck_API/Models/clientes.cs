using System.ComponentModel.DataAnnotations;

namespace FiadoCheck_API.Models

{
    public class clientes
    {
        [Key]
        public int idCliente { get; set; }
        public required String nombreCliente { get; set; }
        public required String direccion { get; set; }
        public required int telefono { get; set; }
        public required String email { get; set; }
        public required DateTime fechaRegistro {  get; set; }




    }
}
