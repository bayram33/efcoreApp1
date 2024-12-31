using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class CourseRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
