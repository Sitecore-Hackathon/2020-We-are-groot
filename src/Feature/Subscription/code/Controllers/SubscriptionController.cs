using ScHackathon.Feature.Subscription;
using ScHackathon.Feature.Subscription.Interfaces;
using ScHackathon.Feature.Subscription.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Sitecore.DependencyInjection;

namespace ScHackathon.Feature.Subscription.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController() : this(ServiceLocator.ServiceProvider.GetService(typeof(ISubscriptionService)) as ISubscriptionService)
        {

        }

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Subscribe(string emailId)
        {
            SubscriptionResponseModel subscriptionResponse;
            if (!string.IsNullOrWhiteSpace(emailId) && Regex.IsMatch(emailId, ScHackathonConstants.RegularExpressions.Email, RegexOptions.IgnoreCase))
                subscriptionResponse = _subscriptionService.Subscribe(emailId);
            else
                subscriptionResponse = new SubscriptionResponseModel
                {
                    Status = SubscriptionResponseStatus.InvalidRequest
                };

            return Json(subscriptionResponse);
        }

        /// <summary>
        /// Subscription confirmation action
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ActionResult SubscriptionConfirmation(string eid, string cid)
        {
            SubscriptionResponseModel subscriptionResponse;
            if (Sitecore.Data.ID.IsID(cid))
                subscriptionResponse = _subscriptionService.ConfirmSubscription(eid, cid);
            else
                subscriptionResponse = new SubscriptionResponseModel
                {
                    Status = SubscriptionResponseStatus.InvalidRequest
                };

            return View(subscriptionResponse);
        }
    }
}