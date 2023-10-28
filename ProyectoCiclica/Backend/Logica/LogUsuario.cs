using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogUsuario
    {
        public ResIngresarUsuario IngresarUsuario(ReqIngresarUsuario req) {
            ResIngresarUsuario res = new ResIngresarUsuario();

            try {
                if (String.IsNullOrEmpty(req.elUsuario.nombre))
                {
                    res.resultado = false;
                    res.errorMensaje = "Nombre faltante";
                }
                else if (String.IsNullOrEmpty(req.elUsuario.primerApellido))
                {
                    res.resultado = false;
                    res.errorMensaje = "Primer Apellido faltante";
                }
                else if (String.IsNullOrEmpty(req.elUsuario.segundoApellido))
                {
                    res.resultado = false;
                    res.errorMensaje = "Segundo Apellido faltante";
                }
                else if (String.IsNullOrEmpty(req.elUsuario.correo))
                {
                    res.resultado = false;
                    res.errorMensaje = "Correo faltante";
                }
                else if (String.IsNullOrEmpty(req.elUsuario.contrasena))
                {
                    res.resultado = false;
                    res.errorMensaje = "Contrasena faltante";
                }
                else {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.sp_IngresarUsuario(req.elUsuario.nombre, req.elUsuario.primerApellido, req.elUsuario.segundoApellido, req.elUsuario.correo, req.elUsuario.contrasena, ref idReturn, ref errorId, ref errorDescripcion);
                    if (errorId == 0 && idReturn != 0)
                    {
                        //Exitoso
                        res.resultado = true;
                    }
                    else
                    {
                        //Error en la base de datos
                        res.resultado = false;
                        res.errorMensaje = "Error interno";
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
