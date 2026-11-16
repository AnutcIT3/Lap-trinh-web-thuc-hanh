using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;
        public LearnerController(SchoolContext context) {
            db = context;
        }
        public IActionResult Create()
        {
            var majors = new List<SelectListItem>();
            foreach (var item in db.Majors) {
                majors.Add(new SelectListItem { Text = item.MajorName,
                       Value = item.MajorID.ToString() });
            }
            ViewBag.MajorsID = majors;
            ViewBag.MajorsID = new SelectList(db.Majors, "MajorID", "MaojorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Lại dùng 1 trong 2 cách tạo SelectList gửi về View để hiển thị danh sách Majors
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }
        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
    }
}
