using System;
using System.Collections.Generic;

namespace BarbaronaJC.Problem4
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    struct Operation
    {
        public string Description;
        public Operation(string description) => Description = description;
    }

    class Problem4_Stack
    {
        static Student[] students = new Student[10];
        static int count;
        static Stack<Operation> operationHistory = new Stack<Operation>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("  STUDENT RECORDS - OPERATION HISTORY");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. View Operation History");
                Console.WriteLine("6. View Last Operation");
                Console.WriteLine("7. Remove Last Operation");
                Console.WriteLine("8. Exit");
                Console.Write("\nEnter choice: ");

                choice = ReadInt();

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: UpdateStudent(); break;
                    case 3: DeleteStudent(); break;
                    case 4: DisplayAllStudents(); break;
                    case 5: ViewOperationHistory(); break;
                    case 6: ViewLastOperation(); break;
                    case 7: RemoveLastOperation(); break;
                    case 8: Console.WriteLine("Exiting program. Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice. Please try again."); break;
                }
            } while (choice != 8);
        }

        static int ReadInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid input. Enter a number: ");

            return value;
        }

        static void RecordOperation(string description) => operationHistory.Push(new Operation(description));

        static int FindStudentIndex(string studentNumber)
        {
            for (int i = 0; i < count; i++)
                if (students[i].StudentNumber.Equals(studentNumber, StringComparison.OrdinalIgnoreCase))
                    return i;

            return -1;
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
            s.StudentNumber = Console.ReadLine() ?? "";

            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine() ?? "";

            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine() ?? "";

            Console.Write("Enter Year Level (1, 2, 3, or 4): ");
            s.YearLevel = ReadInt();

            students[count++] = s;
            RecordOperation($"Added {s.Name}");
            Console.WriteLine("\nStudent added successfully!");
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student Number to update: ");
            string number = Console.ReadLine() ?? "";

            int index = FindStudentIndex(number);
            if (index == -1)
            {
                Console.WriteLine("\nStudent not found.");
                return;
            }

            var s = students[index];

            Console.Write($"Enter new Name ({s.Name}): ");
            string name = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(name)) s.Name = name;

            Console.Write($"Enter new Program ({s.Program}): ");
            string program = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(program)) s.Program = program;

            Console.Write($"Enter new Year Level ({s.YearLevel}): ");
            string yearInput = Console.ReadLine() ?? "";
            if (int.TryParse(yearInput, out int year)) s.YearLevel = year;

            students[index] = s;
            RecordOperation($"Updated {s.Name}");
            Console.WriteLine("\nStudent updated successfully!");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            string number = Console.ReadLine() ?? "";

            int index = FindStudentIndex(number);
            if (index == -1)
            {
                Console.WriteLine("\nStudent not found.");
                return;
            }

            string deletedName = students[index].Name;

            for (int i = index; i < count - 1; i++)
                students[i] = students[i + 1];

            count--;
            RecordOperation($"Deleted {deletedName}");
            Console.WriteLine("\nStudent deleted successfully!");
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

        static void ViewOperationHistory()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("           OPERATION HISTORY");
            Console.WriteLine("========================================");

            if (operationHistory.Count == 0)
            {
                Console.WriteLine("There are no recorded operations.");
                return;
            }

            int position = 1;
            foreach (var op in operationHistory)
                Console.WriteLine($"{position++}. {op.Description}");
        }

        static void ViewLastOperation()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("\nThere are no recorded operations.");
                return;
            }

            Console.WriteLine($"\nMost recent operation: {operationHistory.Peek().Description}");
        }

        static void RemoveLastOperation()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("\nThere are no recorded operations.");
                return;
            }

            var removed = operationHistory.Pop();
            Console.WriteLine($"\nRemoved last operation from history: {removed.Description}");
        }
    }
}