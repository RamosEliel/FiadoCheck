using Microsoft.AspNetCore.Mvc;
using FiadoCheck_API.Models;
using FiadoCheck_API.Context;

namespace FiadoCheck_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {

        private readonly FiadoCheckDbContext context;
        public UsuariosController(FiadoCheckDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IEnumerable<usuarios> Get()
        {
            return context.usuarios.ToList();
        }


        [HttpGet("{id}")]
        public usuarios Get(int id)
        {
            return context.usuarios.Find(id);
        }


        [HttpPost]
        public int Post([FromBody] usuarios usuario)
        {
            int result = context.usuarios.Add(usuario).Context.SaveChanges();
            return result;
        }


        [HttpPut("{id}")]
        public int Put(int id, [FromBody] usuarios usuarioActualizado)
        {
            usuarios usuarioBuscado = context.usuarios.FirstOrDefault(p => p.idUsuario == id);

            if (usuarioBuscado == null) { return 0; }

            usuarioBuscado.idUsuario = usuarioBuscado.idUsuario;
            usuarioBuscado.nombreUsuario = usuarioBuscado.nombreUsuario;
            usuarioBuscado.password = usuarioBuscado.password;
            usuarioBuscado.rol = usuarioBuscado.rol;
            usuarioBuscado.idCliente = usuarioBuscado.idCliente;
            int result = context.SaveChanges();

            return result;
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            usuarios usuarioBuscado = context.usuarios.FirstOrDefault(p => p.idUsuario == id);

            if (usuarioBuscado != null)
            {
                response = context.usuarios.Remove(usuarioBuscado).Context.SaveChanges();
            }
            return response;
        }

    }
}
