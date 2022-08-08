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
    public class ContentManager : GenericServiceManager<Content>, IContentService
    {
        private readonly IRepository<Content> _contentDal;

        public ContentManager(IRepository<Content> manager) : base(manager)
        {
            _contentDal = manager;
        }

        public List<Content> GetByHeadingID(int id)
        {
            return _contentDal.List().Where(c => c.HeadingID == id).ToList();
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(c => c.HeadingID == id);
        }
    }
}
