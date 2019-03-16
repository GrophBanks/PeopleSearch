using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Models
{
    public class AddPersonModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
        public string Interests { get; set; }
    }
}