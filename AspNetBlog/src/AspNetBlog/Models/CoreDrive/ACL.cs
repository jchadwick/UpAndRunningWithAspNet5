using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TieWeb.Models;
using Microsoft.AspNet.Authorization;

namespace TieWeb.Models.CoreDrive
{

    public class ACL
    {
        public ACL(string groupName, string fullName, bool enabled, imNOS nos, imAccessRight right)
        {
            this.groupName = groupName;
            this.fullName = fullName;
            this.enabled = enabled;
            this.nos = nos;
            this.right = right;
        }
        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        private imAccessRight right;

        public imAccessRight Right
        {
            get { return right; }
            set { right = value; }
        }
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        private imNOS nos;

        public imNOS Nos
        {
            get { return nos; }
            set { nos = value; }
        }
    }
}