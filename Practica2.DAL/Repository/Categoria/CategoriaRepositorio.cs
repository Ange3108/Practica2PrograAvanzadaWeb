using Practica2.DAL.Data;

namespace Practica2.DAL.Repository.Categoria
{
    public class CategoriaRepositorio : RepositorioGenerico<Entities.Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(
            ApplicationDbContext context): base(context)
        {


        }
    }
}


