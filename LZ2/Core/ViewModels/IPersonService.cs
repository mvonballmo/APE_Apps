using Core.Models;

namespace Core;

public interface IPersonService
{
    Task Save(Person person);

    Task<IList<Person>> LoadAll();
}