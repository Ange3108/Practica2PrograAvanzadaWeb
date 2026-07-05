using Microsoft.AspNetCore.Mvc;
using Practica2.BLL.DTO;
using Practica2.BLL.Service.Categoria;

namespace Practica2.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly ICategoriaServicio _categoriaServicio;

        public CategoriaController(
            ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCategorias()
        {
            var respuesta = await _categoriaServicio.GetCategorias();
            return Json(respuesta);
        }

        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var respuesta =
                await _categoriaServicio.GetCategoriaById(id);

            return Json(respuesta);
        }

        public async Task<IActionResult> CreateCategoria(
            CategoriaDTO categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var respuesta =
                await _categoriaServicio.CreateCategoria(categoria);

            return Json(respuesta);
        }

        public async Task<IActionResult> UpdateCategoria(
            CategoriaDTO categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var respuesta =
                await _categoriaServicio.UpdateCategoria(categoria);

            return Json(respuesta);
        }

        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var respuesta =
                await _categoriaServicio.DeleteCategoria(id);

            return Json(respuesta);
        }
    }
}
