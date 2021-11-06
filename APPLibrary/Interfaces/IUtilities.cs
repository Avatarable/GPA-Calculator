using System;
using System.Collections.Generic;
using System.Text;

namespace APPLibrary
{
    public interface IUtilities
    {
        public string GetUserOption();
        public bool AddCourse();
        public void ViewCourses();
        public void ViewGPA();
    }
}
