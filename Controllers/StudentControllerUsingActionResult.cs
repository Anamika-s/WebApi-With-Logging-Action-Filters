using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi__Demo.Models;

namespace WebApi__Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        static List<Student> students = null;
        public Student2Controller()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student(){ Id=1, Name="Aashna", BatchCode="DotNet", Marks=90},

                    new Student(){ Id=2, Name="Priynaka", BatchCode="DotNet", Marks=87},
                    new Student(){ Id=3, Name="Tisha", BatchCode="SAP", Marks=98},
                    new Student(){ Id=4, Name="Naveen", BatchCode="SAP", Marks=90},
                    new Student(){ Id=5, Name="Siddhant", BatchCode="DotNet", Marks=90},
                    new Student(){ Id=6, Name="Vaibhav", BatchCode="DotNet", Marks=90},
                };
            }

        }
        // IActionResult
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {

            if (students==null) 
                return NotFound();
            else 
            return students;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Student> Get(int id)
        {
           var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound("Student with this ID not found");
            else
                return student;
                    }  


        [HttpPost]
        public ActionResult Create(Student student)
        {
            students.Add(student);
            return Created("Record has been inserted",
student);        }
     

      [HttpPut]
    [Route("{id:int}")]

    public ActionResult<int> Edit(int id, Student student)
    {
        var obj = students.FirstOrDefault(x => x.Id == id);
            if (obj == null)

                return NotFound("Stduer not found");
            else
                return 2;
        }
   
    [HttpDelete]
    [Route("{id:int}")]

    public ActionResult<string> Delete(int id )
    {
        var obj = students.FirstOrDefault(x => x.Id == id);
            if (obj == null)

                return NotFound("Stduer not found");
            else
            {
                students.Remove(obj);
                return "Record has been deleted";
            }
    }
}

}