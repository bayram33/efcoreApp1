using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class StudentController : Controller
    {

        private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var student =await  _context.Students.ToListAsync();
            return View(student);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Student");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            //var ogr = await _context.Students.FindAsync(id);
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);

            if(student == null)
            {
                return NotFound();
            }

            return View(student); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit ( int id , Student model)
        {

            if(id != model.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _context.Update(model);
                   await  _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index", "Student");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var ogr = await _context.Students.FindAsync(id);
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var std= await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            if (std == null)
            {
                return NotFound();
            }
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Student");
        }



    }
}
