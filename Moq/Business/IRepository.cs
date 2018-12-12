using MoqSample.Models;
using System.Collections.Generic;

namespace MoqSample.Business
{
    public interface IRepository
    {
        Person CheckEmployee(bool manager);
        List<Person> GetAllPeople();
    }
}