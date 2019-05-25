using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Courses.Models;

namespace Vidly_Courses.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}