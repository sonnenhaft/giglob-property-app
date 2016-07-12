using System;
using System.Web.Http;

namespace Client.Api.v1
{
    public class HomeController: ApiController
    {
        [HttpGet]
        public IHttpActionResult Test()
        {
            throw new Exception("test");
        }
    }
}