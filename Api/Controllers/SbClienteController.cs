using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SbClienteController : ControllerBase
    {
        private string connection = @"Data Source=LAPTOP-SPE2L9A9\SQLEXPRESS01; Initial Catalog=ProyectoEdutech; integrated security=True";
        [HttpGet]

        public IActionResult Get()
        {
            IEnumerable<Models.SbCliente> lst = null;
            using (var db = new SqlConnection(connection))
            {
                var sql = "select Codigo, Nombre, Numero, Email  from SbCliente ";

                lst = db.Query<Models.SbCliente>(sql);
            }
            return Ok(lst);

        }
        [HttpPost]
        
        public IActionResult Insert(Models.SbCliente model)
        {
            int result = 0;
            using (var db = new SqlConnection(connection))
            {
                var sql = "inserte into SbCliente (Codigo, Nombre, Numero, Email)" + " values(@Codigo, @Nombre, @Numero, @Email)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpPut]

        public IActionResult Edit(Models.SbCliente model)
        {
            int result = 0;
            using (var db = new SqlConnection(connection))
            {
                var sql = "Update SbCliente set Codio=@Codigo, Nombre=@Nombre, Numero=@Numero Email=@Email";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpDelete]

        public IActionResult Delete(Models.SbCliente model)
        {
            int result = 0;
                using (var db = new SqlConnection(connection))
            {
                var sql = "delete from SbCliente where Codigo=@Codigo";
                result = db.Execute(sql, model);
            }
            return Ok(result);
            
        }




    }
}
