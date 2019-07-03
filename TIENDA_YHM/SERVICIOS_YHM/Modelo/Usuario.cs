using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVICIOS_YHM.Modelo
{
    public class Usuario
    {
        public int id { get; set; }
        public string strUsuario { get; set; }
        public string strPass { get; set; }
        public string dateFechaRegistro { get; set; }
        public bool bitEstatus { get; set; }
    }
}