﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请输入姓名"), MaxLength(50, ErrorMessage = "最长50")]
        public string Name { get; set; }
        [Required]
        public ClassName? ClassNeme { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
    }
}
