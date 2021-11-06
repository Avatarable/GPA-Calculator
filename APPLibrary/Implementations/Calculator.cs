using APPDataAccess.Repositories.InMemoryRepository.Implementations;
using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APPLibrary.Implementations
{
    public class Calculator
    {
        public double CalculateGPA(List<Course> courses)
        {
            List<int> qualityPoints = new List<int>();
            List<int> gradeUnits = new List<int>();

            foreach(Course course in courses)
            {
                qualityPoints.Add(course.CourseUnit * Grading(course.CourseScore));
                gradeUnits.Add(course.CourseUnit);
            }

            double gpa = (double)qualityPoints.Sum() / (double)gradeUnits.Sum();
            return  gpa;
        }

        public int Grading(int courseScore)
        {
            if(courseScore>=70 && courseScore <= 100)
            {
                return 5;
            }
            else if (courseScore >= 60 && courseScore <= 69)
            {
                return 4;
            }
            else if (courseScore >= 50 && courseScore <= 59)
            {
                return 3;
            }
            else if (courseScore >= 45 && courseScore <= 49)
            {
                return 2;
            }
            else if (courseScore >= 40 && courseScore <= 44)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
