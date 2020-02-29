using ScHackathon.Feature.Subscription.Models;

namespace ScHackathon.Feature.Subscription.Interfaces
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Subscribe email id to news letter contact list
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        SubscriptionResponseModel Subscribe(string emailId);

        /// <summary>
        /// Unsubscrice email Id from news letter contact list
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        bool Unsubscribe(string contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        SubscriptionResponseModel ConfirmSubscription(string emailId, string cid);
    }
}
