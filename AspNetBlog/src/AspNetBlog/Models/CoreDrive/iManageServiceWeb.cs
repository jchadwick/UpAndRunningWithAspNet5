//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Mvc;
//using AspNetBlog.Models;
//using Microsoft.AspNet.Authorization;
////using log4net;

//namespace AspNetBlog.Models.CoreDrive
//{
//    public class iManageServiceWeb
//    {
//        //ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        private IManDMS dms = null;
//        private IManDatabase db = null;
//        private IManSession mySession = null;
//        private WorkspaceGenerator.ServerSetting server = null;
//        private iManageUser user = null;
//        //Initialize worksite dlls, and login to database
//        public iManageServiceWeb(WorkspaceGenerator.ServerSetting server)
//        {

//            //log.Debug("Starting Application.");
//            this.server = server;
//        }

//        public iManageUser authenticateUser()
//        {
//            return authenticateUser("", "");

//        }
//        public iManageUser authenticateUser(string userName, string userPassword)
//        {
//            initialize(userName, userPassword);
//            if (mySession.Connected)
//            {
//                user = new iManageUser(mySession.UserID, mySession.Alias);
//            }
//            return user;
//        }
//        private bool initialize(string userName, string userPassword)
//        {

//            log.Debug("Intializing DMS with Server Configuration " + server.name);
//            bool res = false;
//            //Create an object of the ManDMS class.
//            //This object represents the DMS server itself.
//            //Establish a connection to the specified WorkSite DMS Server.
//            //Authenticate the connection to the server
//            try
//            {
//                dms = new ManDMS();
//                mySession = dms.Sessions.Add(server.dmsServer);
//                try
//                {
//                    if (string.IsNullOrEmpty(userName))
//                        mySession.TrustedLogin();
//                    else
//                    {
//                        mySession.Login(userName, userPassword);
//                    }
//                }
//                catch (Exception ex)
//                { }

//                if (mySession.Connected)
//                {
//                    //log.Debug("Successfully logged in to DMS" + mySession.UserID);
//                    IManDatabases dbs = mySession.Databases;

//                    foreach (IManDatabase item in dbs)
//                    {
//                        if (item.Name.Equals(server.dmsDatabase, StringComparison.CurrentCultureIgnoreCase))
//                        {
//                            db = item;
//                            break;
//                        }
//                    }
//                    if (db == null)
//                    {
//                        //log.Error("Database " + server.dmsDatabase + " doesn't exist on server " + server.dmsServer);
//                        return false;
//                    }
//                    dbs = null;
//                    return true;
//                }
//                else
//                {
//                    //log.Debug("failed to login toDMS");
//                    return false;
//                }

//            }
//            catch (Exception e)
//            {
//                //log.Error("Error initializing dms. Error: " + e.Message);
//            }
//            return res;
//        }

//        public int getWorkSpace(int workspaceID, out CoreDriveWorkspace cdWS)
//        {
//            cdWS = null;
//            if (!mySession.Connected)
//            {
//                //logout
//                return Global.ERROR_NOT_AUTHENTICATED;
//            }

//            IManProfileSearchParameters oProfParams = dms.CreateProfileSearchParameters();
//            IManWorkspaceSearchParameters oWspParams = dms.CreateWorkspaceSearchParameters();
//            oWspParams.Add(imFolderAttributeID.imFolderID, workspaceID.ToString());

//            //search
//            IManFolders wsResults;
//            wsResults = db.SearchWorkspaces(oProfParams, oWspParams);
//            if (!wsResults.Empty)
//            {
//                IManWorkspace ws = (IManWorkspace)wsResults.ItemByIndex(1);
//                cdWS = new CoreDriveWorkspace();
//                cdWS.Id = ws.WorkspaceID;
//                cdWS.IssueName = ws.Name;
//                cdWS.RefNumber = ""; //TODO: where is refNo
//                cdWS.WorkCategory = ""; //TODO
//                cdWS.CreateDate = ws.CreationDate;
//                cdWS.Type = ws.GetAttributeValueByID(imProfileAttributeID.imProfileCustom3);
//                cdWS.Status = "";//TODO: where is status
//                cdWS.ComplianceOrgUnit = ws.GetAttributeValueByID(imProfileAttributeID.imProfileCustom4);
//                cdWS.LegalEntity = ""; //TODO
//                cdWS.Lob = ws.GetAttributeValueByID(imProfileAttributeID.imProfileCustom1);
//                cdWS.RelatedIssue = ""; //TODO
//                cdWS.Branch = ""; //TODO
//                cdWS.CostCenter = ""; //TODO
//                cdWS.Confidential = (imSecurityType)ws.Security.DefaultVisibility;
//                cdWS.PaperFile = true; //TODO

//                IManSecurity sec = ws.Security;
//                IManGroupACLs gACLs = sec.GroupACLs;
//                foreach (IManGroupACL item in gACLs)
//                {
//                    cdWS.GACLs.Add(new ACL(item.Group.Name, item.Group.FullName, item.Group.Enabled, (imNOS)item.Group.NOS, (imAccessRight)item.Right));
//                }

//            }
//            else
//            {
//                return Global.NOT_FOUND;
//            }

//            return Global.NO_ERROR;
//        }
//        public int searchWorkSpaces(string value, out CoreDriveWorkspace[] workSpaces)
//        {
//            workSpaces = null;

//            if (!mySession.Connected)
//            {
//                //logout
//                return Global.ERROR_NOT_AUTHENTICATED;
//            }

//            IManProfileSearchParameters oProfParams = dms.CreateProfileSearchParameters();
//            IManWorkspaceSearchParameters oWspParams = dms.CreateWorkspaceSearchParameters();
//            oWspParams.Add(imFolderAttributeID.imFolderName, value);

//            //search
//            IManFolders wsResults;
//            wsResults = db.SearchWorkspaces(oProfParams, oWspParams);
//            if (!wsResults.Empty)
//            {
//                workSpaces = new CoreDriveWorkspace[wsResults.Count];
//                for (int i = 0; i <= wsResults.Count - 1; i++)
//                {
//                    IManWorkspace ws = (IManWorkspace)wsResults.ItemByIndex(i + 1);
//                    CoreDriveWorkspace cdWS = new CoreDriveWorkspace();
//                    cdWS.Id = ws.WorkspaceID;
//                    cdWS.IssueName = ws.Name;
//                    cdWS.RefNumber = "";
//                    cdWS.Type = ws.GetAttributeValueByID(imProfileAttributeID.imProfileCustom3);
//                    cdWS.Lob = ws.GetAttributeValueByID(imProfileAttributeID.imProfileCustom1);
//                    cdWS.ComplianceOrgUnit = ws.GetAttributeValueByID(imProfileAttributeID.imProfileCustom4);
//                    cdWS.Confidential = (imSecurityType)ws.Security.DefaultVisibility;
//                    workSpaces[i] = cdWS;
//                }
//            }

//            return Global.NO_ERROR;

//        }
//        public string getWorkSpaces()
//        {
//            string ret = "";
//            foreach (IManWorkspace ws in db.Workspaces)
//            {
//                ret += ws.Name + "/n";
//            }
//            return ret;
//        }

//        public List<ACL> searchSecurityGroups(string value)
//        {
//            List<ACL> GACLs = new List<ACL>();
//            IManGroups memGroups = db.SearchGroups(value, imSearchAttributeType.imSearchBoth, true);
//            if (memGroups != null)
//            {

//                foreach (IManGroup item in memGroups)
//                {

//                    GACLs.Add(new ACL(item.Name, item.FullName, item.Enabled, (imNOS)item.NOS, imAccessRight.imRightNone));
//                }
//            }
//            return GACLs;
//        }

//        public List<CustomAttribute> getWorkCategories(string value)
//        {
//            List<CustomAttribute> ret = new List<CustomAttribute>();
//            IManCustomAttributes results = db.SearchCustomAttributes(value, imProfileAttributeID.imProfileCustom1, imSearchAttributeType.imSearchBoth, imSearchEnabledDisabled.imSearchEnabledOrDisabled, true);


//            if (results != null && results.Count > 0)
//            {
//                for (int i = 0; i <= results.Count - 1; i++)
//                {
//                    IManCustomAttribute att = results.ItemByIndex(i + 1);
//                    ret.Add(new CustomAttribute(att.ID, att.Name));
//                }
//            }
//            return ret;
//        }

//    }


//}