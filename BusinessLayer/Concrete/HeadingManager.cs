using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : GenericServiceManager<Heading>, IHeadingService
    {
        private readonly IRepository<Heading> _headingDal;

        public HeadingManager(IRepository<Heading> manager) : base(manager)
        {
            _headingDal = manager;
        }


        public int CategoryHeadingCount(int id)
        {
            return _headingDal.List().Where(h => h.CategoryID == id).Count();
        }


        public Heading GetByID(int id)
        {
            return _headingDal.Get(h => h.HeadingID == id);
        }


        public int HeadingFilter(string s)
        {
            return _headingDal.List().Where(h => h.HeadingName.ToUpper().Contains(s)).Count();
        }
    }
}
