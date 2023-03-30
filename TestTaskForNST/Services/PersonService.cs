using Microsoft.EntityFrameworkCore;
using TestTaskForNST.Models;

namespace TestTaskForNST.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationContext _context;

        public PersonService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Person> Create(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> Delete(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                throw new ArgumentNullException("Пользователь не найден");
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Person>> GetAllPerson()
        {
            return await _context.People.Include(x => x.Skills).AsNoTracking().ToListAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.People.Include(x => x.Skills).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                throw new ArgumentNullException("Пользователь не найден");
            }
            return person;
        }

        public async Task<bool> Update(int id, Person person)
        {
            var findPerson = await _context.People.Include(x => x.Skills).FirstOrDefaultAsync(p => p.Id == id);
            if (findPerson == null)
            {
                throw new ArgumentNullException("Пользователь не найден");
            }

            findPerson.Name = person.Name;
            findPerson.DisplayName = person.DisplayName;
            var skills = findPerson.Skills;
            findPerson.Skills = person.Skills;
            await Task.Run(() => _context.Skills.RemoveRange(skills));
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
