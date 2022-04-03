using Microsoft.EntityFrameworkCore;
using PersonRepository.Model;

namespace PersonRepository.DataAccess;

public static class PersonQueryableExtension
{
    public static IQueryable<TPerson> WithAllPersonNavigationProperty<TPerson>(this IQueryable<TPerson> persons) where TPerson : Person
        => persons.Include(p => p.Birthday);

    public static IQueryable<TPerson> WithAllNavigationProperty<TPerson>(this IQueryable<TPerson> persons) where TPerson : Person
    {
        return persons switch
        {
            IQueryable<Student> => (IQueryable<TPerson>)((IQueryable<Student>)persons).WithAllNavigationProperty(),
            IQueryable<Teacher> => (IQueryable<TPerson>)((IQueryable<Teacher>)persons).WithAllNavigationProperty(),
            _ => throw new NotImplementedException(),
        };
    }
}
