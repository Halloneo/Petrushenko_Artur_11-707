using System;
using System.Linq;

namespace LinqToObj_62
{
    class Program
    {
        static void Main()
        {
            var students = Generator.GetStudents(100);

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = students
                .GroupBy(student => new { student.Surname, student.Initials, student.Grade }, (stud, subjects) =>
                 new
                 {
                     stud,
                     algebra = subjects.Count(x => x.Subject == "Algebra"),
                     informatics = subjects.Count(x => x.Subject == "Informatics"),
                     geometry = subjects.Count(x => x.Subject == "Geometry")
                 })
                .OrderBy(data => data.stud.Grade)
                .ThenBy(data => data.stud.Surname)
                .ThenBy(data => data.stud.Initials);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.stud.Grade}\t{item.stud.Surname} {item.stud.Initials}\t{item.algebra} {item.geometry} {item.informatics}");
            }
        }
    }
}
