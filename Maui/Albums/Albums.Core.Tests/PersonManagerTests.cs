using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core.Tests;

[TestFixture]
public class PersonManagerTests : HttpClientTestsBase
{
  [Test]
  public async Task TestGetAll()
  {
    var provider = CreateProvider();
    var manager = provider.GetRequiredService<IPersonManager>();

    var persons = (await manager.GetAll()).ToList();

    Assert.That(persons.Count, Is.EqualTo(2));
  }

  [Test]
  public async Task TestAdd()
  {
    var provider = CreateProvider();
    var manager = provider.GetRequiredService<IPersonManager>();

    var newPerson = await manager.Add(new Person { Name = "Dark Side of the Moon", Id = 16 });

    try
    {
      Assert.That(newPerson.Name, Is.EqualTo("Dark Side of the Moon"));

      var darkSideOfTheMoon = (await manager.GetAll()).FirstOrDefault(a => a.Name == "Dark Side of the Moon");

      Assert.That(darkSideOfTheMoon, Is.Not.Null);
    }
    finally
    {
      await manager.Delete(newPerson.Id);
    }
  }

  [Test]
  public async Task TestUpdate()
  {
    var provider = CreateProvider();
    var manager = provider.GetRequiredService<IPersonManager>();

    var newPerson = await manager.Add(new Person { Name = "Dark Side of the Moon", Id = 16 });

    try
    {
      Assert.That(newPerson.Name, Is.EqualTo("Dark Side of the Moon"));

      var darkSideOfTheMoon = (await manager.GetAll()).FirstOrDefault(a => a.Name == "Dark Side of the Moon");

      Assert.That(darkSideOfTheMoon, Is.Not.Null);

      newPerson.Name = "Wish You Were Here";

      await manager.Update(newPerson);

      var wishYouWereHere = (await manager.GetAll()).FirstOrDefault(a => a.Name == "Wish You Were Here");

      Assert.That(wishYouWereHere, Is.Not.Null);
    }
    finally
    {
      await manager.Delete(newPerson.Id);
    }
  }
}