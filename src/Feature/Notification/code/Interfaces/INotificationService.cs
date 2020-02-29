
namespace ScHackathon.Feature.Notification.Interfaces
{
    public interface INotificationService
    {
        INotificationService Setup(string cid, string emailId, string settingsPath);
        bool Send();
    }
}
