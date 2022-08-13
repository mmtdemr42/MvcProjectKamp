using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService : IService<Heading>
    {
        int CategoryHeadingCount(int id);
        int HeadingFilter(string s);
        Heading GetByID(int id);
        List<Heading> GetByHeadingsTrue(int id);
        List<Heading> GetBySearchHeadings(string value);
    }
}
