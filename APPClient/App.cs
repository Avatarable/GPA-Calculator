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
        public static void Run()
        {

            IUtilities utilities = new Utilities();

            ConsoleSettings();
         

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

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ConsoleSettings()
        {
            Console.Title = "GPA Calculator";
            Console.SetWindowSize(85, 30);
            Console.SetBufferSize(85, 30);

        }
    }
}
