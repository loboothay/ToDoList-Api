namespace Api_ToDoMongo.Data.Configurations
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}