using System;

namespace BarbaronaJC.Problem1
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem1_Array
    {
        static Student[] students = new Student[10];
        static int count;

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("       STUDENT RECORD MANAGEMENT");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter choice: ");

                choice = ReadInt();

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: DisplayAllStudents(); break;
                    case 3: SearchStudent(); break;
                    case 4: UpdateStudent(); break;
                    case 5: DeleteStudent(); break;
                    case 6: Console.WriteLine("Exiting program. Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice. Please try again."); break;
                }

            } while (choice != 6);
        }

        static int ReadInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid input. Enter a number: ");

            return value;
        }

        static void AddStudent()
        {
            if (count >= students.Length)
            {
                Console.WriteLine("\nCannot add more students. Maximum of 10 records reached!");
                return;
            }

            var s = new Student();

            Console.Write("Enter Student Number: ");
            s.StudentNumber = Console.ReadLine();

            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();

            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine();

            Console.Write("Enter Year Level (1, 2, 3, or 4): ");
            s.YearLevel = ReadInt();

            students[count++] = s;
            Console.WriteLine("\nStudent added successfully!");
        }

        static void DisplayAllStudents()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("             STUDENT RECORDS");
            Console.WriteLine("========================================");

            if (count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                Console.WriteLine($"Name: {students[i].Name}");
                Console.WriteLine($"Program: {students[i].Program}");
                Console.WriteLine($"Year Level: {students[i].YearLevel}");
                Console.WriteLine("----------------------------------------");
            }
        }

        static int FindStudentIndex(string studentNumber)
        {
            for (int i = 0; i < count; i++)
                if (students[i].StudentNumber.Equals(studentNumber, StringComparison.OrdinalIgnoreCase))
                    return i;

            return -1;
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string number = Console.ReadLine();

            int index = FindStudentIndex(number);
            if (index == -1)
            {
                Console.WriteLine("\nStudent not found.");
                return;
            }

            Console.WriteLine("\nStudent found:");
            Console.WriteLine($"Student Number: {students[index].StudentNumber}");
            Console.WriteLine($"Name: {students[index].Name}");
            Console.WriteLine($"Program: {students[index].Program}");
            Console.WriteLine($"Year Level: {students[index].YearLevel}");
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student Number to update: ");
            string number = Console.ReadLine();

            int index = FindStudentIndex(number);
            if (index == -1)
            {
                Console.WriteLine("\nStudent not found.");
                return;
            }

            var s = students[index];

            Console.Write($"Enter new Name ({s.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) s.Name = name;

            Console.Write($"Enter new Program ({s.Program}): ");
            string program = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(program)) s.Program = program;

            Console.Write($"Enter new Year Level ({s.YearLevel}): ");
            string yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out int year)) s.YearLevel = year;

            students[index] = s;
            Console.WriteLine("\nStudent updated successfully!");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            string number = Console.ReadLine();

            int index = FindStudentIndex(number);
            if (index == -1)
            {
                Console.WriteLine("\nStudent not found.");
                return;
            }

            for (int i = index; i < count - 1; i++)
                students[i] = students[i + 1];

            count--;
            Console.WriteLine("\nStudent deleted successfully!");
        }
    }
}
