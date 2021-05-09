using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestCorreo.Controllers.models
{
    public class Proveedor
    {
        public string razon_socialParam { get; set; }
        public string dominio_emailParam { get; set; }
        public string nitParam { get; set; }
        public string telefonoParam { get; set; }
        public string direccionParam { get; set; }

    }
    public class UpdateProveedor
    {
        public string razon_socialParam { get; set; }
        public string dominio_emailParam { get; set; }
        public string nitParam { get; set; }
        public string telefonoParam { get; set; }
        public string direccionParam { get; set; }
        public int id_proveedor { get; set; }

    }
    public class DeleteProveedor
    {

        public int idProve { get; set; }

    }
    public class SelectProveedor
    {

        public int idProve { get; set; }
        public int tipo { get; set; }

    }



}
