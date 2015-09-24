using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Services.
        /// </summary>
        /// <returns>List of Services</returns>
        public virtual ServiceResult ListServices()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services";

            return Execute<ServiceResult>(request);
        }

        /// <summary>
        /// Retrieves a Service by Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <returns>Service</returns>
        public virtual Service GetService(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            return Execute<Service>(request);
        }

        /// <summary>
        /// Creates a Service.
        /// </summary>
        /// <param name="friendlyName">Friendly Name for the Service</param>
        /// <returns>A new Service</returns>
        public virtual Service CreateService(string friendlyName)
        {
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services";

            request.AddParameter("FriendlyName", friendlyName);

            return Execute<Service>(request);
        }

        /// <summary>
        /// Updates a Service.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="friendlyName">Friendly Name</param>
        /// <param name="defaultServiceRoleSid">Default Service Role Sid</param>
        /// <param name="defaultChannelRoleSid">Default channel Role Sid</param>
        /// <param name="typingIndicatorTimeout">Typing indicator timeout</param>
        /// <returns>Updated Service</returns>
        public virtual Service UpdateService(string serviceSid, string friendlyName,
            string defaultServiceRoleSid, string defaultChannelRoleSid,
            int typingIndicatorTimeout)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("DefaultServiceRoleSid", defaultServiceRoleSid);
            request.AddParameter("DefaultChannelRoleSid", defaultChannelRoleSid);
            request.AddParameter("TypingIndicatorTimeout", typingIndicatorTimeout);

            return Execute<Service>(request);
        }

        /// <summary>
        /// Deletes a Service identified by Service Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <returns>Service deletion status</returns>
        public virtual DeleteStatus DeleteService(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? 
                DeleteStatus.Success : 
                DeleteStatus.Failed;
        }
    }
}
