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
        private string Surname;
        private string FirstName;
        private string LastName;
        private string Birthday;
        private string Address;
        private string PhoneNumber;

        private List<int> TestScores;
        private List<int> CourseworkScores;
        private List<int> ExamScores;

        public Student() { }

        public Student (string surname, string firstName, string lastName)
        {
            Surname = surname;
            FirstName = firstName;
            LastName = lastName;
        }

        public void ShowAllData()
        {
            Console.WriteLine(ToString());
            Console.WriteLine(Convert.ToString(Get_TestScores()));
            Console.WriteLine(Convert.ToString(Get_CourseworkScores()));
            Console.WriteLine(Convert.ToString(Get_ExamScores()));
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {Surname}, DOB: {Birthday}, Address: {Address}, Phone: {PhoneNumber}";
        }

        public void Set_ExamScores(List<int> examScores)
        {
            ExamScores = examScores;
        }

        public List<int> Get_ExamScores()
        {
            return ExamScores;
        }

        public void Set_CourseworkScores(List<int> courseworkScores)
        {
            CourseworkScores = courseworkScores;
        }

        public List<int> Get_CourseworkScores()
        {
            return CourseworkScores;
        }

        public void Set_TestScores (List<int> testScores)
        {
            TestScores = testScores;
        }

        public List<int> Get_TestScores ()
        {
            return TestScores;
        }

        public void Set_Surname(string surname)
        {
            Surname = surname;
        }

        public string Get_Surname()
        {
            return Surname;
        }

        public void Set_FirstName(string firstName)
        {
            FirstName = firstName;
        }

        public string Get_FirstName()
        {
            return FirstName;
        }

        public void Set_LastName(string lastName)
        {
            LastName = lastName;
        }

        public string Get_LastName ()
        {
            return LastName;
        }

        public void Set_Birthday(string birthday)
        {
            Birthday = birthday;
        }

        public string GetDataTime()
        {
            return Birthday;
        }

        public void Set_Address(string address)
        {
            Address = address;
        }

        public string Get_Address()
        {
            return Address;
        }

        public void Set_PhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string Get_PhoneNumber ()
        {
            return PhoneNumber;
        }







    }
}
