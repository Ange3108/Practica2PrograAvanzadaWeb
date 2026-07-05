using Microsoft.AspNetCore.Mvc;
using Practica2.BLL.DTO;
using Practica2.BLL.Service.Producto;
using Practica2.BLL.Service.Categoria;

namespace Practica2.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoServicio _productoServicio;
        private readonly ICategoriaServicio _categoriaServicio;

        public ProductoController(
            IProductoServicio productoServicio,
            ICategoriaServicio categoriaServicio)
        {
            _productoServicio = productoServicio;
            _categoriaServicio = categoriaServicio;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaServicio.GetCategorias();

            ViewBag.Categorias = categorias.Dato;

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
