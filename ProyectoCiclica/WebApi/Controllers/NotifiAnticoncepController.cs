using Backend.Entidades;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class NotifiAnticoncepController : ApiController
    {
        [HttpPost]
        [Route("api/Notifi_Anticoncep/InsertarNotificaciones")]
        public ResInsertarNotificaciones InsertarNotificaciones(ReqInsertarNotificaciones req)
        {
            LogCicloMenstrual miLogica = new LogCicloMenstrual();
            return miLogica.InsertarNotificaciones(req);
        }
    }
}