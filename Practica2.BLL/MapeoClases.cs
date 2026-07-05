using AutoMapper;

namespace Practica2.BLL
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap<DAL.Entities.Categoria, DTO.CategoriaDTO>().ReverseMap();
            CreateMap<DAL.Entities.Producto, DTO.ProductoDTO>().ReverseMap();
        }
    }
}
