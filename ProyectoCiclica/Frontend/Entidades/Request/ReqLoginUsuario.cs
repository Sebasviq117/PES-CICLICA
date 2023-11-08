using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Entidades.Request
{
    public class ReqLoginUsuario : ReqBase
    {
        public Login userLog { get; set; }
    }
}
