using DapperLesson.Data;
using DapperLesson.Models;
using DapperLesson.Servises;
using System;
using System.Collections.Generic;

namespace DapperLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConfiguration();
        }
        private static void InitConfiguration()
        {
            ConfigurationService.Init();
        }
    }
}
