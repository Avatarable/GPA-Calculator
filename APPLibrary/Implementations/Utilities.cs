using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPModels;
using System;
using System.Linq;
using APPLibrary.Implementations;
using APPLibrary.Interfaces;

namespace APPLibrary
{
    public class Utilities : IUtilities
    {
        readonly ICourseRepository _repository;
        readonly ILogger _logger;
        readonly ICalculator _calculator;

        public Utilities(ICourseRepository repo, ILogger logger, ICalculator calc)
        {
            _repository = repo;
            _logger = logger;
            _calculator = calc;
        }

        public string GetUserOption()
        {
            string[] options = { "1", "2", "3", "4", "N", "V", "R", "Q" };
            _logger.ShowUserOptions();            

            string option = Console.ReadLine();

            while (!options.Contains(option))
            {
                Console.Clear();
                _logger.ShowErrorMsg("Option unavailable!");
                _logger.ShowUserOptions();
                option = Console.ReadLine();
            }
            return option;
        }

        public void AddCourse()
        {
            Console.Clear();
            _logger.ShowHeader("Add New Course");

            _logger.ShowInstruction("Enter Course Name and Code");
            string courseNameCode = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(courseNameCode))
            {
                Console.Clear();
                _logger.ShowHeader("Add New Course");
                _logger.ShowInstruction("Enter Course Name and Code");
                courseNameCode = Console.ReadLine();
            }

            int courseUnit = GetValidInput("Enter Course Unit", 50);
            int courseScore = GetValidInput("Enter Course Score", 100);


            var course = new Course
            {
                CourseNameAndCode = courseNameCode,
                CourseUnit = courseUnit,
                CourseScore = courseScore
            };


            if (course.Validate())
            {
                if (_repository.Add(course))
                {
                    _logger.ShowInfo($"You added {courseNameCode}");
                }
                else
                {
                    _logger.ShowErrorMsg("Cannot Add Course");
                }
            }
        }


        public void ViewGPA()
        {
            //Calculator _calculator = new Calculator();
            double gpa = _calculator.CalculateGPA(_repository.GetCourses());

            _logger.ShowGPA(gpa, _repository.GetCourses());
        }

        public void ResetRecords()
        {
            bool reset = _repository.Reset();
            if (reset)
            {
                _logger.ShowInfo("All courses removed!");
            }
            else
            {
                _logger.ShowErrorMsg("Cannot remove courses");
            }
        }

        public int GetValidInput(string instruction, int range)
        {
            int output = default;
            bool valid = false;
            while (!valid)
            {
                valid = true;
                _logger.ShowInstruction(instruction);
                try
                {
                    output = Convert.ToInt16(Console.ReadLine());
                    if (output < 1 || output > range)
                    {
                        _logger.ShowErrorMsg($"Can only be a number between 1 and {range}");
                        valid = false;
                    }
                }
                catch (Exception e)
                {
                    // Log (e.Message) to File
                    valid = false;
                    _logger.ShowErrorMsg($"Can only be a number between 1 and {range}");
                }
            }
            return output;
        }
    }
}
