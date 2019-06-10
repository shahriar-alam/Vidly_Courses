using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Courses.Models;

namespace Vidly_Courses.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}