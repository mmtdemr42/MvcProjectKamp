using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : GenericServiceManager<Contact>, IContactService
    {
        private readonly IRepository<Contact> _manager;
        public ContactManager(IRepository<Contact> manager) : base(manager)
        {
            _manager = manager;
        }

        public Contact GetByID(int id)
        {
            return _manager.Get(c => c.ContactID == id);
        }

        public List<Contact> ListOrderByDescending()
        {
            return _manager.List().OrderByDescending(m => m.ContactDate).ToList();
        }
    }
}
