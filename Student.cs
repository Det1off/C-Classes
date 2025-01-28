using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    // Свойства
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public List<int> TestScores { get; set; } = new List<int>();
    public List<int> CourseworkScores { get; set; } = new List<int>();
    public List<int> ExamScores { get; set; } = new List<int>();

    // Конструкторы
    public Student() { }

    public Student(string surname, string firstName, string lastName)
    {
        Surname = surname;
        FirstName = firstName;
        LastName = lastName;
    }

    // Методы
    public void ShowAllData()
    {
        Console.WriteLine(ToString());
        Console.WriteLine(string.Join(", ", TestScores));
        Console.WriteLine(string.Join(", ", CourseworkScores));
        Console.WriteLine(string.Join(", ", ExamScores));
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Surname}, DOB: {Birthday:yyyy-MM-dd}, Address: {Address}, Phone: {PhoneNumber}";
    }

    // Средний балл
    public double AverageScore => TestScores.Concat(CourseworkScores).Concat(ExamScores).DefaultIfEmpty(0).Average();

    // Операторы сравнения
    public static bool operator >(Student s1, Student s2) => s1.AverageScore > s2.AverageScore;
    public static bool operator <(Student s1, Student s2) => s1.AverageScore < s2.AverageScore;
    public static bool operator ==(Student s1, Student s2) => s1.AverageScore == s2.AverageScore;
    public static bool operator !=(Student s1, Student s2) => !(s1 == s2);
    public static implicit operator bool(Student s) => s.AverageScore >= 7;

    public override bool Equals(object obj)
    {
        if (obj is Student other)
        {
            return Surname == other.Surname &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName;
        }
        return false;
    }

    public override int GetHashCode() => (Surname, FirstName, LastName).GetHashCode();

    // Вложенные классы для сортировки
    public class SortByAverageScore : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.AverageScore.CompareTo(y.AverageScore);
        }
    }

    public class SortByFullName : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return $"{x.LastName} {x.FirstName} {x.Surname}".CompareTo($"{y.LastName} {y.FirstName} {y.Surname}");
        }
    }
}
