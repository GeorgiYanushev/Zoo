using System.ComponentModel.DataAnnotations;

namespace ZooDB.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public byte[] Picture { get; set; }

        public string Bio { get; set; }

        public Animal(string name, int age, string species, byte[] picture, string bio)
        {
            Name = name;
            Age = age;
            Species = species;
            Picture = picture;
            Bio = bio;
        }
        public Animal()
        {

        }
    }
}
