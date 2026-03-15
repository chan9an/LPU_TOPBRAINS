using System.ComponentModel.DataAnnotations;

namespace StudentMngSystem14_03_26.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
