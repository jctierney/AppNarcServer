namespace AppNarcServer.Context
{
    using MongoDB.Entities;
    using System;

    public class DatabaseContext
    {
        public DatabaseContext()
        {
            string database = Environment.GetEnvironmentVariable("Database");
            string databaseHost = Environment.GetEnvironmentVariable("DatabaseHost");
            int.TryParse(Environment.GetEnvironmentVariable("DatabasePort"), out int databasePort);
            new DB(database, databaseHost, databasePort);
        }
    }
}
