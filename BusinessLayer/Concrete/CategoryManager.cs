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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(category => category.CategoryID == id);
        }

        public List<Category> GetCategories()
        {
            return _categoryDal.List();
        }

        public int CategoryCount()
        {
             return _categoryDal.List().Select(c=> new { count= c.CategoryID}).Count();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
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
