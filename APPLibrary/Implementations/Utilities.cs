using APPDataAccess.Repositories;
using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPDataAccess.Repositories.InMemoryRepository.Implementations;
using APPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APPLibrary.Implementations;

namespace APPLibrary
{
    public class Utilities : IUtilities
    {
        readonly ICourseRepository repository = new CourseRepository();
        readonly Logger logger = new Logger();

        public string GetUserOption()
        {
            string[] options = { "1", "2", "3", "4", "N", "V", "R", "Q" };
            logger.ShowUserOptions();            

            string option = Console.ReadLine();

            while (!options.Contains(option))
            {
                Console.Clear();
                logger.ShowErrorMsg("Option unavailable!");
                logger.ShowUserOptions();
                option = Console.ReadLine();
            }
            return option;
        }

        public bool AddCourse()
        {
            Console.WriteLine("Enter Course Name and Code");
            string courseNameCode = Console.ReadLine();

            Console.WriteLine("Enter Course Unit");
            int courseUnit = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter Course Score");
            int courseScore = Convert.ToInt16(Console.ReadLine());

            var course = new Course
            {
                CourseNameAndCode = courseNameCode,
                CourseUnit = courseUnit,
                CourseScore = courseScore
            };

            if (course.Validate())
            {
                repository.Add(course);
                logger.ShowInfo($"You added {courseNameCode}");
            }
            return false;
        }

        public void ViewCourses()
        {
            var courses = repository.GetCourses();
            foreach (Course course in courses)
            {
                Console.WriteLine("=======================");
                Console.WriteLine(course.CourseNameAndCode);
                Console.WriteLine(course.CourseUnit);
                Console.WriteLine(course.CourseScore);
            }
        }

        public void ViewGPA()
        {
            Calculator calculator = new Calculator();
            double gpa = calculator.CalculateGPA(repository.GetCourses());

            logger.ShowGPA(gpa, repository.GetCourses());
        }

        public void ResetRecords()
        {
            repository.Reset();
            logger.ShowInfo("All courses removed!");
        }
    }
}
