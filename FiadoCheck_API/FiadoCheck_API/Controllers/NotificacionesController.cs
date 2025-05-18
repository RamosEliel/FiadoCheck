using Microsoft.AspNetCore.Mvc;
using FiadoCheck_API.Context;
using FiadoCheck_API.Models;

namespace FiadoCheck_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly FiadoCheckDbContext context;

        public NotificacionesController(FiadoCheckDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<notificaciones> Get()
        {
            return context.notificaciones.ToList();
        }

        [HttpGet("{id}")]
        public notificaciones Get(int id)
        {
            return context.notificaciones.Find(id);
        }

        [HttpPost]
        public int Post([FromBody] notificaciones notificacion)
        {
            int result = context.notificaciones.Add(notificacion).Context.SaveChanges();
            return result;
        }

        [HttpPut("{id}")]
        public int Put(int id, [FromBody] notificaciones notificafionActualizada)
        {
            notificaciones notificacionBuscada = context.notificaciones.FirstOrDefault(c => c.idnotificacion == id);

            if (notificacionBuscada == null) { return 0; }

            notificacionBuscada.idnotificacion = notificafionActualizada.idnotificacion;
            notificacionBuscada.categoria = notificafionActualizada.categoria;
            notificacionBuscada.descripcion = notificafionActualizada.descripcion;
            notificacionBuscada.fechaNotificacion = notificafionActualizada.fechaNotificacion;
            notificacionBuscada.idUsuario = notificafionActualizada.idUsuario;
            notificacionBuscada.idDeuda = notificafionActualizada.idDeuda;

            int result = context.SaveChanges();

            return result;
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            notificaciones? notificacionBuscada = context.notificaciones.FirstOrDefault(c => c.idnotificacion == id);

            if (notificacionBuscada != null)
            {
                response = context.notificaciones.Remove(notificacionBuscada).Context.SaveChanges();
            }
            return response;
        }
    }
}
