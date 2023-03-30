using TestTaskForNST.Models;

namespace TestTaskForNST.Services
{
    public interface IPersonService
    {
        Task<Person> Create(Person person);
        Task<bool> Update(int id, Person person);
        Task<bool> Delete(int id);
        Task<Person> GetPerson(int id);
        Task<List<Person>> GetAllPerson();
    }
}
