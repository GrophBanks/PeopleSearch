using AutoMapper;
using Newtonsoft.Json;
using PeopleSearch.Business.Services;
using PeopleSearch.Entity;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PeopleSearch.Controllers
{
    public class SearchController : ApiController
    {
        [ActionName("SearchAction")]
        [HttpGet]
        public IHttpActionResult index(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return BadRequest("Invalid search string");
            }

            using (var personService = new PersonService())
            {
                var searchResults = personService.Search(searchString);

                return Ok(JsonConvert.SerializeObject(searchResults));
            }
        }

        [Route("api/Search/Add")]
        [HttpPost]
        public IHttpActionResult AddPerson(AddPersonModel person)
        {
            using (var personService = new PersonService())
            {
                var mappedPerson = Mapper.Map<AddPersonModel, Person>(person);

                var newPerson = personService.Add(mappedPerson);

                var serializedPerson = JsonConvert.SerializeObject(newPerson);

                if (newPerson == null)
                {
                    return BadRequest("Unable to add person.");
                }
                else
                {
                    return Ok(serializedPerson);
                }
            }
        }
    }
}
