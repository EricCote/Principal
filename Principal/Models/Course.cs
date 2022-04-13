using System.ComponentModel.DataAnnotations;

namespace Principal.Models
{
    public class Course
    {

        public int CourseID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }

    }
}
