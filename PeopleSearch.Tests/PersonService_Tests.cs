using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Business.Services;
using PeopleSearch.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Linq.Expressions;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class PersonService_Tests
    {
        private Mock<ContextManager> context { get; set; }
        private Guid personId => Guid.NewGuid();


        [TestInitialize]
        public void Init()
        {
            context = new Mock<ContextManager>();

            Person testPerson = new Person()
            {
                FirstName = "Test",
                LastName = "Person"
            };
            testPerson.PersonId = personId;

            context.Setup(x => x.Get<Person>(It.IsAny<Expression<Func<Person, bool>>>()))
                .Returns(testPerson);

            context.Setup(x => x.Save<Person>(It.IsAny<Person>(), It.IsAny<Expression<Func<Person, bool>>>()))
                .Returns(testPerson);
        }

        [TestMethod]
        public void PersonService_Save()
        {
            using (var personService = new PersonService(context.Object))
            {
                var newPerson = personService.Add(new Person());

                Assert.IsNotNull(newPerson);
            }
        }

        [TestMethod]
        public void PersonService_FindById()
        {
            using (var personService = new PersonService(context.Object))
            {
                var savedPerson = personService.GetById(personId);

                Assert.IsNotNull(savedPerson);
            }
        }
    }
}
