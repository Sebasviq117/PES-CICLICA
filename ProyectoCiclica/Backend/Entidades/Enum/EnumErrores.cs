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
        //Errores de Session
        ErrorSession = 007,
        SessionFaltante = 008,
        SessionCerrada = 009,
        SessionInvalida = 010,
        //Errores de Ciclo Menstrual
        FechaFaltante = 011,
        DuracionCicloFaltante = 012,
        DuracionMenstrualFaltante = 013,
        ErrorCicloMenstrual = 014,
        ErrorUsuario = 015,
        //Errores de Anticonceptivos
        AnticonceptivoInexistente = 021,
        EstadoDeNotifi_0 = 022,
        SinRegistro = 023,
        ErrorDeNotificacion = 24,
        YaExisteRegistroNotifi = 25,
    }
}
