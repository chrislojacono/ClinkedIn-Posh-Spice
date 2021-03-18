using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using ClinkedIn.DataAccess;

namespace ClinkedIn.Controllers
{
    [Route("api/interests")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        InterestRepository _repo;

        public InterestsController()
        {
            _repo = new InterestRepository();
        }

        //GET all interests... /api/interests
        [HttpGet]
        public IActionResult GetAllInterests()
        {
            return Ok(_repo.GetAll());
        }

        //POST new interests to /api/interests
        [HttpPost]
        public IActionResult AddInterests(Interest interest)
        {
            _repo.Add(interest);
            return Created($"api/interests/{interest.Id}", interest);
        }

        //GET to /api/interests/{type}
        [HttpGet("{type}")]
        public IActionResult GetByType(InterestType type)
        {
            var interest = _repo.GetInterestByType(type);

            if (interest == null)
            {
                return NotFound("Not found");
            }
            return Ok(interest);
        }

        //DELETE /api/interests/{Id}
        [HttpDelete("{Id}")]
        public IActionResult RemoveInterest(int interestId)
        {
            _repo.Remove(interestId);

            return Ok();
        }

        [HttpGet("getMembers/{interest}")]
        public IActionResult FindByInterest(string interest)
        {
            var parsedString = interest.Replace("-", " ");
            return Ok(_repo.GetMemberByInterest(parsedString));
        }

        [HttpGet("getMembersByType/{interest}")]
        public IActionResult FindByInterestType(InterestType interest)
        {
            return Ok(_repo.GetMemberByInterest(interest));
        }
    }
}
