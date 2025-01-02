using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class CourseRecordController(DataContext context) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var allRecord = await context.CoursesRecord
                .Include(x => x.Student)
                .Include(x => x.Course)
                .ToListAsync();
            return View(allRecord);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await context.Students.ToListAsync(), "StudentId", "StudentNameLastName");
            ViewBag.Courses = new SelectList(await context.Courses.ToListAsync(), "CourseId", "CourseTitle");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseRecord model)
        {
            model.RecordDate = DateTime.Now;
            await context.CoursesRecord.AddAsync(model);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "CourseRecord");
        }

    }
}
