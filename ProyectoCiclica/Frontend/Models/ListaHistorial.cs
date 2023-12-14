using Frontend.CapturarDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class ListaHistorial
    {
        public string Nombre { get; set; } = ObtenerDatosAEnviar.NombreAnticoncep;
        public string Imagen { get; set; } = ObtenerDatosAEnviar.ImagenAnticoncep;
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
    }
}
