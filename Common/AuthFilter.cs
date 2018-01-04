using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Runtime.Caching;

namespace AssignMe.Common
{
    public class AuthFilterAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// read requested header and validated
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string identity = FetchFromHeader(actionContext);

            if (identity == "Found")
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK);
                //return;
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return;
            }
            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// retrive header detail from the request 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        private string FetchFromHeader(HttpActionContext actionContext)
        {
            IEnumerable<string> values = null;

            values = actionContext.Request.Headers.GetValues("authKey");

            if(values.Count() != 0)
            {
                string headerToken =  values.FirstOrDefault();
                MemoryCache cache = new MemoryCache("AssignCache");
                Token cacheToken = (Token)cache[headerToken];
                if(cacheToken == null)
                {
                    return "Found";
                }
            }

            return null;
        }
    }
}