using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AssignMe.Common;
using AssignMe.Models;

namespace AssignMe.Controllers
{
    #region "Functions"

    [RoutePrefix("api")]
    public class AuthController : ApiController
    {
        [HttpGet, HttpPost, Route("login")]
        public Response authUser(dynamic param)
        {
            if (param == null || param.email == "" || param.password == "")
            {
                return new Response();
            }

            // Create private object for credentials
            loginCredentials authCred = new loginCredentials(Convert.ToString(param.email),
                                                                Convert.ToString(param.password));

            Response resp = authCred.checkForCred();

            return resp;

        }

        [HttpGet, HttpPost, Route("register"), AuthFilter]
        public Response regUser(dynamic param)
        {
            if (param == null || param.email == "" || param.email == null
                    || param.password == "" || param.password == null
                    || param.companyName == "" || param.companyName == null
                    || param.city == "" || param.city == null
                    || param.state == "" || param.state == null
                    || param.mobile == "" || param.mobile == null
                    || param.userName == "" || param.userName == null)
            {
                return new Response();
            }

            // Create private object for credentials
            registerCred regUsr = new registerCred(Convert.ToString(param.userName), Convert.ToString(param.companyName),
                                        Convert.ToString(param.city), Convert.ToString(param.state),
                                        Convert.ToString(param.mobile), Convert.ToString(param.email),
                                        Convert.ToString(param.password));

            Response resp = regUsr.regUser();
            return resp;
        }        
    }

    #endregion

    #region classes

    public class loginCredentials
    {
        private string email;
        private string password;
        private string dcryptPswd;
        public loginCredentials(string email, string password)
        {
            this.email = email;
            this.password = password;
            this.dcryptPswd = password;
        }

        public Response checkForCred()
        {
            var retVal = sql.auth_User("authCheck", new ExtLoginParam { email = this.email, dcryptPswd = this.dcryptPswd });

            if (retVal.error == false)
            {
                return retVal;
            }
            else
            {
                return new Response();
            }

        }
    }

    public class registerCred
    {
        private string userName;
        private string companyName;
        private string city;
        private string state;
        private string mobile;
        private string email;
        private string password;

        public registerCred(string userName, string compName, string city,
                                    string state, string mobile, string email, string password)
        {
            this.userName = userName;
            this.companyName = compName;
            this.city = city;
            this.state = state;
            this.mobile = mobile;
            this.email = email;
            this.password = password;
        }

        public Response regUser()
        {
            var retVal = sql.reg_User("registerUser", new ExtSigninParam
            {
                userName = this.userName,
                companyName = this.companyName,
                city = this.city,
                state = this.state,
                mobile = this.mobile,
                email = this.email,
                dcryptPswd = this.password
            });

            if (retVal.error == false)
            {
                return retVal;
            }
            else
            {
                return new Response();
            }

        }
    }

    #endregion
}
