using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        //DTO 视图数据传输者
        public Student Student { get; set; }
        public string PageTitle { get; set; }
    }
}
