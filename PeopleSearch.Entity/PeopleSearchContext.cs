using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Entity
{
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext() : base()
        {
            Database.SetInitializer<PeopleSearchContext>(new DropCreateDatabaseAlways<PeopleSearchContext>());
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
