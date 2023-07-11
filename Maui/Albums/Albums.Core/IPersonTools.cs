namespace Albums.Core;

public interface IPersonTools : IDataItemTools<Person>
{
  Person CreatePerson(string firstName, string lastName);
}