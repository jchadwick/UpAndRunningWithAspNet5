using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TieWeb.Models;
using Microsoft.AspNet.Authorization;
//using log4net;

namespace TieWeb.Models.CoreDrive
{
    public class iManageServiceWebMock
    {
        Random random = new Random();
        public const int ERROR_NOT_AUTHENTICATED = -1;
        public const int NO_ERROR = 1;
        public const int NOT_FOUND = -2;

        private string _server;
        private bool Connected = false;
        private iManageUser user = null;
        //Initialize worksite dlls, and login to database
        public iManageServiceWebMock(string server)
        {

            //log.Debug("Starting Application.");
            _server = server;
        }

        public iManageUser authenticateUser()
        {
            return authenticateUser("", "");

        }
        public iManageUser authenticateUser(string userName, string userPassword)
        {
            initialize(userName, userPassword);
            if (Connected)
            {
                user = new iManageUser(userName, userName);
            }
            return user;
        }
        private bool initialize(string userName, string userPassword)
        {

            //log.Debug("Intializing DMS with Server Configuration " + server.name);
            bool res = false;
            //Create an object of the ManDMS class.
            //This object represents the DMS server itself.
            //Establish a connection to the specified WorkSite DMS Server.
            //Authenticate the connection to the server
            try
            {
                if(userName.Equals("admin@admin.com") && userPassword.Equals("password"))
                {
                    Connected = true;
                }

                if (Connected)
                {
                    //log.Debug("Successfully logged in to DMS" + mySession.UserID);
                    return true;
                }
                else
                {
                    //log.Debug("failed to login toDMS");
                    return false;
                }

            }
            catch (Exception e)
            {
                //log.Error("Error initializing dms. Error: " + e.Message);
            }
            return res;
        }

        public CoreDriveWorkspace getWorkSpace(long workspaceID)
        {
            CoreDriveWorkspace cdWS = null;
            if (Connected)
            {
                if (workspaceID >= 1 && workspaceID <= 10)
                {
                    int i = 1;

                    cdWS = new CoreDriveWorkspace();
                    cdWS.Id = i;
                    cdWS.IssueName = "Issue " + i;
                    cdWS.RefNumber = "Ref Number " + i; //TODO: where is refNo
                    cdWS.WorkCategory = "Cat" + i; //TODO
                    cdWS.CreateDate = DateTime.Today.AddDays(i * -1);
                    cdWS.Type = "Type";
                    cdWS.Status = "Open";//TODO: where is status
                    cdWS.ComplianceOrgUnit = "Custom4-" + i;
                    cdWS.LegalEntity = "Compliance"; //TODO
                    cdWS.Lob = "Custom-" + i;
                    cdWS.RelatedIssue = "Related issue " + i; //TODO
                    cdWS.Branch = "branch " + i; //TODO
                    cdWS.CostCenter = "CostCenter " + i; //TODO
                    cdWS.Confidential = imSecurityType.imPrivate;
                    cdWS.PaperFile = true; //TODO


                    cdWS.GACLs.Add(new ACL("Administrator", "Administrator Group", true, imNOS.imOSVirtual, imAccessRight.imRightAll));
                    cdWS.GACLs.Add(new ACL("EndUser", "End User Group", true, imNOS.imOSExternal, imAccessRight.imRightRead));

                }
            }

            return cdWS;
        }
        public CoreDriveWorkspace[] searchWorkSpaces(string value)
        {
            CoreDriveWorkspace[] workSpaces = null;

            if (Connected)
            {
                int Count = random.Next(5, 100);
                workSpaces = new CoreDriveWorkspace[Count];
                    for (int i = 0; i <= Count - 1; i++)
                    {
                        CoreDriveWorkspace cdWS = new CoreDriveWorkspace();
                    cdWS.Id = i;
                    cdWS.IssueName = "Issue " + i;
                    cdWS.RefNumber = "Ref Number " + i; //TODO: where is refNo
                    cdWS.Type = "Type";
                    cdWS.ComplianceOrgUnit = "Custom4-" + i;
                    cdWS.Lob = "Custom-" + i;
                        cdWS.Confidential = imSecurityType.imPrivate;
                        workSpaces[i] = cdWS;
                    }
                }
            return workSpaces;

        }
  

        public List<ACL> searchSecurityGroups(string value)
        {
            List<ACL> GACLs = new List<ACL>();
            GACLs.Add(new ACL("Administrator", "Administrator Group", true, imNOS.imOSVirtual, imAccessRight.imRightAll));
            GACLs.Add(new ACL("EndUser", "End User Group", true, imNOS.imOSExternal, imAccessRight.imRightRead));
            GACLs.Add(new ACL("Public", "Public Group", true, imNOS.imOSVirtual, imAccessRight.imRightAll));
            GACLs.Add(new ACL("Department", "Department Group", true, imNOS.imOSExternal, imAccessRight.imRightRead));

            return GACLs;
        }

        public List<CustomAttribute> getWorkCategories(string value)
        {
            List<CustomAttribute> ret = new List<CustomAttribute>();

            for (int i = 1; i <= 5; i++)
                ret.Add(new CustomAttribute("Cat"+i,"Work Category "+i));
            return ret;
        }

    }


}