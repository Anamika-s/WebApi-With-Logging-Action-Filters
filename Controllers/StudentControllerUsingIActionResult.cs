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
    public class Student1Controller : ControllerBase
    {
        static List<Student> students = null;
        public Student1Controller()
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
        public IActionResult Get()
        {

            if (students==null) 
                return NotFound();
            else 
            return Ok(students);
        }
        [HttpGet]

        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
           var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound("Student with this ID not found");
            else
                return Ok(student);
                    }  


        [HttpPost]
        public IActionResult Create(Student student)
        {
            students.Add(student);
            return Created("Record has been inserted",
student);        }
     

      [HttpPut]
    [Route("{id:int}")]

    public IActionResult Edit(int id, Student student)
    {
        var obj = students.FirstOrDefault(x => x.Id == id);
        if (obj == null)
        
                return NotFound("Stduer not found");
                else
                    return Ok("Record has been edited");
        }
   
    [HttpDelete]
    [Route("{id:int}")]

    public IActionResult Delete(int id )
    {
        var obj = students.FirstOrDefault(x => x.Id == id);
            if (obj == null)

                return NotFound("Stduer not found");
            else
            {
                students.Remove(obj);
                return Ok("Record has been deleted");
            }
    }
}

}