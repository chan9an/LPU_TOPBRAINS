using System.ComponentModel.DataAnnotations;

namespace StudentMngSystem14_03_26.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string Description {  get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Student> Students {  get; set; }

    }
}
