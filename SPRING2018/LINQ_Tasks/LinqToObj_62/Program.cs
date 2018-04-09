using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_62
{
    class Program
    {
        static void Main(string[] args)
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
                     algebra = subjects.Where(x => x.Subject == "Algebra").Count(),
                     informatics = subjects.Where(x => x.Subject == "Informatics").Count(),
                     geometry = subjects.Where(x => x.Subject == "Geometry").Count()
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
