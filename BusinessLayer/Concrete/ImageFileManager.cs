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
    public class ImageFileManager : GenericServiceManager<ImageFile>, IImageFileService
    {
        private readonly IRepository<ImageFile> _manager;
        public ImageFileManager(IRepository<ImageFile> manager) : base(manager)
        {
            _manager = manager;
        }
    }
}
