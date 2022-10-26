using Microsoft.AspNetCore.Mvc;
using PreEntregawAPI_lcruz.ADO;
using PreEntregawAPI_lcruz.Models;
using System.Xml.Linq;

namespace PreEntregawAPI_lcruz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> Get()
        {
            return ADO_Producto.TraeProductos();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Producto p)
        {
            ADO_Producto.ModificarProducto(p);
        }
        [HttpPost]
        public void Agregar([FromBody] Producto p)
        {
            ADO_Producto.AgregarProducto(p);
        }
    }
}
