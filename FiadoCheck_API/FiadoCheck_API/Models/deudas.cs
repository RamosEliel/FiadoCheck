using System.ComponentModel.DataAnnotations;


namespace FiadoCheck_API.Models
{
    public class deudas
    {
        [Key]
        public int idDeuda { get; set; }
        public required float monto {  get; set; }
        public required DateTime fechaCreacion { get; set; }
        public required string descripcion { get; set; }
        public required string estadoDeuda { get; set; }
        public required int idCliente { get; set; }
    }
}
