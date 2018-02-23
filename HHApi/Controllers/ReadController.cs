using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HHApi.Models;

using HHApi.Service;

using Swashbuckle.Swagger.Annotations;

namespace HHApi.Controllers
{
    public class ReadController : ApiController
    {

        // GET: api/Read
        [SwaggerOperation("GetAll")]
        public IEnumerable<Product> Get()
        {
            return new AzureTableRetrieve().GetAll() as List<Product>;
        }

        // GET: api/Read/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public Product Get(int id)
        {
            return new Product(id, "", 0.00m) ;
        }
                
    }
}
