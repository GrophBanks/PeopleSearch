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
            Database.SetInitializer(new DBInitializer());
            //Database.SetInitializer<PeopleSearchContext>(new DropCreateDatabaseAlways<PeopleSearchContext>());
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class DBInitializer : DropCreateDatabaseAlways<PeopleSearchContext>
    {
        protected override void Seed(PeopleSearchContext context)
        {
            IList<Person> people = new List<Person>();

            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "George", LastName = "Washington", Interests = "Planter", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Gilbert_Stuart_Williamstown_Portrait_of_George_Washington.jpg/165px-Gilbert_Stuart_Williamstown_Portrait_of_George_Washington.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "John", LastName = "Adams", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/70/John_Adams%2C_Gilbert_Stuart%2C_c1800_1815.jpg/165px-John_Adams%2C_Gilbert_Stuart%2C_c1800_1815.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Thomas", LastName = "Jefferson", Interests = "Planter, Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Thomas_Jefferson_by_Rembrandt_Peale%2C_1800.jpg/165px-Thomas_Jefferson_by_Rembrandt_Peale%2C_1800.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "James", LastName = "Madison", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1d/James_Madison.jpg/165px-James_Madison.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "James", LastName = "Monroe", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/James_Monroe_White_House_portrait_1819.jpg/165px-James_Monroe_White_House_portrait_1819.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "John", LastName = "Adams", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Andrew_jackson_head.jpg/165px-Andrew_jackson_head.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Andrew", LastName = "Jackson", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Andrew_jackson_head.jpg/165px-Andrew_jackson_head.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Martin", LastName = "Buren ", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Martin_Van_Buren_edit.jpg/165px-Martin_Van_Buren_edit.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "William", LastName = "Harrison", Interests = "Soldier", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/William_Henry_Harrison_daguerreotype_edit.jpg/165px-William_Henry_Harrison_daguerreotype_edit.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "John", LastName = "Tyler", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Tyler_Daguerreotype_crop_%28restoration%29.jpg/165px-Tyler_Daguerreotype_crop_%28restoration%29.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "James", LastName = "Polk", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/JKP.jpg/165px-JKP.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Zachary", LastName = "Taylor", Interests = "Soldier", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Zachary_Taylor_restored_and_cropped.jpg/165px-Zachary_Taylor_restored_and_cropped.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Millard", LastName = "Fillmore", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Millard_Fillmore_by_Brady_Studio_1855-65-crop.jpg/165px-Millard_Fillmore_by_Brady_Studio_1855-65-crop.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Franklin", LastName = "Pierce", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Franklin_Pierce_-_Cropped.jpg/165px-Franklin_Pierce_-_Cropped.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "James", LastName = "Buchanan", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fd/James_Buchanan.jpg/165px-James_Buchanan.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Abraham", LastName = "Lincoln", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Abraham_Lincoln_O-77_matte_collodion_print.jpg/165px-Abraham_Lincoln_O-77_matte_collodion_print.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Andrew", LastName = "Johnson", Interests = "Tailor", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Andrew_Johnson_photo_portrait_head_and_shoulders%2C_c1870-1880-Edit1.jpg/165px-Andrew_Johnson_photo_portrait_head_and_shoulders%2C_c1870-1880-Edit1.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Ulysses", LastName = "Grant", Interests = "Soldier", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Ulysses_S_Grant_by_Brady_c1870-restored.jpg/165px-Ulysses_S_Grant_by_Brady_c1870-restored.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Rutherford", LastName = "Hayes", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/50/President_Rutherford_Hayes_1870_-_1880_Restored.jpg/165px-President_Rutherford_Hayes_1870_-_1880_Restored.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "James", LastName = "Garfield", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1f/James_Abram_Garfield%2C_photo_portrait_seated.jpg/165px-James_Abram_Garfield%2C_photo_portrait_seated.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Chester", LastName = "Arthur", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Chester_Alan_Arthur.jpg/165px-Chester_Alan_Arthur.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Grover", LastName = "Cleveland", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Grover_Cleveland_-_NARA_-_518139_%28cropped%29.jpg/165px-Grover_Cleveland_-_NARA_-_518139_%28cropped%29.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Benjamin", LastName = "Harrison", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f8/Benjamin_Harrison%2C_head_and_shoulders_bw_photo%2C_1896.jpg/165px-Benjamin_Harrison%2C_head_and_shoulders_bw_photo%2C_1896.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Grover", LastName = "Cleveland", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Grover_Cleveland_-_NARA_-_518139_%28cropped%29.jpg/165px-Grover_Cleveland_-_NARA_-_518139_%28cropped%29.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "William", LastName = "McKinley", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Mckinley.jpg/165px-Mckinley.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Theodore", LastName = "Roosevelt", Interests = "Author", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1c/President_Roosevelt_-_Pach_Bros.jpg/165px-President_Roosevelt_-_Pach_Bros.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "William", LastName = "Taft", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/William_Howard_Taft%2C_head-and-shoulders_portrait%2C_facing_front.jpg/165px-William_Howard_Taft%2C_head-and-shoulders_portrait%2C_facing_front.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Woodrow", LastName = "Wilson", Interests = "Educator", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Woodrow_Wilson-H%26E.jpg/165px-Woodrow_Wilson-H%26E.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Warren", LastName = "Harding", Interests = "Editor", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Warren_G_Harding-Harris_%26_Ewing.jpg/165px-Warren_G_Harding-Harris_%26_Ewing.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Calvin", LastName = "Coolidge", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/37/Calvin_Coolidge%2C_bw_head_and_shoulders_photo_portrait_seated%2C_1919.jpg/165px-Calvin_Coolidge%2C_bw_head_and_shoulders_photo_portrait_seated%2C_1919.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Herbert", LastName = "Hoover", Interests = "Engineer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/57/President_Hoover_portrait.jpg/165px-President_Hoover_portrait.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Franklin", LastName = "Roosevelt", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/FDR_1944_Color_Portrait.jpg/165px-FDR_1944_Color_Portrait.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Harry", LastName = "Truman", Interests = "Businessman", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Truman_58-766-09.jpg/165px-Truman_58-766-09.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Dwight", LastName = "Eisenhower", Interests = "Soldier", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/President_Eisenhower_Portrait_1959.jpg/165px-President_Eisenhower_Portrait_1959.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "John", LastName = "Kennedy", Interests = "Author", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/John_F._Kennedy%2C_White_House_color_photo_portrait.jpg/165px-John_F._Kennedy%2C_White_House_color_photo_portrait.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Lyndon", LastName = "Johnson", Interests = "Teacher", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/37_Lyndon_Johnson_3x4.jpg/165px-37_Lyndon_Johnson_3x4.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Richard", LastName = "Nixon", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Richard_M._Nixon%2C_ca._1935_-_1982_-_NARA_-_530679.jpg/165px-Richard_M._Nixon%2C_ca._1935_-_1982_-_NARA_-_530679.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Gerald", LastName = "Ford", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Gerald_Ford_presidential_portrait.jpg/165px-Gerald_Ford_presidential_portrait.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Jimmy", LastName = "Carter", Interests = "Businessman", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/JimmyCarterPortrait2.jpg/165px-JimmyCarterPortrait2.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Ronald", LastName = "Reagan", Interests = "Actor", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Official_Portrait_of_President_Reagan_1981.jpg/165px-Official_Portrait_of_President_Reagan_1981.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "George", LastName = "Bush", Interests = "Businessman", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/George_H._W._Bush_crop.jpg/165px-George_H._W._Bush_crop.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Bill", LastName = "Clinton", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Bill_Clinton.jpg/165px-Bill_Clinton.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "George", LastName = "Bush", Interests = "Businessman", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/George-W-Bush.jpeg/165px-George-W-Bush.jpeg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Barack", LastName = "Obama", Interests = "Lawyer", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Official_portrait_of_Barack_Obama.jpg/165px-Official_portrait_of_Barack_Obama.jpg" });
            people.Add(new Person() { PersonId = Guid.NewGuid(), FirstName = "Donald", LastName = "Trump", Interests = "Businessman", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Donald_Trump_official_portrait_%28cropped%29.jpg/165px-Donald_Trump_official_portrait_%28cropped%29.jpg" });

            context.Persons.AddRange(people);

            base.Seed(context);
        }
    }
}
