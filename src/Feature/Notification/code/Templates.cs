using Sitecore.Data;
namespace ScHackathon.Feature.Notification
{
    public struct Templates
    {
        public struct HtmlMessage
        {
            public static ID ID = new ID("{ECF0A9C8-FE56-45D8-B750-6BDE3A34A532}");

            public struct Fields
            {
                public static ID Subject = new ID("{8E6B1F0C-1267-4651-BFAA-AFFD48A799EE}");
                public static ID Body = new ID("{89B7628A-3564-4C9A-8116-DCB15F692573}");

                public static string FromName = "From Name";
                public static string FromAddress = "From Address";
            }
        }
    }
}
