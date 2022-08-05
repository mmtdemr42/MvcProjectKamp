using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager :GenericServiceManager<Category>, ICategoryService
    {
        private readonly IRepository<Category> _categoryDal;

        public CategoryManager(IRepository<Category> manager) : base(manager)
        {
            _categoryDal = manager;
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(category => category.CategoryID == id);
        }

      
        public int CategoryCount()
        {
             return _categoryDal.List().Select(c=> new { count= c.CategoryID}).Count();
        }

        public Category MaxCategoryHeading()
        {
           return _categoryDal.List().GroupBy(c => c.Headings).Max().FirstOrDefault();
        }

        public int StatusDifference()
        {
            var a = _categoryDal.List().Where(c => c.CategoryStatus == true).Count();
            return Math.Abs(_categoryDal.List().Count() - a);
        }
    }
}
