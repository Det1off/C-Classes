using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Group
    {
        private List<Student> Students;
        private string GroupName;
        private string Specialization;
        private int CourseNumber;

        public Group()
        {
            Students = new List<Student>();
        }

        public void Set_Students(List<Student> students)
        {
            Students = students;
        }

        public List<Student> Get_Students()
        {
            return Students;
        }

        public void Set_GroupName(string groupName)
        {
            GroupName = groupName;
        }

        public string Get_GroupName()
        {
            return GroupName;
        }

        public void Set_Specialization(string specialization)
        {
            Specialization = specialization;
        }

        public string Get_Specialization()
        {
            return Specialization;
        }

        public void Set_CourseNumber(int courseNumber)
        {
            CourseNumber = courseNumber;
        }

        public int Get_CourseNumber()
        {
            return CourseNumber;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void ShowAllStudents()
        {
            Console.WriteLine($"Group: {GroupName}, Specialization: {Specialization}, Course: {CourseNumber}");
            foreach (var student in Students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void TransferStudent(Group targetGroup, Student student)
        {
            if (Students.Remove(student))
            {
                targetGroup.AddStudent(student);
            }
        }

        public void ExpelLowestScoringStudent()
        {
            if (Students.Count > 0)
            {
                var lowestScoringStudent = Students.OrderBy(s => s.Get_TestScores().Average()).FirstOrDefault();
                if (lowestScoringStudent != null)
                {
                    Students.Remove(lowestScoringStudent);
                }
            }
        }
    }
}
