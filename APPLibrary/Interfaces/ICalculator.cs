using APPModels;
using System.Collections.Generic;

namespace APPLibrary.Implementations
{
    public interface ICalculator
    {
        double CalculateGPA(List<Course> courses);
        Calculator.Grades Grading(int courseScore);
    }
}