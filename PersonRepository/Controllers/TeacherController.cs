using Microsoft.AspNetCore.Mvc;
using PersonRepository.DataAccess;
using PersonRepository.Model;

namespace PersonRepository.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TeacherController : PersonController<Student>
{
    public TeacherController(AppDbContext dbContext) : base(dbContext) { }
}
