namespace Api_ToDoMongo.Data.Configurations
{
    public interface IDatabaseConfiguration
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}