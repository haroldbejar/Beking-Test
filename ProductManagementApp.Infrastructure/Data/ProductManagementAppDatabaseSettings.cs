namespace ProductManagementApp.Infrastructure.Data
{
    public class ProductManagementAppDatabaseSettings : IProductManagementAppDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ProductCollection { get; set; } = string.Empty;
    }
}