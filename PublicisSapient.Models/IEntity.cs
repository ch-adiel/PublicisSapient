using System.ComponentModel.DataAnnotations;

namespace PublicisSapient.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
    }

    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
