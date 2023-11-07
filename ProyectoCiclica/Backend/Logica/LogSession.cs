using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogSession
    {

        public Session obtenerSession(String session) {
            Session objetoSession = new Session();
            int? errorId = 0;
            int? idReturn = 0;//idusuario
            string errorDescripcion = "";

            conexionlinqDataContext miLinq = new conexionlinqDataContext();
            sp_ObtenerSessionResult sessionLinq = (sp_ObtenerSessionResult) miLinq.sp_ObtenerSession(session, ref idReturn, ref errorId, ref errorDescripcion);
            if (errorId == 0 && idReturn != 0)
            {
                //Agregar resto de campos 
                objetoSession.SessionId = sessionLinq.SESSION_ID;
                objetoSession.Session_User_Id = sessionLinq.SESSION_USER_ID;
                objetoSession.SessionCod = sessionLinq.SESSION;
                objetoSession.Session_Fecha_Inicio = (DateTime)sessionLinq.SESSION_FECHA_INICIO;
                objetoSession.Session_Fecha_Final = (DateTime)sessionLinq.SESSION_FECHA_FINAL;
                objetoSession.Session_Estado = (bool)sessionLinq.SESSION_ESTADO;
            }
            else
            {
                objetoSession = null;
            }
            return objetoSession;
        }

        public Boolean ingresarSession(int idUsuario)
        {
            int? errorId = 0;
            int? idReturn = 0;//idusuario
            string errorDescripcion = "";

            conexionlinqDataContext miLinq = new conexionlinqDataContext();
            miLinq.sp_IngresarSession(idUsuario, Guid.NewGuid().ToString() ,ref idReturn, ref errorId, ref errorDescripcion);
            if (errorId == 0 && idReturn != 0)
            {
                //Agregar resto de campos 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
