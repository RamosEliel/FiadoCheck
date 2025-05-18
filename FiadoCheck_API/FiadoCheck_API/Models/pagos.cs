using System.ComponentModel.DataAnnotations;


namespace FiadoCheck_API.Models
{
    public class pagos
    {

        [Key]
        public int idPago { get; set; }
        public required float monto { get; set; }
        public required DateTime fechaPago { get; set; }
        public required int idDeuda { get; set; }
        public required string metodoPago { get; set; }
    }
}
