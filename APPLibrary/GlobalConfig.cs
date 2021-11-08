using APPDataAccess.Repositories.InMemoryRepository.Implementations;
using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPLibrary.Implementations;
using APPLibrary.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLibrary
{
    public 
    class GlobalConfig
    {
        public IUtilities utilities;
        public ICourseRepository courseRepository;
        public ILogger logger;
        public ICalculator calculator;
        public GlobalConfig()
        {
            courseRepository = new CourseRepository();
            logger = new Logger();
            calculator = new Calculator();
            utilities = new Utilities(courseRepository, logger, calculator);
        }
    }
}
