using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLibrary.Interfaces
{
    public interface ILogger
    {
        public void ShowGPA(double gpa, List<Course> courses);
    }
}
