using System;
using System.Collections.Generic;

namespace BarbaronaJC.Problem2
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem2_Dictionary
    {
        static Dictionary<string, Student> students = new Dictionary<string, Student>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("     STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter choice: ");

                choice = ReadInt();

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: SearchStudent(); break;
                    case 3: DisplayAllStudents(); break;
                    case 4: Console.WriteLine("Exiting program. Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice. Please try again."); break;
                }
            } while (choice != 4);
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
            Console.Write("Enter Student Number: ");
            string number = Console.ReadLine() ?? "";

            if (students.ContainsKey(number))
            {
                Console.WriteLine("\nA student with this Student Number already exists!");
                return;
            }

            var s = new Student();
            s.StudentNumber = number;

            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine() ?? "";

            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine() ?? "";

            Console.Write("Enter Year Level (1, 2, 3, or 4): ");
            s.YearLevel = ReadInt();

            students.Add(number, s);
            Console.WriteLine("\nStudent added successfully!");
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string number = Console.ReadLine() ?? "";

            if (students.TryGetValue(number, out Student s))
            {
                Console.WriteLine("\nStudent found:");
                Console.WriteLine($"Student Number: {s.StudentNumber}");
                Console.WriteLine($"Name: {s.Name}");
                Console.WriteLine($"Program: {s.Program}");
                Console.WriteLine($"Year Level: {s.YearLevel}");
            }
            else
            {
                Console.WriteLine("\nStudent Number does not exist.");
            }
        }

        static void DisplayAllStudents()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("             STUDENT RECORDS");
            Console.WriteLine("========================================");

            if (students.Count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            foreach (var entry in students)
            {
                var s = entry.Value;
                Console.WriteLine($"Student Number: {s.StudentNumber}");
                Console.WriteLine($"Name: {s.Name}");
                Console.WriteLine($"Program: {s.Program}");
                Console.WriteLine($"Year Level: {s.YearLevel}");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
