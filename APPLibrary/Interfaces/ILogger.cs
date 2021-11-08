using APPModels;
using System.Collections.Generic;

namespace APPLibrary.Interfaces
{
    public interface ILogger
    {
        void ShowErrorMsg(string msg);
        void ShowGPA(double gpa, List<Course> courses);
        void ShowHeader(string header);
        void ShowInstruction(string instruction);
        void ShowInfo(string info);
        void ShowUserOptions();
    }
}