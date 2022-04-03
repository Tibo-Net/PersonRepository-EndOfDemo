namespace PersonRepository.Model;

public class Course
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Course() { } // Required by EF
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Course(string designation, Teacher teacher)
    {
        Designation = designation;
        Teacher = teacher;
    }

    public int Id { get; set; }
    public string Designation { get; set; }
    public Teacher Teacher { get; set; }
    public ICollection<Student>? Students { get; set; }
}
