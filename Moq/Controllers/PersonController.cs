using Microsoft.AspNetCore.Mvc;
using MoqSample.Business;
using MoqSample.Models;

namespace MoqSample.Controllers
{
    public class PersonController : Controller
    {
        private readonly IRepository _repository;

        public PersonController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index(bool type)
        {   
            if (type)
            {
                var resp = _repository.CheckEmployee(type);
                return View(resp);
            }
            return View();            
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
                ViewBag.Message = PersonTest(person);

            return View(person);
        }

        public void LoopPeron()
        {
            var people = _repository.GetAllPeople();
            foreach (var person in people)
            {
                string name = person.FirstName;
            }
        }

        public string PersonTest(Person person)
        {
            if (person.Manager)
                return $"{person.FirstName} {person.LastName} is a manager";
            else 
                return $"{person.FirstName} {person.LastName} is not a manager";
        }

    }
}