using APPDataAccess.Repositories.InMemoryRepository.Implementations;
using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPDataAccess.Repositories.InFileRepository.Implementations;
using APPDataAccess.Repositories.InFileRepository.Interfaces;
using APPLibrary.Implementations;
using APPLibrary.Interfaces;
using APPModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using APPDataAccess.Repositories;

namespace APPLibrary
{
    public 
    class GlobalConfig
    {
        public IUtilities utilities;
        public ICourseRepository courseRepository;
        public ICourseFileRepository courseFileRepository;
        public ILogger logger;
        public ICalculator calculator;
        public readonly string savePath = @"..\..\..\..\APPDataAccess\InFileStore.txt";
        private readonly string logErrorPath = @"../../../../ErrorLog/errorLog.txt";

        public List<ICRUDRepository> repos;

        public GlobalConfig()
        {
            //courseRepository = new CourseRepository();
            courseFileRepository = new CourseFileRepository(savePath, logErrorPath);

            repos = new List<ICRUDRepository>()
            {
                new CourseRepository(),
                courseFileRepository
            };

            logger = new Logger();
            calculator = new Calculator();
            utilities = new Utilities(repos, logger, calculator, logErrorPath);            
        }
    }
}
