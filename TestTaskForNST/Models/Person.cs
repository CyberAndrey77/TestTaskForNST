using System.ComponentModel.DataAnnotations;

namespace TestTaskForNST.Models
{
    public class Person
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
