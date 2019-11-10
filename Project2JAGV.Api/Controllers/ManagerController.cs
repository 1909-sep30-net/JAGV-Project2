using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project2JAGV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        // GET: api/Manager
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/Manager/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
