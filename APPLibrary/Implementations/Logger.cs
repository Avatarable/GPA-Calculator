using APPLibrary.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APPLibrary.Implementations
{
    public class Logger : ILogger
    {
        public void ShowHeader(string header)
        {
            Console.WriteLine();
            Console.WriteLine($"     {header}");
            Console.Write("     ");
            for (int i = 0; i < header.Length; i++) Console.Write("-");
            Console.WriteLine();
        }

        public void ShowStartOptions()
        {
            ShowHeader("GPA Calculator");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     1. Resume");
            sb.AppendLine("     2. Start New Record");
            sb.AppendLine("     3. Exit");
            sb.AppendLine("     -----------------------");

            sb.Append("\n     ");
            Console.Write(sb);
        }

        public void ShowUserOptions()
        {
            //Console.WriteLine("     =======  GPA Calculator  ======");
            ShowHeader("Select an option below:");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     1. Add New Course");
            sb.AppendLine("     2. View GPA");
            sb.AppendLine("     3. Reset Records");
            sb.AppendLine("     4. Exit");
            sb.AppendLine("     -----------------------");

            sb.Append("\n     ");
            Console.Write(sb);
        }


        public void ShowGPA(double gpa, List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("     |---------------|-------------|-------|------------|");
            sb.AppendLine("     | COURSE & CODE | COURSE UNIT | GRADE | GRADE-UNIT |");
            sb.AppendLine("     |---------------|-------------|-------|------------|");
            //                         14              12         6         11

            foreach (Course course in courses)
            {
                string courseCodeName = (course.CourseNameAndCode.Length > 14) ? $"{course.CourseNameAndCode.Substring(0, 11)}..." 
                    : $"{course.CourseNameAndCode}";

                sb.Append($"     | {courseCodeName}");
                for (int i = 0; i < (14 - course.CourseNameAndCode.Length); i++) sb.Append(" ");
                sb.Append($"| {course.CourseUnit}");
                for (int i = 0; i < (12 - course.CourseUnit.ToString().Length); i++) sb.Append(" ");
                sb.Append($"| {course.Grade}");
                for (int i = 0; i < 5; i++) sb.Append(" ");
                sb.Append($"| {course.GradeUnit}");
                for (int i = 0; i < 10; i++) sb.Append(" ");
                sb.AppendLine("|");
            }

            sb.AppendLine("     |--------------------------------------------------|");
            if (Double.IsNaN(gpa)) sb.AppendLine("     No course recorded.");
            else sb.AppendLine($"     Your GPA is = {gpa.ToString("F")} to 2 decimal places");

            Console.WriteLine(sb);

        }

        public void ShowInstruction(string instruction)
        {
            Console.Write($"     {instruction}:  ");
        }

        public void ShowInfo(string info)
        {
            Console.WriteLine();
            Console.WriteLine($"     == {info} ==");
            Console.WriteLine();
        }

        public void ShowErrorMsg(string msg)
        {
            Console.WriteLine();
            Console.WriteLine($"     **** {msg} ****");
            Console.WriteLine();
        }

    }
}
