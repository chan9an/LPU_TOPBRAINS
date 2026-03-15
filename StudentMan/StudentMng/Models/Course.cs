using System.ComponentModel.DataAnnotations;

namespace StudentMngSystem14_03_26.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Fees { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
