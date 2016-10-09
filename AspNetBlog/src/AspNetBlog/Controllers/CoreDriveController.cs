using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TieWeb.Controllers
{
    public class CoreDriveController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Models.CoreDrive.iManageServiceWebMock iManage = new Models.CoreDrive.iManageServiceWebMock("server");
            iManage.authenticateUser("admin@admin.com", "password");
            var ws = iManage.searchWorkSpaces("");

            return View(ws);
        }

        public IActionResult GetWorkspace(long id)
        {
            Models.CoreDrive.iManageServiceWebMock iManage = new Models.CoreDrive.iManageServiceWebMock("server");
            iManage.authenticateUser("admin@admin.com", "password");
            var ws = iManage.getWorkSpace(id);

            return View(ws);
        }

        public IActionResult GetWorkspaces()
        {
            Models.CoreDrive.iManageServiceWebMock iManage = new Models.CoreDrive.iManageServiceWebMock("server");
            iManage.authenticateUser("admin@admin.com", "password");
            var ws = iManage.searchWorkSpaces("");

            return View(ws);
        }
    }
}
