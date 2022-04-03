using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonRepository.DataAccess;
using PersonRepository.Model;

namespace PersonRepository.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public abstract class PersonController<TPerson> : ControllerBase where TPerson : Person
{
    protected AppDbContext DbContext { get; private set; }

    protected PersonController(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<TPerson> Add(TPerson person)
    {
        DbContext.Add(person);
        DbContext.SaveChanges();
        return Ok(person);
    }

    [HttpGet]
    public ActionResult<IEnumerable<TPerson>> All()
    {
        return Ok(DbContext.Set<TPerson>().WithAllNavigationProperty().ToList());
    }

    [HttpGet]
    public ActionResult<Person?> Get(int id) => DbContext.Set<TPerson>().WithAllNavigationProperty().FirstOrDefault(p => p.Id == id);

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var person = DbContext.Set<TPerson>().FirstOrDefault(x => x.Id == id);
        if (person == null)
        {
            return NotFound();
        }
        DbContext.Set<TPerson>().Remove(person);
        DbContext.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult<TPerson> Update(TPerson person)
    {
        var existing = DbContext.Set<TPerson>().WithAllNavigationProperty().FirstOrDefault(x => x.Id == person.Id);
        if (existing == null)
        {
            return NotFound();
        }
        existing.FirstName = person.FirstName;
        existing.LastName = person.LastName;
        existing.Birthday = person.Birthday;

        DbContext.SaveChanges();
        return Ok(existing);
    }
}
