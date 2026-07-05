using Practica2.BLL.DTO;

namespace Practica2.BLL.Service.Categoria
{
    public interface ICategoriaServicio
    {
        Task<RespuestaDTO<List<CategoriaDTO>>> GetCategorias();
        Task<RespuestaDTO<CategoriaDTO?>> GetCategoriaById(int id);
        Task<RespuestaDTO<CategoriaDTO>> CreateCategoria(
            CategoriaDTO categoria);
        Task<RespuestaDTO<CategoriaDTO>> UpdateCategoria(
            CategoriaDTO categoria);
        Task<RespuestaDTO<CategoriaDTO>> DeleteCategoria(int id);
    }


}
