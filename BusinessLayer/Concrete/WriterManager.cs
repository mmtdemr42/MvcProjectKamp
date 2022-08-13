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
    public class WriterManager : GenericServiceManager<Writer>, IWriterService
    {
        private IRepository<Writer> _manager;
        public WriterManager(IRepository<Writer> manager) : base(manager)
        {
            _manager = manager;
        }

        public Writer GetByID(int id)
        {
            return _manager.Get(w => w.WriterID == id);
        }

        public int GetWriter(string email)
        {
            return _manager.List(w => w.WriterEmail == email).Select(a => a.WriterID).FirstOrDefault();
        }

        public Writer Login(string email, string password)
        {
            return _manager.List(w => w.WriterEmail == email && w.WriterPassword == password).FirstOrDefault();
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
