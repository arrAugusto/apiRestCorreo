using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using AttachedCommandBehavior;

namespace apiRestCorreo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class conectController : ControllerBase
    {
        //string de conexion
        private string conection = @"Server=bwajkqhku6unxpau1riz-mysql.services.clever-cloud.com; Database=bwajkqhku6unxpau1riz; Uid=ufd0ibkz6bmalqof; Pwd=7koeQc4MmQxje5BCizTd";
        //metodo de get para consulta con parametros
        [HttpGet]
        //accion de metodo
        public ActionResult Get(models.viewUser modelsView)
        {
            //objeto vacio
            ClassName[] allRecords = null;
            //strin de respuesta

            string status = "NoAutorizado";

            using (var db = new MySqlConnection(conection))
            {

                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mailUser", modelsView.name_email);
                cmd.CommandText = "spLogUsuario";
                db.Open();
                using (var reader = cmd.ExecuteReader())
                {

                    var list = new List<ClassName>();
                    while (reader.Read())
                        list.Add(new ClassName { name_email = reader.GetString(0), pass_email = reader.GetString(1) });
                    allRecords = list.ToArray();
                }
                if (allRecords.Length > 0)
                {
                if (allRecords[0].name_email == modelsView.name_email && allRecords[0].pass_email == modelsView.pass_email)
                {
                    status = "Autorizado";
                }
                }
            }
            return Ok(status);

        }
 
        [HttpPost]
        public ActionResult Insert(models.newUsuario models){
           int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_usuario", models.nom_usuario);
                cmd.Parameters.AddWithValue("@ape_usuario", models.ape_usuario);
                cmd.Parameters.AddWithValue("@name_email", models.name_email);
                cmd.Parameters.AddWithValue("@pass_email", models.pass_email);
                cmd.Parameters.AddWithValue("@telefono", models.telefono);
                cmd.Parameters.AddWithValue("@codigo", models.codigo);
                cmd.CommandText = "spNewUserSys";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);
        }
    }
}
