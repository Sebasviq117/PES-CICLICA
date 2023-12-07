using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogNotifiAnticoncep
    {
        public ResActualizarNotificaciones actualizarNotificaciones(ReqActualizarNotificaciones req)
        {
            ResActualizarNotificaciones res = new ResActualizarNotificaciones();

            return res;
        }
        public  ResObtenerAnticonceptivos obtenerAnticonceptivos(ReqObtenerAnticonceptivos req)
        {
            ResObtenerAnticonceptivos res = new ResObtenerAnticonceptivos();

            return res;
        }
        public  ResHistorialAnticonceptivos historialAnticonceptivos(ReqHistorialAnticonceptivos req)
        {
            ResHistorialAnticonceptivos res = new ResHistorialAnticonceptivos();

            return res;
        }
        public  ResMostrarConsejos mostrarConsejos(ReqMostrarConsejos req)
        {
            ResMostrarConsejos res = new ResMostrarConsejos();

            return res;
        }
    }
    
}
