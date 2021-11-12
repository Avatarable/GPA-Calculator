using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APPLibrary
{
    public interface IUtilities
    {
        public string GetStartOption();
        public string GetUserOption();
        bool GetYesOrNo(string ques);
        public Task AddCourseAsync();
        void LoadCourses();
        public Task ViewGPAAsync();
        public Task ResetRecordsAsync();
    }
}
