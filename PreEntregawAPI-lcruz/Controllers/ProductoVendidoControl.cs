using Microsoft.AspNetCore.Mvc;
using PreEntregawAPI_lcruz.ADO;
using PreEntregawAPI_lcruz.Models;
using System.Xml.Linq;

namespace PreEntregawAPI_lcruz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductoVendido")]
        public List<ProductoVendido> Get()
        {
            return ADO_ProductoVendido.TraeProductoVendido();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_ProductoVendido.EliminarProductoVendido(id);
        }
        [HttpPut]
        public void Modificar([FromBody] ProductoVendido pv)
        {
            ADO_ProductoVendido.ModificarProductoVendido(pv);
        }
        [HttpPost]
        public void Agregar([FromBody] ProductoVendido pv)
        {
            ADO_ProductoVendido.AgregarProductoVendido(pv);
        }
    }
}
