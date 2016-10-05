using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TieWeb.Models;
using Microsoft.AspNet.Authorization;

namespace TieWeb.Models.CoreDrive
{

    public class CoreDriveWorkspace
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string issueName;

        public string IssueName
        {
            get { return issueName; }
            set { issueName = value; }
        }
        private string refNumber;

        public string RefNumber
        {
            get { return refNumber; }
            set { refNumber = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string workCategory;

        public string WorkCategory
        {
            get { return workCategory; }
            set { workCategory = value; }
        }
        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string complianceOrgUnit;

        public string ComplianceOrgUnit
        {
            get { return complianceOrgUnit; }
            set { complianceOrgUnit = value; }
        }
        private string legalEntity;

        public string LegalEntity
        {
            get { return legalEntity; }
            set { legalEntity = value; }
        }
        private string lob;

        public string Lob
        {
            get { return lob; }
            set { lob = value; }
        }
        private string relatedIssue;

        public string RelatedIssue
        {
            get { return relatedIssue; }
            set { relatedIssue = value; }
        }
        private string branch;

        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        private string costCenter;

        public string CostCenter
        {
            get { return costCenter; }
            set { costCenter = value; }
        }
        private imSecurityType confidential;

        public imSecurityType Confidential
        {
            get { return confidential; }
            set { confidential = value; }
        }
        private bool paperFile;

        public bool PaperFile
        {
            get { return paperFile; }
            set { paperFile = value; }
        }

        public List<ACL> GACLs = new List<ACL>();


    }
}