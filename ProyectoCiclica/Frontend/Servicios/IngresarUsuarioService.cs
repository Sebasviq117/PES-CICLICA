using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;
using Frontend.Entidades;

namespace Frontend.Servicios
{
    public interface IngresarUsuarioService
    {
        Task<ResLoginUsuario> Login(string UserCorreo, string UserContraseña);
    }
}
