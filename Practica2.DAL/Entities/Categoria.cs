using System;
using System.Collections.Generic;
using System.Text;

namespace Practica2.DAL.Entities
{
    public partial class Categoria
    {
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
