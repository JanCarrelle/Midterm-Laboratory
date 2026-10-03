using System;
using System.Collections.Generic;
 
namespace BarbaronaJC.Problem3
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }
 
    class Problem3_Queue
    {
        static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();
 
        static void Main(string[] args)
        {
            int choice;
 
            do
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("          STUDENT REQUEST QUEUE");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter choice: ");
 
                choice = ReadInt();
 
                switch (choice)
                {
                    case 1:
                        AddRequest();
                        break;
                    case 2:
                        ViewPendingRequests();
                        break;
                    case 3:
                        ProcessRequest();
                        break;
                    case 4:
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
 
            } while (choice != 4);
        }
 
        static int ReadInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a number: ");
            }
            return value;
        }
 
        static void AddRequest()
        {
            StudentRequest r = new StudentRequest();
 
            Console.Write("Enter Student Number: ");
            r.StudentNumber = Console.ReadLine() ?? "";
 
            Console.Write("Enter Student Name: ");
            r.StudentName = Console.ReadLine() ?? "";
 
            Console.Write("Enter Request Type: ");
            r.RequestType = Console.ReadLine() ?? "";
 
            requestQueue.Enqueue(r);
 
            Console.WriteLine("\nRequest added successfully!");
        }
 
        static void ViewPendingRequests()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("           PENDING REQUESTS");
            Console.WriteLine("========================================");
 
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("There are no pending requests.");
                return;
            }
 

            int position = 1;
            foreach (StudentRequest r in requestQueue)
            {
                Console.WriteLine($"{position}. Student Number: {r.StudentNumber}");
                Console.WriteLine($"   Student Name: {r.StudentName}");
                Console.WriteLine($"   Request Type: {r.RequestType}");
                Console.WriteLine("----------------------------------------");
                position++;
            }
        }
 
        static void ProcessRequest()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("\nThere are no pending requests to process.");
                return;
            }
 
            StudentRequest r = requestQueue.Dequeue();
 
            Console.WriteLine("\nProcessing request...");
            Console.WriteLine($"Student Number: {r.StudentNumber}");
            Console.WriteLine($"Student Name: {r.StudentName}");
            Console.WriteLine($"Request Type: {r.RequestType}");
            Console.WriteLine("Request has been processed and removed from the queue.");
        }
    }
}