using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace apiRestCorreo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class conectController : ControllerBase
    {
        //string de conexion
        private string conection = @"Server=localhost; Database=corp_capsula; Uid=root;";
        //metodo de get para consulta con parametros
        [HttpGet]
        //accion de metodo
        public ActionResult Get(models.viewUser modelsView)
        {

            //objeto vacio
            ClassName[] allRecords = null;
            //strin de respuesta

            var listResponse = new List<models.ResponseGetUsuario>();

            using (var db = new MySqlConnection(conection))
            {
                //String response al cliente
                string responseView = "NotConect";
                //Inicializando el query
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameEmail", modelsView.nameEmail);
                cmd.CommandText = "spUsuarioLogin";
                db.Open();
                //Ejecutando el query
                using (var reader = cmd.ExecuteReader())
                {
                    var list = new List<ClassName>();
                    while (reader.Read())
                        list.Add(new ClassName
                        {
                            name_email = reader.GetString(0),
                            pass_email = reader.GetString(1)
                        });
                    allRecords = list.ToArray();
                }
                if (allRecords.Length > 0)
                {
                    if (allRecords[0].name_email == modelsView.nameEmail && allRecords[0].pass_email == modelsView.pass_email)
                    {
                        responseView = "conect";
                    }
                }
                string[] fmsDB = new string[] {
          responseView
        };
                return Ok(fmsDB);
            }

        }

        [HttpPost]
        public ActionResult Insert(models.newUsuario models)
        {
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_proveedorParam", models.id_proveedorParam);
                cmd.Parameters.AddWithValue("@nom_usuarioParam", models.nom_usuarioParam);
                cmd.Parameters.AddWithValue("@ape_usuarioParam", models.ape_usuarioParam);
                cmd.Parameters.AddWithValue("@name_emailParam", models.name_emailParam);
                cmd.Parameters.AddWithValue("@pass_emailParam", models.pass_emailParam);
                cmd.Parameters.AddWithValue("@telefonoParam", models.telefonoParam);
                cmd.Parameters.AddWithValue("@nivelParam", models.nivelParam);
                cmd.CommandText = "spNewUsuario";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);

        }
        [HttpPut]
        public ActionResult Update(models.EditUsuario models)
        {
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_proveedorParam", models.id_proveedorParam);
                cmd.Parameters.AddWithValue("@nom_usuarioParam", models.nom_usuarioParam);
                cmd.Parameters.AddWithValue("@ape_usuarioParam", models.ape_usuarioParam);
                cmd.Parameters.AddWithValue("@name_emailParam", models.name_emailParam);
                cmd.Parameters.AddWithValue("@pass_emailParam", models.pass_emailParam);
                cmd.Parameters.AddWithValue("@telefonoParam", models.telefonoParam);
                cmd.Parameters.AddWithValue("@es_activoParam", models.es_activoParam);
                cmd.Parameters.AddWithValue("@nivelParam", models.nivelParam);
                cmd.Parameters.AddWithValue("@idUser", models.idUser);
                cmd.CommandText = "spUpdateUser";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);

        }
        [HttpDelete]
        public ActionResult Delete(models.DeleteUsuario models)
        {
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", models.idUser);
                cmd.CommandText = "spDeleteUsuario";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);

        }
    }
}