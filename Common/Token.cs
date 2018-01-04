using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace AssignMe.Common
{
    public class Token
    {
        //private int userID;
        //private int companyID;
        //private string userName;
        //private string token;
        //private string companyName;
        //private string compMobile;
        //private string userMobile;
        //private string designation;
        //private string about;
        public int userID { get; set; }
        public int companyID { get; set; }
        public string userName { get; set; }
        public string token { get; set; }
        public string companyName { get; set; }
        public string compMobile { get; set; }
        public string userMobile { get; set; }
        public string designation { get; set; }
        public string about { get; set; }

        // Create private instance of token for particular user
        public Token(int userID, int companyID, string userName, string companyName, string compMobile,
                    string userMobile, string designation, string about)
        {
            this.userID = userID;
            this.companyID = companyID;
            this.userName = userName;
            this.companyName = companyName;
            this.compMobile = compMobile;
            this.userMobile = userMobile;
            this.designation = designation;
            this.about = about;
            this.token = generateToken();

            storeInMem(this);
        }
        private static string generateToken()
        {
            // Initialize newToken string type for returning token for user.
            string newToken = "";

            // Create token until we get some in newToken.
            while(newToken == "")
            {
                Guid token = Guid.NewGuid();
                newToken = token.ToString();
            }
            return newToken;
        }

        private static void storeInMem(Token token)
        {
            MemoryCache cache = new MemoryCache("AssignCache");
            cache.Add(token.token.ToString(), token, DateTimeOffset.Now.AddDays(3));            
        }

    }
}