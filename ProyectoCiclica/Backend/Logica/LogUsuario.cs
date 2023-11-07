using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Backend.Logica
{
    public class LogUsuario
    {
        public ResIngresarUsuario IngresarUsuario(ReqIngresarUsuario req)
        {
            ResIngresarUsuario res = new ResIngresarUsuario();

            try
            {
                if (String.IsNullOrEmpty(req.elUsuario.nombre))
                {
                    res.resultado = false;
                    res.errorMensaje = "Nombre faltante";
                    res.errorCode = (int)EnumErrores.NombreFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.primerApellido))
                {
                    res.resultado = false;
                    res.errorMensaje = "Primer Apellido faltante";
                    res.errorCode = (int)EnumErrores.PrimerApellidoFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.segundoApellido))
                {
                    res.resultado = false;
                    res.errorMensaje = "Segundo Apellido faltante";
                    res.errorCode = (int)EnumErrores.SegundoApellidoFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.correo))
                {
                    res.resultado = false;
                    res.errorMensaje = "Correo faltante";
                    res.errorCode = (int)EnumErrores.CorreoFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.contrasena))
                {
                    res.resultado = false;
                    res.errorMensaje = "Contrasena faltante";
                    res.errorCode = (int)EnumErrores.ContrasenaFaltante;
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";
                    int iDUsuario = req.elUsuario.idUsuario;

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.sp_IngresarUsuario(req.elUsuario.nombre, req.elUsuario.primerApellido, req.elUsuario.segundoApellido, req.elUsuario.correo, req.elUsuario.contrasena, ref idReturn, ref errorId, ref errorDescripcion);
                    // realize una variable de tipo Int para capturar el IdUsuario una vez creado el usuario
                    
                    LogSession logSession = new LogSession();
                    //instancie logSession para poder utilizar el metodo ingresarSession, y como parametro me solicita un IdUsuario, se habia declarado una variable

                    bool sessionCreada = logSession.ingresarSession(iDUsuario);
                    //si la session fue creada, tons debe ser diferente a false por que ingresar session es bool

                    if (errorId == 0 && idReturn != 0 && sessionCreada != false)
                    {
                        //Exitos
                        res.resultado = true;
                    }
                    else
                    {
                        //Error en la base de datos
                        res.resultado = false;
                        res.errorMensaje = "Error interno";
                        res.errorCode = (int)EnumErrores.ErrorInterno;
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                res.errorCode = (int)EnumErrores.ErrorInterno;
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        public ResLoginUsuario LoginUsuario(ReqLoginUsuario req)
        {
            ResLoginUsuario res = new ResLoginUsuario();

            try
            {
                if (String.IsNullOrEmpty(req.userLog.correo))
                {
                    res.resultado = false;
                    res.errorMensaje = "Correo faltante";
                    res.errorCode = (int)EnumErrores.CorreoFaltante;
                }
                else if (String.IsNullOrEmpty(req.userLog.contrasena))
                {
                    res.resultado = false;
                    res.errorMensaje = "Contrasena faltante";
                    res.errorCode = (int)EnumErrores.ContrasenaFaltante;
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS p
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.SP_LoginUsuario(req.userLog.correo, req.userLog.contrasena, ref idReturn, ref errorId, ref errorDescripcion);
                    sp_ObtenerSessionResult miSession = new sp_ObtenerSessionResult();
                    //Validar correo , contrasena y  **si la session se creo
                    if (errorId == 0 && idReturn != 0)
                    {
                        //Exitoso
                        res.resultado = true;
                    }
                    else
                    {
                        //Error en la base de datos
                        res.resultado = false;
                        res.errorMensaje = "Error de login";
                        res.errorCode = (int)EnumErrores.ErrorLogin;
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                res.errorCode = (int)EnumErrores.ErrorInterno;
                Console.WriteLine(ex.Message);
            }
            return res;
        }

    }
    }
