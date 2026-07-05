using AutoMapper;
using Practica2.BLL.DTO;
using Practica2.DAL.Repository.Categoria;


namespace Practica2.BLL.Service.Categoria
{

    public class CategoriaServicio : ICategoriaServicio
    {

        //Inyección de dependencias
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;


        // Inyeccion de dependencias del repositorio de categoria, que utiliza el repositorio genérico y el mapper para mapear entre entidades y DTOs
        public CategoriaServicio(
            ICategoriaRepositorio categoriaRepositorio,
            IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaDTO<List<CategoriaDTO>>> GetCategorias()
        {
            var respuesta = new RespuestaDTO<List<CategoriaDTO>>();

            var lista = await _categoriaRepositorio.ObtenerTodosAsync();

            respuesta.Dato = _mapper.Map<List<CategoriaDTO>>(lista);

            return respuesta;
        }

        public async Task<RespuestaDTO<CategoriaDTO?>> GetCategoriaById(int id)
        {
            var respuesta = new RespuestaDTO<CategoriaDTO?>();

            var entity = await _categoriaRepositorio.ObtenerPorIdAsync(id);

            if (entity == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Categoría no encontrada";
                respuesta.codigo = 404;

                return respuesta;
            }

            respuesta.Dato = _mapper.Map<CategoriaDTO>(entity);

            return respuesta;
        }



        public async Task<RespuestaDTO<CategoriaDTO>> DeleteCategoria(int id)
        {
            var respuesta = new RespuestaDTO<CategoriaDTO>();

            _categoriaRepositorio.EliminarAsync(id);

            if (!await _categoriaRepositorio.SaveChangesAsync())
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo eliminar la categoría";
                respuesta.codigo = 500;
            }

            return respuesta;
        }


        public async Task<RespuestaDTO<CategoriaDTO>> CreateCategoria(
            CategoriaDTO categoria)
        {
            var respuesta = new RespuestaDTO<CategoriaDTO>();

            if (categoria == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Categoría inválida";
                respuesta.codigo = 400;

                return respuesta;
            }

            var entity = _mapper.Map<Practica2.DAL.Entities.Categoria>(categoria);

            _categoriaRepositorio.AgregarAsync(entity);

            if (!await _categoriaRepositorio.SaveChangesAsync())
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo crear la categoría";
                respuesta.codigo = 500;

                return respuesta;
            }

            respuesta.Dato = categoria;

            return respuesta;
        }



        public async Task<RespuestaDTO<CategoriaDTO>> UpdateCategoria(
            CategoriaDTO categoria)
        {
            var respuesta = new RespuestaDTO<CategoriaDTO>();

            if (categoria == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Categoría inválida";
                respuesta.codigo = 400;

                return respuesta;
            }

            var entity = _mapper.Map<Practica2.DAL.Entities.Categoria>(categoria);

            _categoriaRepositorio.ActualizarAsync(entity);

            if (!await _categoriaRepositorio.SaveChangesAsync())
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo actualizar la categoría";
                respuesta.codigo = 500;

                return respuesta;
            }

            respuesta.Dato = categoria;

            return respuesta;
        }
    }
}
