using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApplicationFormAutomation.WebUI.App_Start
{
    public static class EntityFrameworkConfig
    {
        public static DbContextOptionsBuilder Get(IConfigurationRoot configuration, 
            DbContextOptionsBuilder options)
        {
            return options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        }
    }
}
