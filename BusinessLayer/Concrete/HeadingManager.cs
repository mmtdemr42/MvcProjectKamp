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
    public class HeadingManager :  IHeadingService
    {
        private readonly IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public int CategoryHeadingCount(int id)
        {
            return _headingDal.List().Where(h=>h.CategoryID==id).Count();
        }

        public int HeadingFilter(string s)
        {
            return _headingDal.List().Where(h => h.HeadingName.ToUpper().Contains(s)).Count();
        }

        
    }
}
