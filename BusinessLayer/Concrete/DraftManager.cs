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
    public class DraftManager : GenericServiceManager<Draft>, IDraftService
    {
        private readonly IRepository<Draft> _manager;
        public DraftManager(IRepository<Draft> manager) : base(manager)
        {
            _manager = manager;
        }

        public Draft GetByID(int id)
        {
            return _manager.Get(d => d.DraftID == id);
        }
    }
}
