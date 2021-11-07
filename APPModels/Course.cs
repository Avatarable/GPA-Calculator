using System;

namespace APPModels
{
    public class Course : ICourse
    {
        public string CourseNameAndCode { get; set; }
        public int CourseUnit { get; set; }
        public int CourseScore { get; set; }
        public string Grade { get; set; }
        public int GradeUnit { get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(CourseNameAndCode)) isValid = false;
            if (CourseUnit < 1) isValid = false;
            if (CourseScore < 1) isValid = false;

            return isValid;
        }
    }
}
