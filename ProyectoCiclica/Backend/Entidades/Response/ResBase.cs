﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ResBase
    {
        public Boolean resultado {  get; set; }

        public String errorMensaje { get; set; }

        public int errorCode { get; set; }
    }
}
