namespace NewsApi.Configurations.Extensions
{
    public static class JsonOptionsExtensions
    {

        public static void AddCustomJsonOptions(this IServiceCollection services)
        {
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

        }
    }
}
