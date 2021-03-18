using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccess;

namespace ClinkedIn.Controllers
{
    [Route("api/Services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        ServiceRepository _repo;
        public ServicesController()
        {
            _repo = new ServiceRepository();
        }

        [HttpGet("{id}")]
        public IActionResult GetServices(int id)
        {
            var clinkerServices = _repo.ListServices(id);
            return Ok(clinkerServices);
        }
    }
}
