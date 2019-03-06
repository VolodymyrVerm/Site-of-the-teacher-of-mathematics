using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kursova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestApiController : ControllerBase
    {
        [Route("Validate")]
        public string validate_answer(string answer,string id)
        {
            return "dvsav";
        }
    }
}