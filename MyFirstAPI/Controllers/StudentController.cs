using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Controllers
{
    [Route("api/student")]
    [ApiController]

    public class StudentController : ControllerBase
    {

        public readonly studentsContext _context;

        public StudentController(studentsContext context)
        {
            _context = context;
        }


        //Action
        [Route("GetStudents")]
        [HttpGet]

        public async Task<IActionResult> GetStudents()
        {

            try
            {
                var result = await _context.StudentsModel.ToListAsync();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }

            catch (Exception e)
            {
                return Unauthorized(e.StackTrace);
            }
        }

        [HttpGet]
        [Route("GetStudents/{id}")]

        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _context.StudentsModel.Where(w => w.Id == id).FirstOrDefaultAsync();


            return Ok(result);
        }

        //[HttpPost]
        //[Route("CreateNewStudent")]
        //public async Task<IActionResult> CreateNewStudent([FromBody] Student student)
        //{
        //await _context.StudentsModel.AddAsync(student);
        //await _context.SaveChangesAsync();
        //  return Ok(student);

        //}


        //[HttpDelete]
        //[Route("DeleteStudent/{id}")]

        //public async Task<IActionResult> DeleteStudent(int id)
        //{
        //  var student = await _context.StudentsModel.FindAsync(id);
        //if(student == null)
        //{
        //  return BadRequest("No Student with id" + id);
        //}
        //else
        //{
        //  _context.StudentsModel.Remove(student);
        //await _context.SaveChangesAsync();
        //return Ok("Delete Sucessfully");
        //}
        //}
        //}
    }
}
