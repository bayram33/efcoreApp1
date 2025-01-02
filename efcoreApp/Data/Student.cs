using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentLastName { get; set; }
        public string? StudentNameLastName
        {
            get 
            { 
                return this.StudentName + " " + this.StudentLastName;
            }
        }
        public string? StudentEmail { get; set; }
        public string? StudentPhoneNumber { get; set; }


       

    }
}
