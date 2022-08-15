using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BusinessLayer.Concrete
{
    public class AdminManager : GenericServiceManager<Admin>, IAdminService
    {

        private readonly IRepository<Admin> _manager;
        public AdminManager(IRepository<Admin> manager) : base(manager)
        {
            _manager = manager;
        }

        public Admin GetByID(int id)
        {
            return _manager.Get(a => a.AdminID == id);
        }

        public Admin Login(string userName, string password)
        {
            return _manager.List(m => m.AdminName == userName && m.AdminPassword == password).FirstOrDefault();
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}



