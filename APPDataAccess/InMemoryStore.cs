using APPModels;
using System;
using System.Collections.Generic;

namespace APPDataAccess
{
    public class InMemoryStore
    {
        public static List<Course> Courses { get; set; } = new List<Course>();
    }
}
