using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace apiRestCorreo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class conectController : ControllerBase
    {
        private string conection = @"Server=bwajkqhku6unxpau1riz-mysql.services.clever-cloud.com; Database=bwajkqhku6unxpau1riz; Uid=ufd0ibkz6bmalqof; Pwd=7koeQc4MmQxje5BCizTd";
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<models.dataUsser> lst = null;
            using (var db = new MySqlConnection(conection))
            {
                var sql = "CALL  spAllUser";
                lst = db.Query<models.dataUsser>(sql);
            }
            return Ok(lst);

        }
 
        [HttpPost]
        public ActionResult Insert(models.newUsuario models){
            int result = 0;
            using (var db = new MySqlConnection(conection))
            {
                var sql = "CALL newUserSys ?, ?, ?, ?, ?, ?, ?, ?";
                result = db.Execute(sql, models);
            }
            return Ok(result);

        }

    }
}
