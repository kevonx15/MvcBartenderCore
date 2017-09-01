using MvcBartender.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcBartender.Data.Models;

namespace MvcBartender.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyAppDbContext _myAppDbContext;

        public CategoryRepository(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;
        }
        public IEnumerable<Category> Categories => _myAppDbContext.Categories;
    }
}