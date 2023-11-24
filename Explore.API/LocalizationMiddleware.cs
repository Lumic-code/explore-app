using System.Globalization;

namespace Explore.API
{
    public class LocalizationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var cultureKey = context.Request.Headers["Accept-Language"];
            if (!string.IsNullOrEmpty(cultureKey))
            {
                if (DoesCultureExist(cultureKey))
                {
                    var culture = new CultureInfo(cultureKey);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
            await next(context);
        }

        private bool DoesCultureExist(string cultureKey)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Any(c => c.Name.Equals(cultureKey, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
