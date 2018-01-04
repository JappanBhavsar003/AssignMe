using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignMe.Models
{
    public class ExtSigninParam
    {
        public string userName { get; set; }
        public string companyName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string dcryptPswd { get; set; }
    }
}