using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.UserName;
            if(Directory.Exists(@"C:\users\" + username + @"\Appdata\local\AI"))
            {
                Start();
            }
            else
            {
                Install();
            }
        }

        private static void Start()
        {
            string username = Environment.UserName;
            if (File.Exists(@"C:\users\" + username + @"\Appdata\local\AI\sys\user.txt"))
            {
                string user = File.ReadAllText(@"C:\users\" + username + @"\Appdata\local\AI\sys\user.txt");
                Console.WriteLine("Welcome back " + user);
                Console.WriteLine();
                while (true)
                {
                    Console.Write("Enter Message:");
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (File.Exists(@"C:\users\" + username + @"\Appdata\local\AI\" + input + ".txt"))
                    {
                        if(input.ToLower() == "open")
                        {
                            Console.Write("Enter a Url or Program you would like to open: ");
                            string open = Console.ReadLine();
                            try
                            {
                                string open_file = File.ReadAllText(@"C:\users\" + username + @"\Appdata\local\AI\open\" + open.ToLower() + ".txt");
                                Process.Start(open_file);
                            }
                            catch (Exception)
                            {
                                string user_1 = File.ReadAllText(@"C:\users\" + username + @"\Appdata\local\AI\sys\user.txt");
                                Console.Clear();
                                Console.WriteLine("Sorry we I don't know where that program is.");
                                Console.WriteLine();
                                Console.Write("Enter the path of the program or file you wanted to open:");
                                string learn_open = Console.ReadLine();
                                StreamWriter nw = new StreamWriter(open.ToLower());
                                nw.WriteLine(learn_open.ToLower());
                                nw.Close();
                                Console.WriteLine("Thank you " + user_1 + " I now know where that is. so next time you won't get this message.");
                            }
                        }
                        string output = File.ReadAllText(@"C:\users\" + username + @"\Appdata\local\AI\" + input.ToLower() + ".txt");

                        Console.WriteLine(user + ": " + input);
                        Console.WriteLine();
                        Console.WriteLine("AI Bot: " + output);
                    }
                    else
                    {
                        string error = File.ReadAllText(@"C:\users\" + username + @"\Appdata\local\AI\sys\error.txt");
                        Console.Clear();
                        Console.WriteLine(error);
                        Console.Write("Enter here:");
                        string learn = Console.ReadLine();
                        StreamWriter learned = new StreamWriter(@"C:\users\" + username + @"\Appdata\local\AI\" + input.ToLower() + ".txt");
                        learned.WriteLine(learn);
                        learned.Close();
                        Console.Clear();
                    }
                }
            }
            else
            {
                string user = File.ReadAllText(@"C:\users\" + username + @"\Appdata\local\AI\sys\user.txt");
                Console.Write("Please enter you name:");
                string name = Console.ReadLine();
                StreamWriter n = new StreamWriter(@"C:\users\" + username + @"\Appdata\local\AI\sys\user.txt");
                n.Write(name);
                n.Close();
                Console.Clear();
                Console.WriteLine("Thank you " + user + " please start this program again to continue.");
                Console.ReadKey();
            }
        }

        private static void Install()
        {
            string username = Environment.UserName;
            Directory.CreateDirectory(@"C:\users\" + username + @"\Appdata\local\AI");
            Directory.CreateDirectory(@"C:\users\" + username + @"\Appdata\local\AI\open");
            Directory.CreateDirectory(@"C:\users\" + username + @"\Appdata\local\AI\sys");
            StreamWriter er = new StreamWriter(@"C:\users\" + username + @"\Appdata\local\AI\sys\error.txt");
            er.WriteLine("I don't understand. can you explain how you want me to respond.");
            er.Close();
            Start();
        }
    }
}
