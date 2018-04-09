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
                .GroupBy(student => new { student.Surname, student.Initials }, (stud, subjects) =>
                 new
                 {
                     stud,
                     subjects = subjects.GroupBy(x => x.Subject, (subject, marks) =>
                     new
                     {
                         subject,
                         marks = marks.Count()             
                    })
                });

            foreach (var item in answer)
            {
                foreach (var subject in item.subjects)
                {
                    Console.WriteLine($"{item.stud.Initials} {item.stud.Surname} {subject.subject} {subject.marks}");
                }
            }
        }
    }
}
