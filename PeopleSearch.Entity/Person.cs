using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(255)]
        public String FirstName { get; set; }
        [MaxLength(255)]
        public String LastName { get; set; }
        public int? Age { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(1000)]
        public string ImageURL { get; set; }
        [MaxLength(1000)]
        public string Interests { get; set; }
    }
}
