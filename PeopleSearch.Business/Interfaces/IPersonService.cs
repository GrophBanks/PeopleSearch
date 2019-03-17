using PeopleSearch.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Business
{
    public interface IPersonService
    {
        Person Add(Person person);
        Person GetById(Guid personId);
        List<Person> Search(string searchString);
    }
}
