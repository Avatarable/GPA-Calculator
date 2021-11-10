using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPModels;
using System;
using System.Linq;
using APPLibrary.Implementations;
using APPLibrary.Interfaces;
using System.IO;
using System.Collections.Generic;
using APPDataAccess.Repositories;
using APPDataAccess.Repositories.InFileRepository.Interfaces;

namespace APPLibrary
{
    public class Utilities : IUtilities
    {
        readonly ICourseRepository _inMemRepo;
        readonly ICourseFileRepository _inFileRepo;
        readonly List<ICRUDRepository> _repos;
        readonly ILogger _logger;
        readonly ICalculator _calculator;
        private readonly string _path;

        public Utilities(List<ICRUDRepository> repos, ILogger logger, ICalculator calc, string path)
        {
            _repos = repos;
            _logger = logger;
            _calculator = calc;
            _inMemRepo = repos[0] as ICourseRepository;
            _inFileRepo = repos[1] as ICourseFileRepository;
            _path = path;
        }

        public string GetStartOption()
        {
            string[] options = { "1", "2", "3" };
            _logger.ShowStartOptions();
            string option = Console.ReadLine();
            while (!options.Contains(option))
            {
                Console.Clear();
                _logger.ShowErrorMsg("Option unavailable!");
                _logger.ShowStartOptions();
                option = Console.ReadLine();
            }
            return option;
        }

        public string GetUserOption()
        {
            string[] options = { "1", "2", "3", "4"};
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

            int courseUnit = GetValidInput("Enter Course Unit", 1, 50);
            int courseScore = GetValidInput("Enter Course Score", 0, 100);

            var course = new Course
            {
                CourseNameAndCode = courseNameCode,
                CourseUnit = courseUnit,
                CourseScore = courseScore
            };


            if (course.Validate())
            {
                bool added = false;
                foreach(var repo in _repos)
                {
                    added = repo.Add(course);
                    if (!added) break;
                }

                if (added)
                {
                    _logger.ShowInfo($"You added {courseNameCode}");
                }
                else
                {
                    _logger.ShowErrorMsg("Course already exists");
                }
            }
        }


        public void ViewGPA()
        {
            double gpa = _calculator.CalculateGPA(_inMemRepo.GetCourses());

            _logger.ShowGPA(gpa, _inMemRepo.GetCourses());
        }

        public void LoadCourses()
        {
            var courses = _inFileRepo.LoadCourses();
            foreach(var course in courses)
            {
                _inMemRepo.Add(course);
            }
            Console.WriteLine("Loaded!!");
        }

        public void ResetRecords()
        {
            bool reset = false;
            foreach (var repo in _repos)
            {
                reset = repo.Reset();
                if (!reset) break;
            }
            if (reset)
            {
                _logger.ShowInfo("All courses removed!");
            }
            else
            {
                _logger.ShowErrorMsg("Cannot remove courses");
            }
        }

        public int GetValidInput(string instruction, int start, int end)
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
                    if (output < start || output > end)
                    {
                        _logger.ShowErrorMsg($"Can only be a number between {start} and {end}");
                        valid = false;
                    }
                }
                catch (Exception e)
                {
                    // Log (e.Message) to File
                    using(StreamWriter sw = new StreamWriter(_path, true))
                    {
                        DateTime dtNow = DateTime.Now;
                        sw.WriteLine($"{dtNow} -- ({e.GetType()}) {e.Message}");
                    }
                    valid = false;
                    _logger.ShowErrorMsg($"Can only be a number between {start} and {end}");
                }
            }
            return output;
        }
    }
}
