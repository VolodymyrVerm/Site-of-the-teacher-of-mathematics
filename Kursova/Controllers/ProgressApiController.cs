using Kursova.Models;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressApiController : ControllerBase
    {
        ApplicationDBContext db;
        UserManager<User> us;
        public ProgressApiController(ApplicationDBContext context, UserManager<User> _us)
        {
            db = context;
            us = _us;
        }

        [HttpGet]
        [Route("Results")]
        public string Results(int testId)
        {

            
                int res = 0;
                var user_list = db.Users.ToList();
                var question_list = db.Tests.Include(y => y.ListOfQuestion).Where(i => i.Id == testId).First().ListOfQuestion;
                foreach (var user in user_list)
                {
                    res = 0;
                    var ress = db.Answers.Where(i => i.UserId == user.Id).ToList();
                    foreach (var answ in ress)
                    {
                        foreach (var quest in question_list)
                        {
                            if (answ.TaskViewModelId == quest.Id && answ.AnswerUser == quest.Answer)
                            {
                                res += quest.Score;
                            }
                        }

                    }
                    var e = db.TestsProgress.Where(i => i.UserId == user.Id && i.TestId == testId);
                    foreach (var w in e)
                    {
                        w.Score = res;
                    }
                    db.SaveChangesAsync();

                }

            
            
            var reas = db.TestsProgress.Include(d => d.User).Include(t => t.Test).Where(i => i.TestId == testId);

            return JsonConvert.SerializeObject(reas);
            }
        
        [HttpGet]
        [Route("BestResultsInRegion")]
        public string BestResultsInRegion(int testId, string region)
        {

            int res = 0;
            var user_list = db.Users.ToList();
            var question_list = db.Tests.Include(y => y.ListOfQuestion).Where(i => i.Id == testId).First().ListOfQuestion;
            foreach (var user in user_list)
            {
                res = 0;
                var ress = db.Answers.Where(i => i.UserId == user.Id).ToList();
                foreach (var answ in ress)
                {
                    foreach (var quest in question_list)
                    {
                        if (answ.TaskViewModelId == quest.Id && answ.AnswerUser == quest.Answer)
                        {
                            res += quest.Score;
                        }
                    }

                }
                var e = db.TestsProgress.Where(i => i.UserId == user.Id && i.TestId == testId);
                foreach (var w in e)
                {
                    w.Score = res;
                }
                db.SaveChangesAsync();

            }



            var reas = db.TestsProgress.Include(d => d.User).Include(t => t.Test).Where(i => i.TestId == testId);
            var q = reas.Max(i => i.Score);
            var r = reas.Where(i => i.Score == q && i.User.Region == region);
            
            return JsonConvert.SerializeObject(r);
        }

        [HttpGet]
        [Route("BestResultsOnRegion")]
        public string BestResultsOnRegion(int testId)
        {

            int res = 0;
            var user_list = db.Users.ToList();
            var question_list = db.Tests.Include(y => y.ListOfQuestion).Where(i => i.Id == testId).First().ListOfQuestion;
            foreach (var user in user_list)
            {
                res = 0;
                var ress = db.Answers.Where(i => i.UserId == user.Id).ToList();
                foreach (var answ in ress)
                {
                    foreach (var quest in question_list)
                    {
                        if (answ.TaskViewModelId == quest.Id && answ.AnswerUser == quest.Answer)
                        {
                            res += quest.Score;
                        }
                    }

                }
                var e = db.TestsProgress.Where(i => i.UserId == user.Id && i.TestId == testId);
                foreach (var w in e)
                {
                    w.Score = res;
                }
                db.SaveChangesAsync();

            }



            var reas = db.TestsProgress.Include(d => d.User).Include(t => t.Test).Where(i => i.TestId == testId);
            var q = reas.Max(i => i.Score);
            var r = reas.Where(i => i.Score == q).OrderBy(c=>c.User.Region);

            return JsonConvert.SerializeObject(r);
        }

        [HttpGet]
        [Route("PopularTests")]
        public string PopularTests(string number)
        {
            int num = 1;
            if (number != null)
            {
                num = Int32.Parse(number);

            }
            db.TestsProgress.Include(u => u.User).Include(i => i.Test);
            var q = db.TestsProgress.Include(p => p.Test).OrderBy(i => i.Test.Name);
            int count = 0;
            var r = q.GroupBy(x => x.Test.Name);
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var i in r)
            {
                count = i.Count();
                dic.Add(i.First().Test.Name, i.Count());
            }
            var sort_dic = dic.OrderByDescending(i => i.Value);



            //return View(sort_dic.Take(num));
            return JsonConvert.SerializeObject(sort_dic.Take(num));
        }

        [HttpGet]
        [Route("AveregeScore")]
        public string AveregeScore(int testId, string _for,string to)
        {

            DateTime t1 = DateTime.Parse(_for);
            DateTime t2 = DateTime.Parse(to);


            int res = 0;
            var user_list = db.Users.ToList();
            var question_list = db.Tests.Include(y => y.ListOfQuestion).Where(i => i.Id == testId).First().ListOfQuestion;
            foreach (var user in user_list)
            {
                res = 0;
                var ress = db.Answers.Where(i => i.UserId == user.Id).ToList();
                foreach (var answ in ress)
                {
                    foreach (var quest in question_list)
                    {
                        if (answ.TaskViewModelId == quest.Id && answ.AnswerUser == quest.Answer)
                        {
                            res += quest.Score;
                        }
                    }

                }
                var e = db.TestsProgress.Where(i => i.UserId == user.Id && i.TestId == testId);
                foreach (var w in e)
                {
                    w.Score = res;
                }
                db.SaveChangesAsync();

            }



            var reas = db.TestsProgress.Include(d => d.User).Include(t => t.Test).Where(i => i.TestId == testId);

            double sum = 0;
            int count = 0;
            foreach(var i in reas)
            {
                if (i.DateTime > t1 && i.DateTime < t2)
                {
                    sum += i.Score;
                    count++;
                }
            }
            double averegeSum = sum / count;

            return JsonConvert.SerializeObject(averegeSum);
        }
    }
    }

