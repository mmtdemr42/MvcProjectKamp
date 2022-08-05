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
    public class WriterManager : GenericServiceManager<Writer>, IWriterService
    {
        private IRepository<Writer> _manager;
        public WriterManager(IRepository<Writer> manager) : base(manager)
        {
            _manager = manager;
        }
    }
}
