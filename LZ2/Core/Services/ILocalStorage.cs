using Core.Models;

namespace Core.Services;

public interface ILocalStorage
{
    // TODO Make the interface generic rather than Person-specifics
    // TODO Add documentation

    Task<Person?> TryLoad(int id);

    Task<bool> Save(Person person);

    Task<bool> Delete(Person person);

    Task<List<Person>> LoadAll();

    Task<bool> DeleteAll();
    Task Initialize();
}