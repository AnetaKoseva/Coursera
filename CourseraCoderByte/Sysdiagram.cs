namespace CourseraCoderByte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sysdiagram
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int Principal_id { get; set; }

        [Key]
        public int Diagram_id { get; set; }

        public int? Version { get; set; }

        public byte[] Definition { get; set; }
    }
}
