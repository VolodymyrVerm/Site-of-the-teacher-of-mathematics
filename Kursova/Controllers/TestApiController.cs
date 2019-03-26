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

         
        }

        [HttpGet]
        [Route("GetAnswer")]
        public string GetAnswer()
        {
            var t = us.GetUserId(User);
            
            var ress=db.Answers.Where(i => i.UserId == t);
            var res = db.Tasks.Where(i => !ress.Any(k => k.QuestionId == i.Id.ToString()));
            return JsonConvert.SerializeObject(res);


        }

        [HttpGet]
        [Route("ValidateAnswer")]
        public string ValidateAnswer()
        {
            
            int res = 0;
            var user_list = db.Users.ToList();
            var question_list = db.Tasks.ToList();
            foreach (var user in user_list)
            {
                res = 0;
                var ress = db.Answers.Where(i => i.UserId == user.Id).ToList();
                foreach(var answ in ress)
                {
                    foreach(var quest in question_list)
                    {
                        if(answ.QuestionId==quest.Id.ToString() && answ.AnswerUser==quest.Answer)
                        {
                            res++;
                        }
                    }
                    
                }
                db.Users.Find(user.Id).Score = res; ;
                db.SaveChanges();
               

            }
            return JsonConvert.SerializeObject(db.Users);
        }

    }
}