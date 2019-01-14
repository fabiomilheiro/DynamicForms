using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Routing;
using DynamicForms.Common.Infrastructure.Constants;
using DynamicForms.Common.Infrastructure.Extensions;

namespace DynamicForms.Common.Infrastructure.Helpers
{
    public interface IRequestWrapper
    {
        string RetrieveApplicationId();

        string RetrieveApplicationFormID();

        int? RetrieveApplicationFormVersionID();

        int RetrieveCurrentStepNumber();

        ClientType RetrieveClientType();
        IDictionary RetrieveItems();
    }

    public class RequestWrapper : IRequestWrapper
    {

        public string RetrieveApplicationId()
        {
            return RetrieveQueryString()[QueryStringParameters.ApplicationID];
        }

        public string RetrieveApplicationFormID()
        {
            return RetrieveRouteValues()[RouteParameters.ApplicationFormID] as string;
        }

        public int? RetrieveApplicationFormVersionID()
        {
            var versionID = RetrieveRouteValues()[RouteParameters.ApplicationFormVersionID] as string;

            if (string.IsNullOrEmpty(versionID))
            {
                return null;
            }

            return versionID.ToInteger();
        }

        public int RetrieveCurrentStepNumber()
        {
            return (RetrieveRouteValues()[RouteParameters.CurrentStepNumber] as string).ToInteger();
        }

        private static NameValueCollection RetrieveQueryString()
        {
            return HttpContext.Current.Request.QueryString;
        }

        private static RouteValueDictionary RetrieveRouteValues()
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values;
        }

        public ClientType RetrieveClientType()
        {
            var clientTypeQueryStringValue = HttpContext.Current.Request.QueryString["clientType"];
            ClientType result;

            if (Enum.TryParse(clientTypeQueryStringValue, true, out result))
            {
                return result;
            }

            return ClientType.Partner;
        }

        public IDictionary RetrieveItems()
        {
            return HttpContext.Current.Items;
        }
    }

    public enum ClientType
    {
        InternalApplicationForms,
        Partner
    }
}