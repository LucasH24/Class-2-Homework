using System;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            do
            {
                Console.WriteLine("1) Read data from file");
                Console.WriteLine("2) Create file from data");
                Console.WriteLine("Enter any other key to exit");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        string headerLine = sr.ReadLine();
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] arr = line.Split(',');
                            string[] arr2 = arr[6].Split('|');
                            string watching = arr2[0];
                            for (int i = 1; i < arr2.Length; i++)
                            {
                                watching += (", " + arr2[i]);
                            }
                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], watching);

                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }

                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file);

                    Console.WriteLine("Enter Ticket ID");
                    string ans1 = Console.ReadLine();
                    Console.WriteLine("Enter Ticket Summary");
                    string ans2 = Console.ReadLine();
                    Console.WriteLine("Enter Ticket Status");
                    string ans3 = Console.ReadLine();
                    Console.WriteLine("Enter Ticket Priority");
                    string ans4 = Console.ReadLine();
                    Console.WriteLine("Enter Ticket Submitter");
                    string ans5 = Console.ReadLine();
                    Console.WriteLine("Enter Ticket Assigned");
                    string ans6 = Console.ReadLine();
                    Console.WriteLine("Enter the number of watchers (written in numbers not words)");
                    int numInput = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Watcher");
                    string ans7 = Console.ReadLine();

                    for (int i = 2; i <= numInput; i++)
                    {
                        Console.WriteLine("Enter Watcher #" + i);
                        string temp = Console.ReadLine();
                        ans7 += ("|" + temp);
                    }
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ans1, ans2, ans3, ans4, ans5, ans6, ans7);
                    sw.Close();
                }


            } while (choice == "1" || choice == "2");
        }

    }
}