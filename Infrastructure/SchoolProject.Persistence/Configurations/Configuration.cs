
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace SchoolProject.Persistence.Configurations
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SchoolProject.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MsSql");
            }
        }
    }
}

