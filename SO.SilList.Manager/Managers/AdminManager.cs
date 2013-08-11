using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;

namespace SO.SilList.Manager.Managers
{
    public class AdminManager : IAdminManager
    {
        public AdminVo get(int adminId)
        {
            using (var db = new MainDb())
            {
                var res = db.admins
                    .FirstOrDefault(p => p.adminId == adminId);
                return res;
            }
        }

        public List<AdminVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.admins
                    .Where(e => isActive == null || e.isActive == isActive)
                    .ToList();

                return list;
            }
        }

        public bool delete(int adminId)
        {
            using (var db = new MainDb())
            {
                var res = db.admins
                     .Where(e => e.adminId == adminId)
                     .Delete();
                return true;
            }
        }

        public AdminVo update(AdminVo input, int? adminId = null)
        {
            using (var db = new MainDb())
            {

                if (adminId == null)
                    adminId = input.adminId;

                var res = db.admins.FirstOrDefault(e => e.adminId == adminId);

                if(res == null) 
                    return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public AdminVo insert(AdminVo input)
        {
            using (var db = new MainDb())
            {

                db.admins.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}
