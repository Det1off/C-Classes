using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Group : IEnumerable<Student>
{
    // Свойства
    public List<Student> Students { get; private set; } = new List<Student>();
    public string GroupName { get; set; }
    public string Specialization { get; set; }
    public int CourseNumber { get; set; }

    // Конструкторы
    public Group() { }

    public Group(string groupName, string specialization, int courseNumber)
    {
        GroupName = groupName;
        Specialization = specialization;
        CourseNumber = courseNumber;
    }

    // Методы
    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

    public void ShowAllStudents()
    {
        Console.WriteLine($"Group: {GroupName}, Specialization: {Specialization}, Course: {CourseNumber}");
        foreach (var student in Students)
        {
            Console.WriteLine(student);
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
        if (Students.Any())
        {
            var lowestScoringStudent = Students.OrderBy(s => s.AverageScore).FirstOrDefault();
            if (lowestScoringStudent != null)
            {
                Students.Remove(lowestScoringStudent);
            }
        }
    }

    // Индексатор
    public Student this[int index] => (index >= 0 && index < Students.Count) ? Students[index] : null;

    // Операторы сравнения
    public static bool operator >(Group g1, Group g2) => g1.Students.Count > g2.Students.Count;
    public static bool operator <(Group g1, Group g2) => g1.Students.Count < g2.Students.Count;
    public static bool operator ==(Group g1, Group g2) => g1.Students.Count == g2.Students.Count;
    public static bool operator !=(Group g1, Group g2) => !(g1 == g2);
    public static implicit operator bool(Group g) => g.Students.Count > 0;

    public override bool Equals(object obj)
    {
        if (obj is Group other)
        {
            return GroupName == other.GroupName &&
                   Specialization == other.Specialization;
        }
        return false;
    }

    public override int GetHashCode() => (GroupName, Specialization).GetHashCode();

    // Реализация IEnumerable<Student>
    public IEnumerator<Student> GetEnumerator() => Students.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
