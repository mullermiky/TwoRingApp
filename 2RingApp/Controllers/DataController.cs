using System;
using System.Collections.Generic;
using System.Linq;
using _2RingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace _2RingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    [EnableCors("AllowMyOrigin")]
    public class DataController : ControllerBase
    {

        private readonly DW_testContext _db;

        public DataController(DW_testContext db)
        {
            _db = db;
        }

        //GET: api/Data
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SpGetData>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(DateTime from, DateTime to, [FromQuery(Name = "ids")]string[] names)
        {


            try
            {
                var fromDate = new SqlParameter("from", from);
                var toDate = new SqlParameter("to", to);
                var queues = new SqlParameter("queues", string.Join(",", names));


                var data = _db.SpGetData.FromSql("EXEC [dbo].[ComputeData] @from, @to, @queues", fromDate, toDate, queues).ToList();

                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

           

            
        }

        
    }
}
