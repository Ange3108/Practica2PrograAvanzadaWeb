using Practica2.BLL.DTO;

namespace Practica2.BLL.Service.Producto
{

    public interface IProductoServicio
    {
        Task<RespuestaDTO<List<ProductoDTO>>> GetProductos();
        Task<RespuestaDTO<ProductoDTO?>> GetProductoById(int id);
        Task<RespuestaDTO<ProductoDTO>> CreateProducto(
            ProductoDTO producto);
        Task<RespuestaDTO<ProductoDTO>> UpdateProducto(
            ProductoDTO producto);
        Task<RespuestaDTO<ProductoDTO>> DeleteProducto(int id);
    }


}
