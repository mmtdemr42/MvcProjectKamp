using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService : IService<Contact>
    {
        Contact GetByID(int id);
        List<Contact> ListOrderByDescending();
    }
}
