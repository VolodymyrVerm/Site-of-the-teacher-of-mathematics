using Kursova.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    public class TestProgressController:Controller
    {
        public ApplicationDBContext _context;
        public UserManager<User> _us;


        public TestProgressController(ApplicationDBContext context, UserManager<User> us)
        {
            _context = context;
            _us = us;
        }
        public ActionResult ShowTestForResult()
        {
            return View(_context.Tests);
        }

        public ActionResult ShowResultForTest(int id)
        {
           
            return View(_context.Tests.Find(id));
        }

        public ActionResult ShowTestForBestResultInRegion()
        {
            return View(_context.Tests);
        }

        public ActionResult ShowResultForBestResultInRegion(int id)
        {
            return View(_context.Tests.Find(id));
        }

        public ActionResult ShowTestForBestResultOnRegion()
        {
            return View(_context.Tests);
        }

        public ActionResult ShowResultForBestResultOnRegion(int id)
        {
            return View(_context.Tests.Find(id));
        }

        public ActionResult PopularTests()
        {
           
            return View();
        }

        public ActionResult AveregeScore()
        {
            return View(_context.Tests);
        }

        public ActionResult ShowAveregeScore(int id)
        {
            return View(_context.Tests.Find(id));
        }

        public ActionResult RatingOfUsers()
        {
            return View();
        }

        public ActionResult AboutUsers()
        {
            return View();
        }
    }
}
