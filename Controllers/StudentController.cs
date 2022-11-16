using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi__Demo.Models;

namespace WebApi__Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomActionFilter))]
    public class StudentController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StudentController));
        private ILogger _logger;
         
        static List<Student> students = null;

        public StudentController(ILogger<StudentController> logger)

        {
            _logger = logger;
            
            //if (students == null)
            //{
            //    students = new List<Student>()
            //    {
            //        new Student(){ Id=1, Name="Aashna", BatchCode="DotNet", Marks=90},

            //        new Student(){ Id=2, Name="Priynaka", BatchCode="DotNet", Marks=87},
            //        new Student(){ Id=3, Name="Tisha", BatchCode="SAP", Marks=98},
            //        new Student(){ Id=4, Name="Naveen", BatchCode="SAP", Marks=90},
            //        new Student(){ Id=5, Name="Siddhant", BatchCode="DotNet", Marks=90},
            //        new Student(){ Id=6, Name="Vaibhav", BatchCode="DotNet", Marks=90},
            //    };
            //}

        }
        // specific type
        [HttpGet]
        public List<Student> Get()
        {
            _log4net.Info("Inside Get Method");
            _logger.LogInformation("We are inside Get Method");
            if (students==null)
                _logger.LogCritical("Pl add some records");
            return students;
        }
        [Route("{id:int}")]
        [HttpGet]
        
        public Student Get(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Create(Student student)
        {

            _log4net.Info("Inside Post Method");
            _logger.LogInformation("We are inside Post Method");
            students.Add(student);
        }
    }
}