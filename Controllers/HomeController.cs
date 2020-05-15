using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    //[Route("Home")]
    public class HomeController : Controller
    {
        private readonly IstudentRespository _studentRespository;
        public HomeController(IstudentRespository istudentRespository)
        {
            _studentRespository = istudentRespository;
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
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student news = _studentRespository.Add(student);
              //  return RedirectToAction("Details", new { id = news.Id });//重定向
            }
            return View();
        }
    }
}