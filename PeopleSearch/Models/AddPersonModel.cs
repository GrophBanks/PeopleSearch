using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeopleSearch.Models
{
    public class AddPersonModel
    {
        [MaxLength(255)]
        public String FirstName { get; set; }
        [MaxLength(255)]
        public String LastName { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(1000)]
        public string ImageURL { get; set; }
        [MaxLength(1000)]
        public string Interests { get; set; }
        public int delay { get; set; }
    }
}