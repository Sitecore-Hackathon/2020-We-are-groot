using System;
using System.Web;

namespace ScHackathon.Feature.Notification.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns default value if the string is null or empty
        /// </summary>
        /// <param name="text">String to check for NULL and Empty</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static T IfEmpty<T>(this string text, T defaultValue)
        {
            if (string.IsNullOrWhiteSpace(text))
                return defaultValue;
            else
                return (T)Convert.ChangeType(text, typeof(T));
        }

        /// <summary>
        /// Replaces tokens in email content
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceTokens(this string text, string cid, string emailId)
        {
            var url = HttpContext.Current.Request.Url;
            var confirmationLink = $"{url.Scheme}://{url.Host}{ScHackthonSettings.SubscriptionConfirmationPage}";

            return text.Replace("$link$", string.Format(confirmationLink, cid, emailId));
        }
    }
}
