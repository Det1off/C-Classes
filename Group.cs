using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    public class Group
    {
        private List<Student> _students { get; set; }
        private string _groupName;
        public string groupName
        {
            get { return _groupName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _groupName = value;
                }
            }
        }

        private string _specialization;
        private int _courseNumber;

        public Group()
        {
            _students = new List<Student>();
        }

        public void SetStudents(List<Student> students)
        {
            _students = students;
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public void SetGroupName(string groupName)
        {
            _groupName = groupName;
        }

        public string GetGroupName()
        {
            return _groupName;
        }

        public void SetSpecialization(string specialization)
        {
            _specialization = specialization;
        }

        public string GetSpecialization()
        {
            return _specialization;
        }

        public void SetCourseNumber(int courseNumber)
        {
            _courseNumber = courseNumber;
        }

        public int GetCourseNumber()
        {
            return _courseNumber;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void ShowAllStudents()
        {
            Console.WriteLine($"Group: {_groupName}, Specialization: {_specialization}, Course: {_courseNumber}");
            foreach (var student in _students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void TransferStudent(Group targetGroup, Student student)
        {
            if (_students.Remove(student))
            {
                targetGroup.AddStudent(student);
            }
        }

        public void ExpelLowestScoringStudent()
        {
            if (_students.Count > 0)
            {
                var lowestScoringStudent = _students.OrderBy(s => s.GetTestScores().Average()).FirstOrDefault();
                if (lowestScoringStudent != null)
                {
                    _students.Remove(lowestScoringStudent);
                }
            }
        }

        public static bool operator >(Group g1, Group g2) => g1._students.Count > g2._students.Count;
        public static bool operator <(Group g1, Group g2) => g1._students.Count < g2._students.Count;
        public static bool operator ==(Group g1, Group g2) => g1._students.Count == g2._students.Count;
        public static bool operator !=(Group g1, Group g2) => !(g1 == g2);
        public static implicit operator bool(Group g) => g._students.Count > 0;

        public Student this[int index] => (index >= 0 && index < _students.Count) ? _students[index] : null;

        public override bool Equals(object obj)
        {
            if (obj is Group other)
            {
                return _groupName == other._groupName &&
                       _specialization == other._specialization;
            }
            return false;
        }

        public override int GetHashCode() => (_groupName, _specialization).GetHashCode();
    }
}

