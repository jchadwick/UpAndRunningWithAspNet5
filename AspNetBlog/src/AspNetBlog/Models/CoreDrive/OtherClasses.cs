using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TieWeb.Models;
using Microsoft.AspNet.Authorization;

namespace TieWeb.Models.CoreDrive
{
    public enum imSecurityType
    {
        imPublic = 80,
        imView = 86,
        imPrivate = 88,
    }

    public enum imNOS
    {
        imOSNovell = 1,
        imOSVirtual = 2,
        imOSNT = 3,
        imOSNovellNDS = 4,
        imOSExternal = 5,
        imOSNTADS = 6,
        imOSNetscapeDS = 7,
    }
    public enum imAccessRight
    {
        imRightNone = 0,
        imRightRead = 1,
        imRightReadWrite = 2,
        imRightAll = 3,
    }
}
