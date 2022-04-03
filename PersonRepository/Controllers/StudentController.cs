using Microsoft.AspNetCore.Mvc;
using PersonRepository.DataAccess;
using PersonRepository.Model;

namespace PersonRepository.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StudentController : PersonController<Student>
{
    public StudentController(AppDbContext dbContext) : base(dbContext) { }

    [HttpPost]
    public ActionResult<Student> AddClass(int id, int courseId)
    {
        var existingStudent = DbContext.Students.SingleOrDefault(x => x.Id == id);
        if (existingStudent == null)
        {
            return NotFound(nameof(Student));
        }
        var existingCourse = DbContext.Courses.FirstOrDefault(x => x.Id == courseId);
        if (existingCourse == null)
        {
            return NotFound(nameof(Course));
        }
        if (existingStudent.FollowedCourses == null)
        {
            existingStudent.FollowedCourses = new List<Course>();
        }
        if (existingStudent.FollowedCourses.Any(x => x.Id == courseId))
        {
            return BadRequest();
        }
        existingStudent.FollowedCourses.Add(existingCourse);
        DbContext.SaveChanges();
        return Ok(existingStudent);
    }
}
