using Practica2.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica2.DAL.Repository.Categoria
{


    public class CategoriaRepository : RepositorioGenerico<Entities.Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepository(
            ApplicationDbContext context): base(context)
        {


        }
    }
}


