using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStudentRepository _repository;

        public HomeController(ILogger<HomeController> logger, IStudentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            List<Student> tempStudents = new List<Student>();
            tempStudents = _repository.GetAll();
            return View(tempStudents);
        }
        public IActionResult StudentDetails(int id)
        {
            Student student = _repository.GetById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = _repository.Insert(student);
                return RedirectToAction("StudentDetails", new {id = newStudent.Id});
            }
            return View();
        }
        [HttpGet]
        public IActionResult StudentUpdate(int id)
        {
            Student student = _repository.GetById(id);
            StudentUpdateViewModel studentUpdateViewModel = new StudentUpdateViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Batch = student.Batch,
                Dept = student.Dept,
                Email = student.Email,
            };
            return View(studentUpdateViewModel);
        }
        [HttpPost]
        public IActionResult StudentUpdate(StudentUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _repository.GetById(model.Id);
                student.Name = model.Name;
                student.Email = model.Email;
                student.Batch = model.Batch;
                student.Dept = model.Dept;
                _repository.Update(student);
                return RedirectToAction("StudentDetails", new {id = student.Id});
            }
            return View();
        }

        public IActionResult StudentDelete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Students");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
