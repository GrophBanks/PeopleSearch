using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Entity
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? PersonId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
        public string Interests { get; set; }
    }
}
