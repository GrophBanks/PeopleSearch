using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleSearch.Entity;

namespace PeopleSearch.Business.Services
{
    public class PersonService : IPersonService, IDisposable
    {
        private IContextManager context { get; set; }

        #region constructors
        public PersonService()
        {
            context = new ContextManager();
        }

        public PersonService(IContextManager context)
        {
            this.context = context;
        }
        #endregion

        /// <summary>
        /// Adds a new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Person Add(Person person)
        {
            person.PersonId = (person.PersonId == null ? Guid.NewGuid() : person.PersonId);

            var newPerson = context.Save<Person>(person);

            return newPerson;
        }

        /// <summary>
        /// Finds a person by the provided person ID
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Person GetById(Guid personId)
        {
            return context.Get<Person>(x => x.PersonId == personId);
        }

        public List<Person> Search(string searchString)
        {
            return context.GetList<Person>(x => x.LastName.Contains(searchString));
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
