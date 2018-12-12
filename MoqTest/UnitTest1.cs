using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqSample.Models;
using Moq;
using System.Collections.Generic;
using MoqSample.Business;
using MoqSample.Controllers;
using System.Linq;
using FluentAssertions;

namespace MoqTest
{
    [TestClass]
    public class UnitTest1
    {
        // Nugets
        // Moq
        // FluentAssertions
        // Microsoft.AspNetCore.Mvc

        private List<Person> GetAll()
        {
            return new List<Person> {
                new Person {
                     FirstName = "Qasim",
                     LastName = "Sheikh",
                     Manager = true
                },
                new Person {
                     FirstName = "Tom",
                     LastName = "Jerry",
                     Manager = false
                }
            };
        }

        [TestMethod]
        public void LoopingPersonTest()
        {            
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.GetAllPeople()).Returns(GetAll());
            var person = new PersonController(repository.Object);
            person.LoopPeron();
            person.Should().NotBeNull();
        }

        [TestMethod]
        public void CheckingSpecificPersonTypeTest()
        {
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.CheckEmployee(true))
                .Returns(GetAll().Where(x => x.Manager == true)
                .FirstOrDefault());

            var person = new PersonController(repository.Object);
            var resp = person.PersonTest(repository.Object.CheckEmployee(true));
            StringAssert.EndsWith(resp, "manager");
        }

    }
}
