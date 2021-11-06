using APPLibrary.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLibrary.Implementations
{
    public class Logger : ILogger
    {

        public void ShowUserOptions()
        {
            Console.WriteLine("GPA Calculator");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Select an option below");
            sb.AppendLine("1. Add New Course");
            sb.AppendLine("2. View GPA");
            sb.AppendLine("3. Reset Records");
            sb.AppendLine("4. Exit");

            Console.WriteLine(sb);
        }


        public void ShowGPA(double gpa, List<Course> courses)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("==============================\n============================");
            sb.AppendLine($"GPA: {gpa}");
            Console.WriteLine(sb);
        }

        public void ShowInfo(string info)
        {
            Console.WriteLine();
            Console.WriteLine($"==             {info}            ==");
        }

        public void ShowErrorMsg(string msg)
        {
            Console.WriteLine();
            Console.WriteLine($"********** {msg} ************");
            Console.WriteLine();
        }
    }
}
