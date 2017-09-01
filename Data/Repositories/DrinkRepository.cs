using MvcBartender.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcBartender.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcBartender.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly MyAppDbContext _myAppDbContext;

        public DrinkRepository(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;
        }

        public IEnumerable<Drink> Drinks => _myAppDbContext.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks => _myAppDbContext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public Drink GetDrinkById(int drinkId) => _myAppDbContext.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
    }
}
