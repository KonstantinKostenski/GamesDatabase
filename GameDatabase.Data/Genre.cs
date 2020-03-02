using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Data
{
    public class Genre
    {
        [Key]
        public decimal Key {get; set;}
        public string Name { get; set; }
    }
}