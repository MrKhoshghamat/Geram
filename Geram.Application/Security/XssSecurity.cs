using Ganss.XSS;

namespace Geram.Application.Security
{
    public static class XssSecurity
    {
        public static string SanitizeText(this string text)
        {
            var sanitize = new HtmlSanitizer()
            {
                AllowedTags = { "p" },
                AllowDataAttributes = true
            };

            return sanitize.Sanitize(text);
        }
    }
}
