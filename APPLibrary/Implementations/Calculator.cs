using APPDataAccess.Repositories.InMemoryRepository.Implementations;
using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APPLibrary.Implementations
{
    public class Calculator : ICalculator
    {
        public double CalculateGPA(List<Course> courses)
        {
            List<int> qualityPoints = new List<int>();
            List<int> gradeUnits = new List<int>();

            foreach (Course course in courses)
            {
                qualityPoints.Add(course.CourseUnit * (int)Grading(course.CourseScore));
                //gradeUnits.Add((int)Grading(course.CourseScore));
                gradeUnits.Add(course.CourseUnit);

                course.Grade = Grading(course.CourseScore).ToString();
                course.GradeUnit = (int)Grading(course.CourseScore);
            }

            double gpa = (double)qualityPoints.Sum() / (double)gradeUnits.Sum();
            return gpa;
        }

        public Grades Grading(int courseScore)
        {
            if (courseScore >= 70 && courseScore <= 100)
            {
                return Grades.A;
            }
            else if (courseScore >= 60 && courseScore <= 69)
            {
                return Grades.B;
            }
            else if (courseScore >= 50 && courseScore <= 59)
            {
                return Grades.C;
            }
            else if (courseScore >= 45 && courseScore <= 49)
            {
                return Grades.D;
            }
            else if (courseScore >= 40 && courseScore <= 44)
            {
                return Grades.E;
            }
            else
            {
                return Grades.F;
            }
        }

        public enum Grades
        {
            F, E, D, C, B, A
        }
    }
}
