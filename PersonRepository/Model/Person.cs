namespace PersonRepository.Model;

public abstract class Person
{
    protected Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Date? Birthday { get; set; }
    public Gender Gender { get; set; }
}
