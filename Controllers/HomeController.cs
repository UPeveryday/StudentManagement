using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    //[Route("Home")]
    public class HomeController : Controller
    {
        private readonly IstudentRespository _studentRespository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IstudentRespository istudentRespository, IHostingEnvironment hosting)
        {
            _studentRespository = istudentRespository;
            _hostingEnvironment = hosting;
        }
        //[Route("")]
        //[Route("Index")]//属性路由
        //[Route("~/")]
        public IActionResult Index()
        {
            return View(_studentRespository.GetStudents());
        }
        //[Route("Details/{id?}")]//属性路由
        public IActionResult Details(int id = 1)
        {
            Student model = _studentRespository.GetStudent(id);

            ViewModels.HomeDetailsViewModel homeDetailsViewModel = new ViewModels.HomeDetailsViewModel()
            {
                Student = model,
                PageTitle = "学生详细信息"
            };
            //ViewData["PageTitle"] = "Student Details";//viewdata运行时动态解析,弱类型
            //ViewData["Student"] = model;

            //ViewBag.PageTitle = "学习详情";//本身是动态类型 弱类型
            //ViewBag.Student = model;
            //  return View();

            return View(homeDetailsViewModel);//相对路径不需要扩展名  根路径"~/MyViews/Test.cshtml"
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public RedirectToActionResult Create(Student student)
        //{

        //    Student news = _studentRespository.Add(student);
        //    return RedirectToAction("Details", new { id = news.Id });//重定向
        //}
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel student)
        {
            string uniqueFilename = string.Empty;
            if (ModelState.IsValid)
            {
                if (student.PhotoPath != null)
                {
                    string upfoler = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + student.PhotoPath.FileName;
                    string filepath = Path.Combine(upfoler, uniqueFilename);
                    student.PhotoPath.CopyTo(new FileStream(filepath, FileMode.Create));


                }
                //Student news = _studentRespository.Add(student);
                //  return RedirectToAction("Details", new { id = news.Id });//重定向
            }

            Student newstu = new Student
            {
                Name = student.Name,
                ClassNeme = student.ClassNeme,
                Email = student.Email,
                PhotoPath = uniqueFilename
            };
            _studentRespository.Add(newstu);
            return RedirectToAction("Details", new { id = newstu.Id });//重定向
        }
    }
}