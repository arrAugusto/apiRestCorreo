using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace apiRestCorreo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class enviarEmailController : ControllerBase
    {
        private string conection = @"Server=localhost; Database=corp_capsula; Uid=root;";

        [HttpPost]
        public ActionResult Insert(models.emailStruct models)
        {
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUserEnvia", models.idUserEnvia);
                cmd.Parameters.AddWithValue("@idUserRecibe", models.idUserRecibe);
                cmd.Parameters.AddWithValue("@asuntEnvia", models.asuntEnvia);
                cmd.Parameters.AddWithValue("@correoCuerpo", models.correoCuerpo);


                cmd.CommandText = "spNewCorreoeEnvia";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);

        }/*
        [HttpPut]
        public ActionResult Update(models.UpdateProveedor models)
        {
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razon_socialParam", models.razon_socialParam);
                cmd.Parameters.AddWithValue("@dominio_emailParam", models.dominio_emailParam);
                cmd.Parameters.AddWithValue("@nitParam", models.nitParam);
                cmd.Parameters.AddWithValue("@telefonoParam", models.telefonoParam);
                cmd.Parameters.AddWithValue("@direccionParam", models.direccionParam);
                cmd.Parameters.AddWithValue("@id_prove", models.id_proveedor);
                cmd.CommandText = "updateProveedor";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);

        }
        [HttpDelete]
        public ActionResult Delete(models.DeleteProveedor models)
        {
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProve", models.idProve);
                cmd.CommandText = "spDeleteProveedor";
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return Ok(result);

        }
        //metodo de get para consulta con parametros
        [HttpGet]
        //accion de metodo
        public ActionResult Get(models.SelectProveedor modelsView)
        {

            //objeto vacio
            responseListProveedor[] allRecords = null;
            //strin de respuesta

            using (var db = new MySqlConnection(conection))
            {
                //Inicializando el query
                MySqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProve", modelsView.idProve);
                if (modelsView.tipo == 0)
                {
                    cmd.CommandText = "spConsultProveedor";

                }
                else
                {
                    cmd.CommandText = "spAllProveedores";

                }
                db.Open();
                //Ejecutando el query
                using (var reader = cmd.ExecuteReader())
                {
                    var list = new List<responseListProveedor>();
                    while (reader.Read())
                        list.Add(new responseListProveedor
                        {
                            id_proveedor = reader.GetInt64(0),
                            razon_social = reader.GetString(1),
                            dominio_email = reader.GetString(2),
                            nit = reader.GetString(3),
                            telefono = reader.GetString(4),
                            direccion = reader.GetString(5),
                            fecha_creacion = reader.GetString(6)

                        });
                    allRecords = list.ToArray();
                }

            };
            return Ok(allRecords);
        }*/
    }
}