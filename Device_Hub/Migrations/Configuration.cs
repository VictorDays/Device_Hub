namespace Device_Hub.Migrations
{
    using Device_Hub.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Device_Hub.App_Data.DeviceHubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true; // Adicione esta linha
        }

        protected override void Seed(Device_Hub.App_Data.DeviceHubContext context)
        {
            
        }
    }
}
