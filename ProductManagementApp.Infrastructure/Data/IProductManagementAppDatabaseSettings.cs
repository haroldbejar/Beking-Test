namespace ProductManagementApp.Infrastructure.Data
{
    public interface IProductManagementAppDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ProductCollection { get; set; }
    }
}