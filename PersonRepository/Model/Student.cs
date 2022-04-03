namespace PersonRepository.Model;

public class Student : Person
{
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public ICollection<Course>? FollowedCourses { get; set; }
}
