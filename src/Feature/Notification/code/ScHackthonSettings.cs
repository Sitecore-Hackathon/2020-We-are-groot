namespace ScHackathon.Feature.Notification
{
    public partial class ScHackthonSettings
    {
        private static bool useDefaultCredentials = true;
        /// <summary>
        /// Custom SMTP Configurations
        /// </summary>
        public static string SmtpHost = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SmtpHost") ?? string.Empty;

        public static string SmtpPort = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SmtpPort") ?? string.Empty;

        public static string SmtpUserName = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SmtpUserName") ?? string.Empty;

        public static string SmtpPassword = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SmtpPassword") ?? string.Empty;

        public static bool UseDefaultCredentials = bool.TryParse(Sitecore.Configuration.Settings.GetSetting("ScHackathon.UseDefaultCredentials"), out useDefaultCredentials) ? useDefaultCredentials : true;

        public static string SubscribeConfirmationSettingsPath = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SubscribeConfirmationSettingsPath");

        public static string SubscriptionNotificationSettingsPath = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SubscriptionNotificationSettingsPath");

        public static string SubscriptionConfirmationPage = Sitecore.Configuration.Settings.GetSetting("ScHackathon.SubscriptionConfirmationPage");
    }
}
