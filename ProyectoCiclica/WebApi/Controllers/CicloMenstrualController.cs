using Backend.Entidades;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CicloMenstrualController : ApiController
    {
        //POST: CicloMenstrual
        [HttpPost]
        [Route("api/CicloMenstrual/IngresarCicloMenstrual")]
        public ResIngresarCicloMenstrual IngresarCicloMenstrual(ReqIngresarCicloMenstrual req)
        {
            LogCicloMenstrual miLogica = new LogCicloMenstrual();
            return miLogica.IngresarCicloMenstrual(req);
        }

    }
}