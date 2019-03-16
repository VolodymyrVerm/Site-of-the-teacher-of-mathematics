using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kursova.ViewModels;
using Kursova.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel;
using System.Security.Claims;


namespace Kursova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestApiController : ControllerBase
    {

        ApplicationDBContext db;
        UserManager<User> us;
        public TestApiController(ApplicationDBContext context,UserManager<User> _us)
        {
            db = context;
            us = _us;
        }

        [HttpGet]
        [Route("SetAnswer")]
        public void SetAnswer(string answer,string id)
        {


            var t=us.GetUserId(User);
            UserResponseViewModel res = new UserResponseViewModel { UserId = t, QuestionId = id, AnswerUser = answer };
            db.Answers.Add(res);
            db.SaveChanges();



            //var task = db.Tasks.Find(int.Parse(id));
            //if (answer == task.Answer)
            //{
            //    return JsonConvert.SerializeObject(task);
            //}
            //throw new ArgumentException();
         
        }

        [HttpGet]
        [Route("GetAnswer")]
        public string GetAnswer()
        {
            var t = us.GetUserId(User);
       
            var ress=db.Answers.Where(i => i.UserId == t);
            var res = db.Tasks.Where(i => !ress.Any(k => k.QuestionId == i.Id.ToString()));
            //var res = db.Tasks.Where(i => !db.Answers.Find(t));
          //  return res;
            return JsonConvert.SerializeObject(res);


        }
    }
}