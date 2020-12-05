using System.ComponentModel.DataAnnotations;

namespace GamesDatabaseBusinessLogic.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
