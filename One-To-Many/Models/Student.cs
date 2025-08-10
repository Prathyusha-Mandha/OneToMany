using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_To_Many.Models
{
    public class Student
    {
        [Key]
        public int StuId { get; set; }

        public string? StuName { get; set; }


        public ICollection<Mark> Marks { get; set; }
        
    }
}
