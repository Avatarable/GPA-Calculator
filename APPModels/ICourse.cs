namespace APPModels
{
    public interface ICourse
    {
        string CourseNameAndCode { get; set; }
        int CourseScore { get; set; }
        int CourseUnit { get; set; }
        string Grade { get; set; }
        int GradeUnit { get; set; }

        bool Validate();
    }
}