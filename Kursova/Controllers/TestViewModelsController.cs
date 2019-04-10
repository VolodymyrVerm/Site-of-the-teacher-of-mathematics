using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursova.Models;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Identity;


namespace Kursova.Controllers
{
    public class TestViewModelsController : Controller
    {
        public ApplicationDBContext _context;
        public  UserManager<User> _us;


        public TestViewModelsController(ApplicationDBContext context, UserManager<User> us)
        {
            _context = context;
            _us = us;
        }

        // GET: TestViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tests.ToListAsync());
        }

        public async Task<IActionResult> Tests()
        {
            return View(await _context.Tests.ToListAsync());
        }

        public ActionResult ShowQuestion(int id)

        {
            //if(_context.TestsProgress.Where(i=>i.TestId==id).Where(y=>y.UserId==_us.GetUserId(User)).First==true)
            //{

            //}
            return View(_context.Tests.Include(i => i.ListOfQuestion).Where(item => item.Id == id).First());
        }

        
        public ActionResult SetProgressTest(int id)
        {
            var a = _context.Tests.Find(id);
            TestProgress tp = new TestProgress { Completed = true, Test = _context.Tests.Find(id), IdentityUserId = _us.GetUserId(User) };
            _context.TestsProgress.Add(tp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Tests));
        }

        // GET: TestViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testViewModel = await _context.Tests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testViewModel == null)
            {
                return NotFound();
            }

            return View(testViewModel);
        }

        [HttpGet]
        public ActionResult ViewList(int id)
        {
            //var y = _context.Tests.Find(135).Name;
           // var t = _context.Tasks.Find(130).Test;
            var r =  _context.Tests.Include(i=>i.ListOfQuestion);
            //_context.Update(r);
            //var y=_context.Tasks.Find()

            //foreach (var item in r)
            //{
            //    var t = item;
            //}
            return View(_context.Tests.Include(i => i.ListOfQuestion).Where(item=>item.Id==id).First().ListOfQuestion);
        }

        [HttpGet]
        public IActionResult AddQuestion(int? Id)
        {
            var res=_context.Tests.Find(Id);
            
            return View(res);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public  void AddQuestion(string question,string answer,int id)
        {
            TaskViewModel t = new TaskViewModel { Question = question, Answer = answer, TestViewModelId=id,Test=_context.Tests.Find(id)};
           // _context.Entry(t).State = EntityState.Modified;

            _context.Tasks.Add(t);
            var r = _context.Tests.Find(id);
           // _context.Tests.Find(id).ListOfQuestion.Add(t);
             _context.SaveChanges();
            // var r = _context.Tasks.Last();
            //_context.Tests.Find(id).ListOfQuestion.Add(r);
            //_context.SaveChanges();
            //if (ModelState.IsValid)
            //{
            //   // _context.Tests.Find(id).ListOfQuestion=new List<TaskViewModel>();
                
            //    //_context.Tests.Find(id).ListOfQuestion.Add(t);
                
            //    //_context.Tasks.Last().Test = _context.Tests.Find(id);
            //    //var r = _context.Tasks.Last();

            //    //List<TaskViewModel> l = new List<TaskViewModel>();
            //    // l.Add(t);
            //    //_context.Tests.Find(id).ListOfQuestion.Add(r);
            //   // _context.Tests.Find(id).ListOfQuestion.Add(t);
            //    //_context.Add(taskViewModel);
            //    // await _context.SaveChangesAsync();
            //    // _context.Tests.Find(id).ListOfQuestion.Add(t);
            //    //x.ListOfQuestion.Add(t);
            //     //_context.SaveChanges();
            //   // return RedirectToAction(nameof(Index));
            //}
           // return RedirectToAction(nameof(Index));
        }

        // GET: TestViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountQuestion")] TestViewModel testViewModel)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(testViewModel);
                await _context.SaveChangesAsync();
                var a = testViewModel;
                return RedirectToAction("AddQuestion", "TestViewModels",new { a.Id } );
                //return RedirectToAction(nameof(AddQuestion(testViewModel)));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TestViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testViewModel = await _context.Tests.FindAsync(id);
            if (testViewModel == null)
            {
                return NotFound();
            }
            return View(testViewModel);
        }

        // POST: TestViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountQuestion")] TestViewModel testViewModel)
        {
            if (id != testViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestViewModelExists(testViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testViewModel);
        }

        // GET: TestViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testViewModel = await _context.Tests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testViewModel == null)
            {
                return NotFound();
            }

            return View(testViewModel);
        }

        // POST: TestViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testViewModel = await _context.Tests.FindAsync(id);
            _context.Tests.Remove(testViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestViewModelExists(int id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }
    }
}
