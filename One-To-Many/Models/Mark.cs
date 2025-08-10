using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_To_Many.Models
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        public int StudentId { get; set; }

        public int English { get; set; }
        public int Maths { get; set; }
        public int Social { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
