using Microsoft.AspNetCore.Mvc;
using PreEntregawAPI_lcruz.ADO;
using PreEntregawAPI_lcruz.Models;
using System.Xml.Linq;

namespace PreEntregawAPI_lcruz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> Get()
        {
            return ADO_Venta.TraeVentas();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Venta.EliminarVenta(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Venta ven)
        {
            ADO_Venta.ModificarVenta(ven);
        }
        [HttpPost]
        public void Agregar([FromBody] Venta ven)
        {
            ADO_Venta.AgregarVenta(ven);
        }
    }
}
