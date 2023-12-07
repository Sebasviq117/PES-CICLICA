using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class CategoriaProductos
    {
        public int idCategoriaProducto { get; set; }
        public int nombre { get; set; }
        public int descripcion { get; set; }
        public int idProducto { get; set; }

    }
}
