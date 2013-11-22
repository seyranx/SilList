using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Models.ValueObjects;

using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Classes;


namespace SO.SilList.Manager.Managers
{
    public class EntryStatusTypeStrings
    {
        public const String csPending = "Pending";
        public const String csApprove = "Approved";
        public const String csDecline = "Declined";
    }
}
