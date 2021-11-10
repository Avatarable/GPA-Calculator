using System;
using System.Collections.Generic;
using System.Text;

namespace APPLibrary
{
    public interface IUtilities
    {
        public string GetStartOption();
        public string GetUserOption();
        bool GetYesOrNo(string ques);
        public void AddCourse();
        void LoadCourses();
        public void ViewGPA();
        public void ResetRecords();
    }
}
