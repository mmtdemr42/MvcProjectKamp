using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService : IService<Admin>
    {
        Admin Login(string userName, string password);
        Admin GetByID(int id);
        void LogOut();
    }
}
