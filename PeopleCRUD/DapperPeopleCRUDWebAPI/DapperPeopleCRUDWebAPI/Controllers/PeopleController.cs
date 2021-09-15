using DapperPeopleCRUDWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperPeopleCRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleRepository peopleRepository;

        public PeopleController()
        {
            peopleRepository = new PeopleRepository();

        }

        [HttpGet]
        public IEnumerable<People> GetAll()
        {
            return peopleRepository.GetAll();
        }

        [HttpGet("{id:int}")]
        public People Get(int id)
        {
            return peopleRepository.GetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] People person)
        {
            if (ModelState.IsValid)
            {
                peopleRepository.Add(person);
            }
        }

        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] People person)
        {
            person.PersonId = id;
            if (ModelState.IsValid)
            {
                peopleRepository.UPDATE(person);
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            peopleRepository.Delete(id);
        }
    }
}
