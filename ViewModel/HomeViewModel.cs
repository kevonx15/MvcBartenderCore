using MvcBartender.Data.Models;
using System.Collections.Generic;

namespace MvcBartender.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }
    }
}
