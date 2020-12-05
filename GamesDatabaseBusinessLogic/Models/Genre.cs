using System.ComponentModel.DataAnnotations;

namespace GamesDatabaseBusinessLogic.Models
{
    public class Genre
    {
        [Key]
        public decimal Key {get; set;}
        public string Name { get; set; }
    }
}