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
    public class AboutManager : GenericServiceManager<About>, IAboutService
    {
        IRepository<About> _manager;
        public AboutManager(IRepository<About> manager) : base(manager)
        {
            _manager = manager;
        }
    }
}
