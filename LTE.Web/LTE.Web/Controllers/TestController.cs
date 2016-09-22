using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LTE.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        
        [Route("GetMessage")]
        public string GetMessage()
        {
            return "Success.";
        }
    }
}
