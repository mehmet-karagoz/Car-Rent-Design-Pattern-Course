namespace CarRenting.Host
{
    public class ExceptionHandlingMiddleware 
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                
                var response = context.Response;
                response.ContentType= "application/text";

                await response.WriteAsync(ex.Message);
            }
        }
    }





}
