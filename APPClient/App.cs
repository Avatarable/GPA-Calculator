using System;
using System.Collections.Generic;
using System.Text;
using APPLibrary;
using APPDataAccess;
using APPDataAccess.Repositories.InMemoryRepository;
using APPDataAccess.Repositories;
using APPModels;

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

            while (true)
            {
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
                Console.Clear();
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
