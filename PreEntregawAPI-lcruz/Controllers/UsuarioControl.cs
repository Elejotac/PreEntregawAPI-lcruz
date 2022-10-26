using Microsoft.AspNetCore.Mvc;
using PreEntregawAPI_lcruz.ADO;
using PreEntregawAPI_lcruz.Models;
using System.Xml.Linq;

namespace PreEntregawAPI_lcruz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> Get()
        {
            return ADO_Usuario.TraeUsuarios();
        }

        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Usuario.EliminarUsuario(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Usuario u)
        {
            ADO_Usuario.ModificarUsuario(u);
        }
        [HttpPost]
        public void Agregar([FromBody] Usuario u)
        {
            ADO_Usuario.AgregarUsuario(u);
        }
    }
}
