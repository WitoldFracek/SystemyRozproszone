using ClientLab4.StudentReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> records = new List<Student>();
            Console.WriteLine("Starting client");
            StudentClient client = new StudentClient();
            bool end = false;
            while (!end)
            {
                int index = GetMethod();
                switch(index)
                {
                    case 0:
                        end = true;
                        Console.WriteLine("Closing");
                        break;
                    case 1:
                        Console.WriteLine("Type student name, last name and age.");
                        string name = Console.ReadLine();
                        string lastName = Console.ReadLine();
                        int age = GetInt();
                        var s = new Student
                        {
                            Name = name,
                            LastName = lastName,
                            Age = age
                        };
                        records.Add(s);
                        break;
                    case 2:
                        Console.WriteLine("Type student index.");
                        int i = GetInt();
                        if(i < 0 || i >= records.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        records.RemoveAt(i);
                        break;
                    case 3:
                        int ii = GetInt();
                        if (ii < 0 || ii >= records.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        Student stud = records[ii];
                        Console.WriteLine("\nName to upper case");
                        Console.WriteLine(client.UpperName(stud));
                        //Console.WriteLine($"Student: {stud.Name} {stud.LastName} {stud.Age}");
                        break;
                    case 4:
                        int i2 = GetInt();
                        if (i2 < 0 || i2 >= records.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        Student stud2 = records[i2];
                        Console.WriteLine("\nAge in months:");
                        Console.WriteLine(client.AgeInMonths(stud2));
                        break;
                    case 5:
                        Console.WriteLine("\nSaved students:");
                        foreach (var record in records)
                        {
                            Console.WriteLine($"Student: {record.Name} {record.LastName} {record.Age}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("\nType last name:");
                        string ln = Console.ReadLine().Trim().ToLower();
                        int inx = records.FindIndex(sss => sss.LastName.ToLower() == ln);
                        if(inx == -1)
                        {
                            Console.WriteLine("Student with this name does not exist");
                        } else
                        {
                            Console.WriteLine($"Student at index {inx}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("\nType last name search to modify:");
                        string t = Console.ReadLine().Trim().ToLower();
                        Student toModify = records.Find(st => st.LastName.ToLower() == t);
                        if(toModify == null)
                        {
                            break;
                        }
                        Console.WriteLine("\nType new name.");
                        string newName = Console.ReadLine();
                        toModify.Name = newName;
                        break;
                }
            }
            client.Close();
        }
        public static int GetMethod()
        {
            Console.WriteLine("\nChoose method:");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Delete student");
            Console.WriteLine("3. Student name upper");
            Console.WriteLine("4. Student age in months");
            Console.WriteLine("5. Show students");
            Console.WriteLine("6. Find student");
            Console.WriteLine("7. Modify student");
            Console.WriteLine("0. Exit");

            bool isCorrect = false;
            int index = 0;
            while (!isCorrect)
            {
                try
                {
                    index = GetInt();
                    if (index < 8 && index >= 0)
                    {
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid index");
                }
            }
            return index;
        }

        public static int GetInt()
        {
            bool isCorrect = false;
            int index = 0;
            while (!isCorrect)
            {
                try
                {
                    index = int.Parse(Console.ReadLine().Trim());
                    isCorrect = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid int");
                }
            }
            return index;
        }

        public static double GetDouble()
        {
            bool isCorrect = false;
            double n1 = 0.0;
            while (!isCorrect)
            {
                try
                {
                    n1 = double.Parse(Console.ReadLine().Trim());
                    isCorrect = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data format (maybe use ',' instead of '.')");
                }

            }
            return n1;
        }
    }
}
