using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Dept Dept { get; set; }
        
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        public int Batch { get; set; }
        public Student()
        {
            
        }

        public Student(int id, string name, Dept dept, string email, int batch)
        {
            this.Id = id;
            this.Name = name;
            this.Dept = dept;
            this.Email = email;
            this.Batch = batch;
        }
    }
}