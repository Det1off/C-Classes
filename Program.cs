namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание студентов
            var student1 = new Student("Ivanov", "Ivan", "Ivanovich") { AverageScore = 8 };
            var student2 = new Student("Petrov", "Petr", "Petrovich") { AverageScore = 6 };
            var student3 = new Student("Sidorov", "Sidr", "Sidorovich") { AverageScore = 9 };

            // Создание группы
            var group = new Group();
            group.AddStudent(student1);
            group.AddStudent(student2);
            group.AddStudent(student3);

            // Сортировка по среднему баллу
            group.GetStudents().Sort(new Student.SortByAverageScore());
            group.ShowAllStudents();
        }
    }
}