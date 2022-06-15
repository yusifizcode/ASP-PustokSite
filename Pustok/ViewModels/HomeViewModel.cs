using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class HomeViewModel
    {
        public List<HomeSlider> HomeSliders;
        public List<HomeFeature> HomeFeatures;
        public List<Book> NewBooks;
        public List<Book> DiscountedBooks;
        public List<Book> FeaturedBooks;
    }
}
