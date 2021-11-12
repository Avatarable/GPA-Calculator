using APPDataAccess.Repositories.InFileRepository.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace APPDataAccess.Repositories.InFileRepository.Implementations
{
    public class CourseFileRepository : ICourseFileRepository
    {
        private readonly string _savePath;
        private readonly string _logErrorPath;
        public CourseFileRepository(string savePath, string logErrorPath)
        {
            _savePath = savePath;
            _logErrorPath = logErrorPath;
        }

        public Task<bool> AddAsync<T>(T model)
        {
            try
            {
                Course course = model as Course;
                using (StreamWriter sw = new StreamWriter(_savePath, true))
                {
                    sw.WriteLine($"{course.CourseNameAndCode}||{course.CourseUnit}||{course.CourseScore}");
                }
                return Task.Run(() => true);
            }
            catch (Exception e)
            {
                using (StreamWriter err = new StreamWriter(_logErrorPath, true))
                {
                    DateTime dtNow = DateTime.Now;
                    err.WriteLine($"{dtNow} -- ({e.GetType()}) {e.Message}");
                }
                return Task.Run(() => false);
            }
        }

        public List<Course> LoadCourses()
        {
            List<Course> courses = new List<Course>();

            if (File.Exists(_savePath))
            {
                var info = new FileInfo(_savePath);
                if (info.Length > 0)
                {
                    string[] lineArr = new string[3];
                    foreach (var line in File.ReadAllLines(_savePath))
                    {
                        lineArr = line.Split("||");
                        courses.Add(new Course
                        {
                            CourseNameAndCode = lineArr[0],
                            CourseUnit = Convert.ToInt16(lineArr[1]),
                            CourseScore = Convert.ToInt16(lineArr[2])
                        });
                    }
                }
            }
            return courses;
        }

        public Task<bool> ResetAsync()
        {
            bool reset = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(_savePath))
                {
                    sw.Write("");
                }
            }
            catch(Exception e)
            {
                using (StreamWriter sw = new StreamWriter(_logErrorPath, true))
                {
                    DateTime dtNow = DateTime.Now;
                    sw.WriteLine($"{dtNow} -- ({e.GetType()}) {e.Message}");
                }
            }
            finally
            {
                int rowCount = RowCount();
                if(rowCount == 0)
                {
                    reset = true;
                }
            }
            return Task.Run(() => reset);
        }


        public int RowCount()
        {
            int count = 0;

            if (File.Exists(_savePath))
            {
                var info = new FileInfo(_savePath);
                if (info.Length > 0)
                {
                    foreach (var line in File.ReadAllLines(_savePath))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
