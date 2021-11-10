using System;
using System.Collections.Generic;
using System.Text;
using APPLibrary;
using APPDataAccess;
using APPDataAccess.Repositories.InMemoryRepository;
using APPDataAccess.Repositories;
using APPModels;
using System.IO;

namespace APPClient
{
    static class App
    {
        public static IUtilities utilities;
        public static void Run()
        {
            GlobalConfig global = new GlobalConfig();
            ConsoleSettings();

            utilities = global.utilities;
            var path = global.savePath;

            var info = new FileInfo(path);
            if (info.Length > 0)
            {
                var option = utilities.GetStartOption();
                if (option == "1")
                {
                    utilities.LoadCourses();
                }
                else if(option == "2")
                {
                    global.courseFileRepository.Reset();
                }
                else if(option == "3")
                {
                    Environment.Exit(0);
                }
            }



            while (true)
            {
                Console.Clear();
                string option = utilities.GetUserOption();
                if (option == "1")
                {
                    utilities.AddCourse();
                }
                else if (option == "2")
                {
                    utilities.ViewGPA();
                }
                else if (option == "3")
                {
                    utilities.ResetRecords();
                }
                else if (option == "4")
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();                
            }
        }

        public static void ConsoleSettings()
        {
            Console.Title = "GPA Calculator";
            Console.SetWindowSize(75, 30);
            Console.SetBufferSize(75, 30);

        }
    }
}
