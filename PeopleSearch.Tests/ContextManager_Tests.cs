using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class ContextManager_Tests
    {
        [TestMethod]
        public void ContextManager_CanInsert()
        {
            using (var context = new ContextManager())
            {
                var expectedID = Guid.NewGuid();

                var person = new Person();
                person.PersonId = expectedID;

                //attempt to save the person
                var newPerson = context.Save<Person>(person);

                //attempt to retrieve saved person
                var savedPerson = context.Get<Person>(x => x.PersonId == expectedID);

                Assert.IsNotNull(savedPerson);
            }
        }

        [TestMethod]
        public void ContextManager_CanUpdate()
        {
            using (var context = new ContextManager())
            {
                var expectedID = Guid.NewGuid();
                var expectedFirstName = "New Test Name";

                var person = new Person();
                person.PersonId = expectedID;
                person.FirstName = "Test";
                person.LastName = "Person";

                //attempt to save the person
                context.Save<Person>(person);

                //now update that user with the same id
                person.FirstName = expectedFirstName;
                context.Save<Person>(person, x => x.PersonId == expectedID);

                //attempt to retrieve saved person
                var savedPerson = context.Get<Person>(x => x.PersonId == expectedID);

                Assert.AreEqual(savedPerson.FirstName, expectedFirstName);
            }
        }
    }
}
