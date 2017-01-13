using System.Collections.Generic;
using System.Linq;

namespace RepoPattern
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IList<Person> _personslist;

        public PersonRepository()
        {
            _personslist = new List<Person>
                           {
                               new Person
                               {
                                   FirstName = "Test",
                                   LastName = "User",
                                   Id = 1
                               },
                               new Person
                               {
                                   FirstName = "Eric",
                                   LastName = "Zhao",
                                   Id = 2
                               }
                           };
        }

        public Person GetPerson(int personId)
        {
            return _personslist.FirstOrDefault(person => person.Id == personId);
        }
    }
}