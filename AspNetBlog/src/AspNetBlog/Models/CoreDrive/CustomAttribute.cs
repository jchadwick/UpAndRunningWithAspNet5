using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TieWeb.Models;
using Microsoft.AspNet.Authorization;

namespace TieWeb.Models.CoreDrive
{
    public class CustomAttribute
    {


        public CustomAttribute(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}