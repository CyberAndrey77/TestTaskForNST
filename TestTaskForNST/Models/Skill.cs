using System.ComponentModel.DataAnnotations;

namespace TestTaskForNST.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1, 10, ErrorMessage = "Значение должно быть 1 - 10")]
        public byte Level { get; set; }
    }
}
