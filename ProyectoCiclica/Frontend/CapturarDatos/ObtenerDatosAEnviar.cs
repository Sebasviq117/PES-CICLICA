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
        public static List<Anticonceptivos> anticonceptivos { get; set; }
        public static List<Notifi_Anticonceptivos> historialAnticoncep { get; set; }
        public static List<Consejos> consejos { get; set; }
        public static CollectionView pestañaConsejos { get; set; }

    }
}
