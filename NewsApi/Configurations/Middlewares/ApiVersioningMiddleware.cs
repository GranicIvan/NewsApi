namespace NewsApi.Configurations.Middlewares
{
    public class ApiVersionErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiVersionErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            // Check for versioning errors (status code 400 and relevant headers)
            if (context.Response.StatusCode == 400 &&
                context.Response.Headers.ContainsKey("api-supported-versions"))
            {
                context.Response.ContentType = "application/json";
                var supportedVersions = context.Response.Headers["api-supported-versions"].ToString();

                var errorResponse = new
                {
                    StatusCode = 400,
                    Message = "The requested API version does not exist.",
                    SupportedVersions = supportedVersions.Split(',')
                };

                // Write the custom response
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
