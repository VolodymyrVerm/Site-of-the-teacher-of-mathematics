using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kursova.ViewModels;
using Kursova.Models;
using Newtonsoft.Json;

namespace Kursova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestApiController : ControllerBase
    {

        ApplicationDBContext db;
        public TestApiController(ApplicationDBContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("Validate")]
        public string validate_answer(string answer,string id)
        {
            var task = db.Tasks.Find(int.Parse(id));
            if (answer == task.Answer)
            {
                return JsonConvert.SerializeObject(task);

            }
            throw new ArgumentException();
        }
    }
}