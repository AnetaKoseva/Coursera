namespace CourseraCoderByte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students_Courses_xref
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Student_pin { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Course_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Completion_date { get; set; }

        public virtual Cours Cours { get; set; }

        public virtual Student Student { get; set; }
    }
}
