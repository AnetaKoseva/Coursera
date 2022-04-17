namespace CourseraCoderByte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;  

    public class Program
    {
        static void Main(string[] args)
        {
            var db = new Model1();
            var studentsPINInput = Console.ReadLine().Split(',').ToArray();

            var students = db.Students
                .Where(s => studentsPINInput.Contains(s.Pin))
                .Select(s => new
                {
                    Student = s.First_name + " " + s.Last_name,
                    Courses = s.Students_Courses_xref.Select(sc => new
                    {
                        CourseName = sc.Cours.Name,
                        Instructor = sc.Cours.Instructor,
                        Time = sc.Cours.Total_time,
                        Credit = sc.Cours.Credit

                    }),
                    TotalCredit = s.Students_Courses_xref.Sum(x => x.Cours.Credit)

                }).ToList();

            SaveToCsv(students, Directory.GetCurrentDirectory());
        }

        private static void SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();

            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);

            File.WriteAllLines(path, lines.ToArray());
        }
    }
}
