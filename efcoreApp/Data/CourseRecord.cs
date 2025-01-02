﻿using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class CourseRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public DateTime RecordDate { get; set; }
    }
}
