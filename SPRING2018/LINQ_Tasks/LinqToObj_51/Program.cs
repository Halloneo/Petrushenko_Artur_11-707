using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_51
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = Generator.GetStudents(10);


            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var answer = students
                .GroupBy(student => student.School, (school, student) =>
                new
                {
                    school,
                    stud = student.Where(exam => exam.Points[2] == student.Max(exams => exams.Points[2]))
                })
                .OrderBy(data => data.school);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.school} {item.stud.First().Surname} {item.stud.First().Initials} \t{item.stud.First().Points[2]}");
            }
        }
    }
}
