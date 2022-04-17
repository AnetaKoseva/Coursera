namespace CourseraCoderByte
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Students_Courses_xref> Students_Courses_xref { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Students_Courses_xref)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.Course_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Instructor)
                .HasForeignKey(e => e.Instructor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Pin)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Students_Courses_xref)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.Student_pin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students_Courses_xref>()
                .Property(e => e.Student_pin)
                .IsFixedLength();
        }
    }
}
