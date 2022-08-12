using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService : IService<Content>
    {
        Content GetByID(int id);
        List<Content> GetByHeadingID(int id);
        List<Content> GetByWriterID(int id);
        List<Content> GetByWriterContent(int id);

    }
}
