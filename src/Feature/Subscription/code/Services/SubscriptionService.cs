using ScHackathon.Feature.Notification.Interfaces;
using ScHackathon.Feature.Subscription.Interfaces;
using ScHackathon.Feature.Subscription.Models;
using ScHackathon.Foundation.xConnect;
using Sitecore.DependencyInjection;
using System;
using EmailArgs = ScHackathon.Feature.Notification.ScHackthonSettings;

namespace ScHackathon.Feature.Subscription.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        protected readonly INotificationService _notificationService;
        public SubscriptionService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        /// <summary>
        /// Subscribe email id to news letter contact list
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public SubscriptionResponseModel Subscribe(string emailId)
        {
            using (XConnectClient client = new XConnectClient(emailId))
            {
                var contact = client.GetOrCreateContact();
                if (contact != null)
                {
                    if (_notificationService.Setup(contact.Id.Value.ToString(), emailId, EmailArgs.SubscribeConfirmationSettingsPath).Send())
                        return new SubscriptionResponseModel { Status = SubscriptionResponseStatus.Success };
                    else
                        return new SubscriptionResponseModel
                        {
                            Message = "Failure Sending Email",
                            Status = SubscriptionResponseStatus.Failed
                        };
                }
                else
                    return new SubscriptionResponseModel
                    {
                        Message = "No Contact Found",
                        Status = SubscriptionResponseStatus.Failed
                    }; 
            }
        }

        /// <summary>
        /// Subscriber confirmation
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public SubscriptionResponseModel ConfirmSubscription(string emailId, string cid)
        {
            var subscriptionService = ServiceLocator.ServiceProvider.GetService(typeof(Sitecore.ListManagement.XConnect.Web.ISubscriptionService)) as Sitecore.ListManagement.XConnect.Web.ISubscriptionService;
            if (subscriptionService != null)
            {
                subscriptionService.Subscribe(Guid.Parse(ScHackathonSettings.NewsLetterContactList), Guid.Parse(cid));

                using (XConnectClient client = new XConnectClient(emailId))
                {
                    var contact = client.GetContact();
                    if (contact != null)
                    {
                        if (_notificationService.Setup(cid, emailId, EmailArgs.SubscriptionNotificationSettingsPath).Send())
                            return new SubscriptionResponseModel { Status = SubscriptionResponseStatus.Success };
                        else
                            return new SubscriptionResponseModel
                            {
                                Message = "Failure Sending Email",
                                Status = SubscriptionResponseStatus.Failed
                            };
                    }
                    else
                        return new SubscriptionResponseModel
                        {
                            Message = "No Contact Found",
                            Status = SubscriptionResponseStatus.Failed
                        };
                }
            }
            else
            {
                return new SubscriptionResponseModel
                {
                    Message = "SubscriptionService Not Initialized",
                    Status = SubscriptionResponseStatus.Failed
                };
            }
        }

        /// <summary>
        /// Unsubscrice email Id from news letter contact list
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool Unsubscribe(string contactId)
        {
            throw new NotImplementedException();
        }

    }
}