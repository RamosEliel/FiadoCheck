using System.ComponentModel.DataAnnotations;

namespace FiadoCheck_API.Models
{
    public class notificaciones
    {
        [Key]
        public int idnotificacion { get; set; }
        public required string categoria { get; set; }
        public required string descripcion { get; set; }
        public required DateTime fechaNotificacion { get; set; }
        public required int idUsuario { get; set; }
        public required int idDeuda { get; set; }

    }
}
