using Microsoft.AspNetCore.Mvc;
using MvcBartender.Data.Interfaces;
using MvcBartender.Data.Models;
using MvcBartender.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBartender.Controllers
{
    public class DrinkController :Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DrinkController(IDrinkRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }
        /*
        public ViewResult List()
        {
            ViewBag.Name = "Tyrone's testApp";

            var drinks = _drinkRepository.Drinks;

            DrinkListViewModel vm = new DrinkListViewModel();

            vm.Drinks = _drinkRepository.Drinks;
            vm.CurrentCategory = "DrinkCategory";
            return View(vm);
        }
        */

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                    drinks = _drinkRepository.Drinks.Where(n => n.Category.CategoryName.Equals("Alcoholic")).OrderBy(n => n.Name);
                else
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            });
        }
        /*
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
            }
            else
            {
                drinks = _drinkRepository.Drinks.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Drink/List.cshtml", new DrinkListViewModel { Drinks = drinks, CurrentCategory = "All drinks" });
        }

        public ViewResult Details(int drinkId)
        {
            var drink = _drinkRepository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
            if (drink == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(drink);
            
        }
        */
    }
}
