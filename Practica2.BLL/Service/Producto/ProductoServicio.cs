using AutoMapper;
using Practica2.BLL.DTO;
using Practica2.DAL.Repository.Producto;

namespace Practica2.BLL.Service.Producto
{

    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IMapper _mapper;

        public ProductoServicio(
            IProductoRepositorio productoRepositorio,
            IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaDTO<List<ProductoDTO>>> GetProductos()
        {
            var respuesta = new RespuestaDTO<List<ProductoDTO>>();

            var lista = await _productoRepositorio.ObtenerTodosAsync();

            respuesta.Dato = _mapper.Map<List<ProductoDTO>>(lista);

            return respuesta;
        }

        public async Task<RespuestaDTO<ProductoDTO?>> GetProductoById(int id)
        {
            var respuesta = new RespuestaDTO<ProductoDTO?>();

            var entity = await _productoRepositorio.ObtenerPorIdAsync(id);

            if (entity == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Producto no encontrado";
                respuesta.codigo = 404;

                return respuesta;
            }

            respuesta.Dato = _mapper.Map<ProductoDTO>(entity);

            return respuesta;
        }

        public async Task<RespuestaDTO<ProductoDTO>> DeleteProducto(int id)
        {
            var respuesta = new RespuestaDTO<ProductoDTO>();

            _productoRepositorio.EliminarAsync(id);

            if (!await _productoRepositorio.SaveChangesAsync())
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo eliminar el producto";
                respuesta.codigo = 500;
            }

            return respuesta;
        }


        public async Task<RespuestaDTO<ProductoDTO>> CreateProducto(
            ProductoDTO producto)
        {
            var respuesta = new RespuestaDTO<ProductoDTO>();

            if (producto == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Producto inválido";
                respuesta.codigo = 400;

                return respuesta;
            }

            var entity = _mapper.Map<Practica2.DAL.Entities.Producto>(producto);

            _productoRepositorio.AgregarAsync(entity);

            if (!await _productoRepositorio.SaveChangesAsync())
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo crear el producto";
                respuesta.codigo = 500;

                return respuesta;
            }

            respuesta.Dato = producto;

            return respuesta;
        }


        public async Task<RespuestaDTO<ProductoDTO>> UpdateProducto(
            ProductoDTO producto)
        {
            var respuesta = new RespuestaDTO<ProductoDTO>();

            if (producto == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Producto inválido";
                respuesta.codigo = 400;

                return respuesta;
            }

            var entity = _mapper.Map<Practica2.DAL.Entities.Producto>(producto);

            _productoRepositorio.ActualizarAsync(entity);

            if (!await _productoRepositorio.SaveChangesAsync())
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo actualizar el producto";
                respuesta.codigo = 500;

                return respuesta;
            }

            respuesta.Dato = producto;

            return respuesta;
        }

    }
}
