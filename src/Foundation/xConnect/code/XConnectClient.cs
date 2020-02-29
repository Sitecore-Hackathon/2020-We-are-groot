using System;
using Sitecore.Diagnostics;
namespace ScHackathon.Foundation.xConnect
{
    using Sitecore.XConnect;
    using Sitecore.XConnect.Client;
    using Sitecore.XConnect.Collection.Model;

    public class XConnectClient : IDisposable
    {
        private readonly Sitecore.XConnect.Client.XConnectClient _client;
        private readonly string _contactIdentifier;

        public XConnectClient(string contactIdentifier)
        {
            _client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient();
            _contactIdentifier = contactIdentifier;
        }

        public Contact GetOrCreateContact()
        {
            if (!IsContactExists())
                AddContact();

            return GetContact();
        }

        /// <summary>
        /// Adds contact in xDb
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public bool AddContact()
        {
            try
            {
                var contact = new Contact(new ContactIdentifier(ScHackathonConstants.IdentifierSources.SubscriptionList, _contactIdentifier, ContactIdentifierType.Known));
                _client.SetEmails(contact, new EmailAddressList(new EmailAddress(_contactIdentifier, false), "Preferred"));
                _client.AddContact(contact);
                _client.Submit();
                return true;
            }
            catch (XdbExecutionException xe)
            {
                Log.Error($"Failed to Add Contact: {_contactIdentifier}", xe, this);
                return false;
            }
            catch (Exception e)
            {
                Log.Error($"Failed to Add Contact: {_contactIdentifier}", e, this);
                return false;
            }
        }

        /// <summary>
        /// Checks if contact exists in xDb
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public bool IsContactExists()
        {
            try
            {
                return _client.GetContactAsync(new IdentifiedContactReference(ScHackathonConstants.IdentifierSources.SubscriptionList, _contactIdentifier), new ContactExpandOptions { }).Result != null;
            }
            catch (Exception e)
            {
                Log.Error($"Failed to Check Contact Existance in xDb: {_contactIdentifier}", e, this);
                return false;
            }
        }

        /// <summary>
        /// Gets contact from xDB
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public Contact GetContact()
        {
            try
            {
                return _client.GetContactAsync(new IdentifiedContactReference(ScHackathonConstants.IdentifierSources.SubscriptionList, _contactIdentifier), new ContactExpandOptions { }).Result;
            }
            catch (Exception e)
            {
                Log.Error($"Failed to Get Contact from xDb: {_contactIdentifier}", e, this);
                return null;
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
