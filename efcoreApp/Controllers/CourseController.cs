using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class CourseController(DataContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await context.Courses.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            await context.Courses.AddAsync(model);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Course");
        }


        [HttpGet]
        public async Task<IActionResult> Edit (int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var result = await context.Courses.FirstOrDefaultAsync(m => m.CourseId == id);

            if (result == null)
            {
                return NotFound(); 
            }

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Edit (int ? id , Course model)
        {
            if(id != model.CourseId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(model);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index", "Course");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete (int ? id)
        {
            var course = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int  id)
        {
            var course = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            if(course == null)
            {
                return NotFound();
            }
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Course");
        }

    }
}
 