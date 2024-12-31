using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class StudentController : Controller
    {

        private DataContext _context;
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
    }
}
