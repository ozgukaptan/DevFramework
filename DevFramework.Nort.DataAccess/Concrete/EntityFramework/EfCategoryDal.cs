using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Core.DataAccess.EntityFramework;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.Entities.Concrete;

namespace DevFramework.Nort.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,NortContext> , ICategoryDal
    {
    }
}
