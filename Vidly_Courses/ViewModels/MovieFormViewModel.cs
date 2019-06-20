using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Courses.Models;

namespace Vidly_Courses.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}