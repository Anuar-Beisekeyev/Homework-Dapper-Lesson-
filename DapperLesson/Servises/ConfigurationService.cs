using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DapperLesson.Servises
{
    public static class ConfigurationService
    {
        public static IConfiguration Configuration { get; set; }
        public static void Init()
        {
            if (DbProviderFactories.GetFactory("DapperLessonProvider") == null)
            {
                DbProviderFactories.RegisterFactory("DapperLessonProvider", SqlClientFactory.Instance);
            }
            if (Configuration == null)
            {
                var configuratonBuilder = new ConfigurationBuilder();
                var configuration = configuratonBuilder.AddJsonFile("appSetting.json").Build();
            }
        }
    }
}
