using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;


using HHApi.Models;
using HHApi.Service;
using System.Threading.Tasks;

namespace HHApi.Controllers
{

    
    public class WriteController : ApiController
    {

        // GET: api/Write
        [HttpGet]
        public string Get()
        {
            return "In the Write Controller";
        }

        // POST: api/Write
        [HttpPost]
        public IHttpActionResult Post([FromBody]Product value)
        {
            new AzureTablePersist().Save(value);

            return Ok(value.Id);
        }

        // POST: api/Write
    //    [HttpPost]
    //    [ActionName("Raw")]
    //    public IHttpActionResult Raw([FromBody]string value)
    //    {
            
    //        new AzureTablePersist().Save(Request.Content.ReadAsStringAsync());

    //        return Ok();
    //    }

    }
}
