using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Student
    {
        private string _surname;
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;
        private string _address;
        private string _phoneNumber;

        private List<int> _testScores;
        private List<int> _courseworkScores;
        private List<int> _examScores;

        public Student() { }

        public Student(string surname, string firstName, string lastName)
        {
            _surname = surname;
            _firstName = firstName;
            _lastName = lastName;
        }

        public void ShowAllData()
        {
            Console.WriteLine(ToString());
            Console.WriteLine(Convert.ToString(GetTestScores()));
            Console.WriteLine(Convert.ToString(GetCourseworkScores()));
            Console.WriteLine(Convert.ToString(GetExamScores()));
        }

        public override string ToString()
        {
            return $"{_lastName} {_firstName} {_surname}, DOB: {_birthday}, Address: {_address}, Phone: {_phoneNumber}";
        }

        public void Set_ExamScores(List<int> examScores)
        {
            _examScores = examScores;
        }

        public List<int> GetExamScores()
        {
            return _examScores;
        }

        public void SetCourseworkScores(List<int> courseworkScores)
        {
            _courseworkScores = courseworkScores;
        }

        public List<int> GetCourseworkScores()
        {
            return _courseworkScores;
        }

        public void SetTestScores(List<int> testScores)
        {
            _testScores = testScores;
        }

        public List<int> GetTestScores()
        {
            return _testScores;
        }

        public void SetSurname(string surname)
        {
            _surname = surname;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetBirthday(DateTime birthday)
        {
            _birthday = birthday;
        }

        public DateTime GetDataTime()
        {
            return _birthday;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public string GetAddress()
        {
            return _address;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public double AverageScore => (_testScores?.Concat(_courseworkScores ?? new List<int>())
                                       .Concat(_examScores ?? new List<int>())
                                       .Average()) ?? 0;

        public static bool operator >(Student s1, Student s2) => s1.AverageScore > s2.AverageScore;
        public static bool operator <(Student s1, Student s2) => s1.AverageScore < s2.AverageScore;
        public static bool operator ==(Student s1, Student s2) => s1.AverageScore == s2.AverageScore;
        public static bool operator !=(Student s1, Student s2) => !(s1 == s2);
        public static implicit operator bool(Student s) => s.AverageScore >= 7;

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return _surname == other._surname &&
                       _firstName == other._firstName &&
                       _lastName == other._lastName;
            }
            return false;
        }

        public override int GetHashCode() => (_surname, _firstName, _lastName).GetHashCode();
    }
}
