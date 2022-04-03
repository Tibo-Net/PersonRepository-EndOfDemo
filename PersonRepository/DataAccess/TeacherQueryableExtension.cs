using Microsoft.EntityFrameworkCore;
using PersonRepository.Model;

namespace PersonRepository.DataAccess;

public static class TeacherQueryableExtension
{
    public static IQueryable<Teacher> WithAllNavigationProperty(this IQueryable<Teacher> persons)
        => persons.WithAllPersonNavigationProperty();
}