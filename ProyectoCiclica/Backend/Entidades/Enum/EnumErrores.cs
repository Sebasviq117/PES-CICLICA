using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public enum EnumErrores
    {
        //Catalogo de errorres
        ErrorInterno = -1,
        NombreFaltante = 001,
        PrimerApellidoFaltante = 002,
        SegundoApellidoFaltante = 003,
        CorreoFaltante = 004,
        ContrasenaFaltante = 005,
        ErrorLogin = 006,
        ErrorSession = 007,
        SessionFaltante = 008,
    }
}
