using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogCicloMenstrual
    {
        public ResIngresarCicloMenstrual IngresarCicloMenstrual(ReqIngresarCicloMenstrual req)
        {
            ResIngresarCicloMenstrual res = new ResIngresarCicloMenstrual();

            try
            {   //debo quitarlo?? ya que se debe obtener de la session
                if (LogSession.EvaluarSession(req.session)) 
                { 
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }

                if (req.elcicloMenstrual.UsuarioID == 0)
                {
                    res.resultado = false;
                    res.errorMensaje = "Id Usuario Faltante";
                }
                else if (req.elcicloMenstrual.FechaInicioCiclo == null)
                {
                    res.resultado = false;
                    res.errorMensaje = "Fecha Faltante";
                }
                else if (req.elcicloMenstrual.DuracionCiclo == 0)
                {
                    res.resultado = false;
                    res.errorMensaje = "Duracion Ciclo Faltante";
                }
                else if (req.elcicloMenstrual.DuracionMenstruacion == 0)
                {
                    res.resultado = false;
                    res.errorMensaje = "Duracion Menstruacion Faltante";
                }
                else if (req.elcicloMenstrual.FechaNacimiento == null)
                {
                    res.resultado = false;
                    res.errorMensaje = "Fecha Nacimiento faltante";
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.sp_IngresarRegistroCicloMenstrual(req.elcicloMenstrual.UsuarioID, req.elcicloMenstrual.FechaInicioCiclo, req.elcicloMenstrual.DuracionCiclo, req.elcicloMenstrual.DuracionMenstruacion, req.elcicloMenstrual.FechaNacimiento, ref idReturn, ref errorId, ref errorDescripcion);
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.resultado = true;
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorMensaje = "error interno";
                        Console.WriteLine(errorDescripcion);

                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
    }
}