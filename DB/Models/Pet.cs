using System.ComponentModel.DataAnnotations;

namespace Pets.Models
{
    public class Pet
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Raza { get; set; }
        public int Age { get; set; }
        public string? OwnName { get; set; }

    }
}
