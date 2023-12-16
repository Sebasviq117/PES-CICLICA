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
        // Diccionario que mapea ID de anticonceptivo con la ruta de la imagen
        private Dictionary<int, string> idImagenMapping = new Dictionary<int, string>();

        public ListaHistorial()
        {
            // Asigna ID a la imagen para cada anticonceptivo
            idImagenMapping.Add(1, "Resources/Images/pastillas_anticonceptivas.png");
            idImagenMapping.Add(2, "Resources/Images/inyeccion.png");
            idImagenMapping.Add(3, "Resources/Images/diu.png");
            idImagenMapping.Add(4, "Resources/Images/parche.png");
            idImagenMapping.Add(5, "Resources/Images/implante.png");
            idImagenMapping.Add(6, "Resources/Images/anillo.png");
            // Añade más según sea necesario
        }
        // Método para obtener la ruta de la imagen según el ID del anticonceptivo
        public string ObtenerRutaImagen(int idAnticonceptivo)
        {
            if (idImagenMapping.ContainsKey(idAnticonceptivo))
            {
                return idImagenMapping[idAnticonceptivo];
            }
            else
            {
                // Devuelve una imagen predeterminada si el ID no está en el diccionario
                return "imagen_predeterminada.png";
            }
        }
        public string Nombre { get; set; } = ObtenerDatosAEnviar.NombreAnticoncep;
        public string Imagen { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
    }
}
