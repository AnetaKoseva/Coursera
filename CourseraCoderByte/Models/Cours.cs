namespace CourseraCoderByte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("courses")]
    public partial class Cours
    {
     
        public Cours()
        {
            Students_Courses_xref = new HashSet<Students_Courses_xref>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int Instructor_id { get; set; }

        public byte Total_time { get; set; }

        public byte Credit { get; set; }

        public DateTime Time_created { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<Students_Courses_xref> Students_Courses_xref { get; set; }
    }
}
