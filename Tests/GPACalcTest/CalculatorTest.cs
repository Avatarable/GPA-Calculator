using APPDataAccess.Repositories.InMemoryRepository.Implementations;
using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPLibrary.Implementations;
using APPModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPACalcTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void CalculateGPAValid()
        {
            //-- Arrange
            Course course1 = new Course
            {
                CourseNameAndCode = "MTH101",
                CourseScore = 80,
                CourseUnit = 2
            };

            Course course2 = new Course
            {
                CourseNameAndCode = "ENG101",
                CourseScore = 60,
                CourseUnit = 1
            };

            ICourseRepository repository = new CourseRepository();
            repository.Add(course1);
            repository.Add(course2);

            Calculator calculator = new Calculator();

            double expected = (double)14/3;



            //-- Act
            double actual = calculator.CalculateGPA(repository.GetCourses());

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
