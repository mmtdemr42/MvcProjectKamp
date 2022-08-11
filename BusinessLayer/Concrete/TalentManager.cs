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
    public class TalentManager : GenericServiceManager<Talent>, ITalentService
    {
        private readonly IRepository<Talent> _manager;
        public TalentManager(IRepository<Talent> manager) : base(manager)
        {
            _manager = manager;
        }
    }
}
