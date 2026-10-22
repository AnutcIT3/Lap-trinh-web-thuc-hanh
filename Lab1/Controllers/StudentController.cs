using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController() {
            listStudents = new List<Student>()
            {
                new Student(){ Id = 101, Name = "Hải Nam", Email = "nam@g.com", Address = "A1-2018",
                               Branch = Branch.IT, Gender = Gender.Male, IsRegular = true},
                new Student(){ Id = 102, Name = "Minh Tú", Email = "tu@g.com", Address = "A1-2019",
                               Branch = Branch.BE, Gender = Gender.Female, IsRegular = true},
                new Student(){ Id = 103, Name = "Hoàng Phong", Email = "phong@g.com", Address = "A2-2020",
                               Branch = Branch.CE, Gender = Gender.Male, IsRegular = false},
                new Student(){ Id = 101, Name = "Xuân Mai", Email = "mai@g.com", Address = "A1-2021",
                               Branch = Branch.EE, Gender = Gender.Female, IsRegular = false},
            };      
        }

        [Route("Admin/Student/List", Name = "StudentList")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        [Route("Admin/Student/Add", Name = "StudentAdd")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem {Text = "IT",Value = "1"},
                new SelectListItem {Text = "BE",Value="2"},
                new SelectListItem {Text = "CE",Value="3"},
                new SelectListItem {Text = "EE",Value="4"},

            };
            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add")]
        public IActionResult Create(Student student)
        {
            student.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(student);
            return View("Index", listStudents);
        }
    }
}
