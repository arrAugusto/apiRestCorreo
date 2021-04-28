using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestCorreo.Controllers.models
{
    //ESTRUCTURA USADA PARA MOSTRAR USUARIOS
    public class dataUsser
    {
        public string nom_usuario { get; set; }
        public string ape_usuario { get; set; }
        public string name_email { get; set; }
        public string telefono { get; set; }
        public string codigo { get; set; }
        public string es_activo { get; set; }
        public string es_admin { get; set; }
        public string fecha_creacion { get; set; }

    }      

    //STRUCTURA PARA AGREGAR NUEVOS USUARIOS AL SISTEMA
    public class newUsuario
    {
        public string nom_usuario { get; set; }
        public string ape_usuario { get; set; }
        public string name_email { get; set; }
        public string pass_email { get; set; }
        public string telefono { get; set; }
        public string codigo { get; set; }
        public string es_activo { get; set; }
        public string es_admin { get; set; }

    }

}
