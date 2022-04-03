using Microsoft.EntityFrameworkCore;
using PersonRepository.Model;

namespace PersonRepository.DataAccess;

public static class StudentQueryableExtension
{
    public static IQueryable<Student> WithAllNavigationProperty(this IQueryable<Student> persons)
        => persons.WithAllPersonNavigationProperty().Include(p => p.FollowedCourses);
}
