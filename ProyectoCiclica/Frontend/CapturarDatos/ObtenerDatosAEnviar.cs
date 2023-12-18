using Frontend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.CapturarDatos
{
   public static class ObtenerDatosAEnviar
    {
        public static string Session { get; set; }
        public static int IdAnticoncep { get; set; }
        public static int CategoriaProductoId { get; set; }
        public static string NombreAnticoncep { get; set; }
        public static string ImagenAnticoncep { get; set; }
        public static List<Producto> ListaProductos { get; set; }

    }
}
