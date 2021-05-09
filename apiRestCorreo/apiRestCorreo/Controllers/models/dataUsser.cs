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
        public int id_proveedorParam { get; set; }

        public string nom_usuarioParam { get; set; }
        public string ape_usuarioParam { get; set; }
        public string name_emailParam { get; set; }
        public string pass_emailParam { get; set; }
        public string telefonoParam { get; set; }
        public int nivelParam { get; set; }


    }
    //STRUCTURA PARA MODIFICAR NUEVOS USUARIOS AL SISTEMA
    public class EditUsuario
    {
        public int id_proveedorParam { get; set; }
        public string nom_usuarioParam { get; set; }
        public string ape_usuarioParam { get; set; }
        public string name_emailParam { get; set; }
        public string pass_emailParam { get; set; }
        public string telefonoParam { get; set; }
        public int es_activoParam { get; set; }
        public int nivelParam { get; set; }
        public int idUser { get; set; }

    }
    public class DeleteUsuario
    {
        public int idUser { get; set; }
    }
    public class viewUser
    {
        public string nameEmail { get; set; }
        public string pass_email     { get; set; }
    }
    public class ResponseGetUsuario
    {
        public string responseUsuario { get; set; }
    }

}

public class ClassName
{
    public string name_email { get; set; }
    public string pass_email { get; set; }
}


public class responseListProveedor
{
    public Int64 id_proveedor { get; set; }
    public string razon_social { get; set; }
    public string dominio_email { get; set; }
    public string nit { get; set; }
    public string telefono { get; set; }
    public string direccion { get; set; }
    public string fecha_creacion { get; set; }
}