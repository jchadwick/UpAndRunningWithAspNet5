using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TieWeb.Models;
using Microsoft.AspNet.Authorization;

namespace TieWeb.Models.CoreDrive
{
    public class iManageUser
    {
        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public iManageUser(string userID, string userName)
        {
            this.userID = userID;
            this.userName = userName;
        }
    }
}