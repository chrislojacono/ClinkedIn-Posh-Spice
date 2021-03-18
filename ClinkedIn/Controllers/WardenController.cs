using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClinkedIn.DataAccess;
using ClinkedIn.Models;

namespace ClinkedIn.Controllers
{
    [Route("api/warden")]
    [ApiController]
    public class WardenController : ControllerBase
    {
        MemberRepository _memberRepo;
        public WardenController()
        {
            _memberRepo = new MemberRepository();
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            return Ok(_memberRepo.GetAllMembers());
        }
    }
}
