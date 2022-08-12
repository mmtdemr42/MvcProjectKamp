using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IWriterService : IService<Writer>
    {
        Writer GetByID(int id);
        Writer Login(string email, string password);
        int GetWriter(string email);
    }
}
