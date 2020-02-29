
namespace ScHackathon.Feature.Subscription.Models
{
    /// <summary>
    /// Response Model Message
    /// </summary>
    public class SubscriptionResponseModel
    {
        public string Message { get; set; }
        public SubscriptionResponseStatus Status { get; set; }
    }

    /// <summary>
    /// Response Status
    /// </summary>
    public enum SubscriptionResponseStatus
    {
        InvalidRequest,
        Success,
        Failed
    }
}