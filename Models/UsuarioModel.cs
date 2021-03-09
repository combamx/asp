using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public  class UsuarioModel
    {
        public  String Nombre { get; set; }
        public  String Ape_Paterno { get; set; }
        public  String Ape_Materno { get; set; }
        public  int Edad { get; set; }
        public  String CorreoElectronico { get; set; }
        public  String Telefono { get; set; }

    }
}
