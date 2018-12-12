using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoqSample.Models;

namespace MoqSample.Business
{
    public class Repository : IRepository
    {
        private List<Person> GetAll()
        {
            return new List<Person> {
                new Person {
                     FirstName = "Qasim",
                     LastName = "Sheikh",
                     Manager = true
                },
                new Person {
                     FirstName = "ABC",
                     LastName = "Person",
                     Manager = false
                }
            };
        }

        public List<Person> GetAllPeople()
        {
            return GetAll().ToList();
        }

        public Person CheckEmployee(bool manager)
        {
            return GetAll().Where(x => x.Manager == manager).FirstOrDefault();
        }
    }
}
