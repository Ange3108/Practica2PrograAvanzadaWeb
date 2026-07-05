using Microsoft.AspNetCore.Mvc;
using Practica2.BLL.DTO;
using Practica2.BLL.Service.Producto;

namespace Practica2.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IProductoServicio _productoServicio;

        public ProductoController(
            IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProductos()
        {
            var respuesta = await _productoServicio.GetProductos();

            return Json(respuesta);
        }

        public async Task<IActionResult> GetProductoById(int id)
        {
            var respuesta =
                await _productoServicio.GetProductoById(id);

            return Json(respuesta);
        }

        public async Task<IActionResult> CreateProducto(
            ProductoDTO producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var respuesta =
                await _productoServicio.CreateProducto(producto);

            return Json(respuesta);
        }

        public async Task<IActionResult> UpdateProducto(
            ProductoDTO producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var respuesta =
                await _productoServicio.UpdateProducto(producto);

            return Json(respuesta);
        }

        public async Task<IActionResult> DeleteProducto(int id)
        {
            var respuesta =
                await _productoServicio.DeleteProducto(id);

            return Json(respuesta);
        }
    }
}
